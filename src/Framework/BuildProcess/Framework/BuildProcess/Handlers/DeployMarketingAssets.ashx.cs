namespace Spitfire.Modules.BuildProcess.Handlers
{
    using System.Web;

    using Sitecore;
    using Sitecore.Configuration;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Diagnostics;
    using Sitecore.Diagnostics.PerformanceCounters;
    using Sitecore.Globalization;
    using Sitecore.Pipelines;
    using Sitecore.Security.Accounts;
    using Sitecore.SecurityModel;
    using Sitecore.Workflows;
    using Sitecore.Workflows.Simple;

    /// <summary>
    /// Deploy the marketing assets from a CI environment
    /// </summary>
    public class DeployMarketingAssets : IHttpHandler
    {
        /// <summary>
        /// The master database
        /// </summary>
        private readonly Database _masterDb = Factory.GetDatabase("master");

        /// <summary>
        /// Log in as admin user and deploy all marketing assets
        /// </summary>
        /// <param name="context">The Http Context</param>
        public void ProcessRequest(HttpContext context)
        {
            var user = User.FromName(@"sitecore\admin", false);
            using (new UserSwitcher(user))
            {
                this.DeployGoals();
                this.DeployCampaigns();
                this.DeployPathExperienceMaps();
                this.DeploySegments();
            }
        }

        /// <summary>
        /// Select all items based on the Goal and Page Event templates and run them through workflow
        /// </summary>
        private void DeployGoals()
        {
            Item[] goals = this._masterDb.SelectItems("fast:/sitecore/system/Marketing Control Panel/Goals//*[@@templateid='" + BuildProcess.TemplateIDs.Goal + "' or @@templateid='" + BuildProcess.TemplateIDs.PageEvent + "']");
            foreach (Item goal in goals)
            {
                Log.Info("Deploying Goal: " + goal.Name, this);
                this.MoveToStateAndExecuteActions(goal, BuildProcess.ItemIDs.WorkflowAnalyticsDraft);
                this.MoveToStateAndExecuteActions(goal, BuildProcess.ItemIDs.WorkflowAnalyticsDeployed);
            }
        }

        /// <summary>
        /// Select all items based on the Campaign Category and Campaign templates and run them through workflow
        /// </summary>
        private void DeployCampaigns()
        {
            Item[] campaigns = this._masterDb.SelectItems("fast:/sitecore/system/Marketing Control Panel/Campaigns//*[@@templateid='" + BuildProcess.TemplateIDs.CampaignCategory + "' or @@templateid='" + BuildProcess.TemplateIDs.Campaign + "']");
            foreach (Item campaign in campaigns)
            {
                Log.Info("Deploying Campaign: " + campaign.Name, this);
                this.MoveToStateAndExecuteActions(campaign, BuildProcess.ItemIDs.WorkflowAnalyticsDraft);
                this.MoveToStateAndExecuteActions(campaign, BuildProcess.ItemIDs.WorkflowAnalyticsDeployed);
            }
        }

        /// <summary>
        /// Select all items based on the Visit Map templates and run them through workflow
        /// </summary>
        private void DeployPathExperienceMaps()
        {
            Item[] campaigns = this._masterDb.SelectItems("fast:/sitecore/system/Marketing Control Panel/Path Analyzer/Maps/Path Experience Maps//*[@@templateid='" + BuildProcess.TemplateIDs.VisitMap + "']");
            foreach (Item map in campaigns)
            {
                Log.Info("Deploying Path Experience Map: " + map.Name, this);
                this.MoveToStateAndExecuteActions(map, BuildProcess.ItemIDs.WorkflowPathAnalyzerInitializing);
                this.MoveToStateAndExecuteActions(map, BuildProcess.ItemIDs.WorkflowPathAnalyzerDeployed);
            }
        }

        /// <summary>
        /// Select all items based on the Segment template and run them through workflow
        /// </summary>
        private void DeploySegments()
        {
            Item[] campaigns = this._masterDb.SelectItems("fast:/sitecore/system/Marketing Control Panel/Experience Analytics/Dimensions//*[@@templateid='" + BuildProcess.TemplateIDs.Segment + "']");
            foreach (Item segment in campaigns)
            {
                Log.Info("Deploying Segment: " + segment.Name, this);
                this.MoveToStateAndExecuteActions(segment, BuildProcess.ItemIDs.WorkflowSegmentInitializing);
                this.MoveToStateAndExecuteActions(segment, BuildProcess.ItemIDs.WorkflowSegmentDeployed);
            }
        }

        /// <summary>
        /// Move an item to a particular workflow state
        /// </summary>
        /// <param name="item">The item to go through workflow</param>
        /// <param name="workflowStateId">The ID of the workflow state</param>
        public void MoveToStateAndExecuteActions(Item item, ID workflowStateId)
        {
            IWorkflowProvider workflowProvider = item.Database.WorkflowProvider;
            IWorkflow workflow = workflowProvider.GetWorkflow(item);

            // if item is in any workflow
            if (workflow != null)
            {
                using (new EditContext(item))
                {
                    // update item's state to the new one
                    item[FieldIDs.WorkflowState] = workflowStateId.ToString();
                }

                Item stateItem = ItemManager.GetItem(workflowStateId, Language.Current, Version.Latest, item.Database, SecurityCheck.Disable);

                // if there are any actions for the new state
                if (!stateItem.HasChildren)
                    return;

                // TODO: Obsolete constructor
                var workflowPipelineArgs = new WorkflowPipelineArgs(item, string.Empty, null);

                // start executing the actions
                Pipeline pipeline = Pipeline.Start(stateItem, workflowPipelineArgs);
                if (pipeline == null)
                    return;

                // TODO: Obsolete class
                WorkflowCounters.ActionsExecuted.IncrementBy(pipeline.Processors.Count);
            }
        }

        /// <summary>
        /// Required sillyness because of generic handler
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}