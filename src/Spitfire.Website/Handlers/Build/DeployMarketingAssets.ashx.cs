namespace Spitfire.Website.Handlers.Build
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

    public class DeployMarketingAssets : IHttpHandler
    {
        private readonly Database masterDb = Factory.GetDatabase("master");
    
        public void ProcessRequest(HttpContext context)
        {
            var user = User.FromName(@"sitecore\admin", false);
            using (new UserSwitcher(user))
            {
                DeployGoals();
                DeployCampaigns();
                DeployPathExperienceMaps();
                DeploySegments();
            }
        }

        private void DeployGoals()
        {
            Item[] goals = masterDb.SelectItems("fast:/sitecore/system/Marketing Control Panel/Goals//*[@@templateid='{475E9026-333F-432D-A4DC-52E03B75CB6B}' or @@templateid='{059CFBDF-49FC-4F14-A4E5-B63E1E1AFB1E}']");
            foreach (Item goal in goals)
            {
                Log.Info("Deploying Goal: " + goal.Name, this);
                this.MoveToStateAndExecuteActions(goal, new ID("{39156DC0-21C6-4F64-B641-31E85C8F5DFE}"));
                this.MoveToStateAndExecuteActions(goal, new ID("{EDCBB550-BED3-490F-82B8-7B2F14CCD26E}"));
            }
        }

        private void DeployCampaigns()
        {
            Item[] campaigns = masterDb.SelectItems("fast:/sitecore/system/Marketing Control Panel/Campaigns//*[@@templateid='{56682FE6-9679-4B69-9589-60C99AA08BEC}' or @@templateid='{94FD1606-139E-46EE-86FF-BC5BF3C79804}']");
            foreach (Item campaign in campaigns)
            {
                Log.Info("Deploying Campaign: " + campaign.Name, this);
                this.MoveToStateAndExecuteActions(campaign, new ID("{39156DC0-21C6-4F64-B641-31E85C8F5DFE}"));
                this.MoveToStateAndExecuteActions(campaign, new ID("{EDCBB550-BED3-490F-82B8-7B2F14CCD26E}"));
            }
        }

        private void DeployPathExperienceMaps()
        {
            Item[] campaigns = masterDb.SelectItems("fast:/sitecore/system/Marketing Control Panel/Path Analyzer/Maps/Path Experience Maps//*[@@templateid='{1A0C1FE0-7956-4020-981B-4CEA3C4F114A}']");
            foreach (Item map in campaigns)
            {
                Log.Info("Deploying Path Experience Map: " + map.Name, this);
                this.MoveToStateAndExecuteActions(map, new ID("{C0DA66F8-4371-412B-B716-648DA4657459}"));
                this.MoveToStateAndExecuteActions(map, new ID("{D86A72B4-7C3D-447E-9622-66B0DC1243F8}"));
            }
        }

        private void DeploySegments()
        {
            Item[] campaigns = masterDb.SelectItems("fast:/sitecore/system/Marketing Control Panel/Experience Analytics/Dimensions//*[@@templateid='{A87EE256-044E-450D-A73C-9A464AA773EF}']");
            foreach (Item segment in campaigns)
            {
                Log.Info("Deploying Segment: " + segment.Name, this);
                this.MoveToStateAndExecuteActions(segment, new ID("{E39E0ADC-9487-4BA4-950D-1993D5614B8E}"));
                this.MoveToStateAndExecuteActions(segment, new ID("{3C70E8B1-D6D2-42CC-8E21-1AE8EC72A0FB}"));
            }
        }

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

                WorkflowPipelineArgs workflowPipelineArgs = new WorkflowPipelineArgs(item, string.Empty, null);

                // start executing the actions
                Pipeline pipeline = Pipeline.Start(stateItem, workflowPipelineArgs);
                if (pipeline == null)
                    return;

                WorkflowCounters.ActionsExecuted.IncrementBy(pipeline.Processors.Count);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}