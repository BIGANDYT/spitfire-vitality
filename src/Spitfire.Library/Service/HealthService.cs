namespace Spitfire.Library.Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Sitecore.Data;
    using Sitecore.Data.Items;

    using Spitfire.Library.Models.Health;

    public class HealthService
    {
        private HealthResult result;

        private Database db;

        public HealthResult GetHealthResult()
        {
            result = new HealthResult();
            db = Sitecore.Configuration.Factory.GetDatabase("master");

            DoRenderings();
            return result;
        }

        private void DoRenderings()
        {
            var renderingsRootItem = db.GetItem("/sitecore/layout/Renderings/Spitfire");
            if (renderingsRootItem == null)
            {
                this.AddRenderingIssue(new HealthIssue(HealthIssueSeverity.Error, "RenderingRootItem not found"));
                return;
            }

            var viewsFolder = HttpContext.Current.Server.MapPath("~/Views/");
            var viewRenderingFiles =
                Directory.GetFiles(viewsFolder, "*.cshtml", SearchOption.AllDirectories)
                    .Select(x => ("/views/" + x.Replace(viewsFolder, string.Empty).Replace("\\", "/")).ToLower())
                    .ToList();

            var foundViewRenderings = new List<string>();

            foreach (var renderingItem in renderingsRootItem.Axes.GetDescendants())
            {
                switch (renderingItem.Template.Name)
                {
                    case "View rendering":
                        // Check rendering path set
                        var path = renderingItem["Path"].ToLower();
                        if (string.IsNullOrEmpty(path))
                        {
                            this.AddRenderingIssue(
                                new HealthIssueRendering(
                                    HealthIssueSeverity.Error,
                                    "Rendering's path not set",
                                    renderingItem));
                            continue;
                        }

                        // Does the rendering exist on the filesystem?
                        if (!viewRenderingFiles.Contains(path))
                        {
                            this.AddRenderingIssue(
                              new HealthIssueRendering(
                                  HealthIssueSeverity.Error,
                                  "File not found: " + path,
                                  renderingItem));
                            continue;
                        }

                        foundViewRenderings.Add(path);

                        // Check the location on filesystem mirrors the location in content tree
                        var expectedFile =
                            renderingItem.Paths.Path.ToLower()
                                .Replace("/sitecore/layout/renderings/spitfire/", string.Empty)
                                .Replace(" ", string.Empty);

                        var expectedPath = string.Format("/views/{0}.cshtml", expectedFile);

                        if (!string.Equals(path, expectedPath, StringComparison.InvariantCultureIgnoreCase))
                        {
                            AddRenderingIssue(
                                new HealthIssueRendering(
                                    HealthIssueSeverity.Warning,
                                    "Expected path: " + expectedPath,
                                    renderingItem));
                        }

                        //// Check Datasource Template/Location set.
                        //if (renderingItem["Datasource Location"] == string.Empty
                        //    || renderingItem["Datasource Template"] == string.Empty)
                        //{
                        //    AddRenderingIssue(
                        //        new HealthIssueRendering(
                        //            HealthIssueSeverity.Info,
                        //            "Datasource Location or Datasource Template not set",
                        //            renderingItem));
                        //}

                        //// Check caching enabled
                        //if (!IsRenderingCacheable(renderingItem))
                        //{
                        //    AddRenderingIssue(
                        //        new HealthIssueRendering(
                        //            HealthIssueSeverity.Info,
                        //            "No caching enabled",
                        //            renderingItem));
                        //}

                        var modelPath = renderingItem["Model"].ToLower();
                        if (!string.IsNullOrEmpty(modelPath))
                        {
                            var modelItem = db.GetItem(modelPath);
                            if (modelItem == null)
                            {
                                AddRenderingIssue(
                                new HealthIssueRendering(
                                    HealthIssueSeverity.Error,
                                    "ModelItem not found: " + modelPath,
                                    renderingItem));

                                continue;
                            }

                            var expectedModelPath = 
                                renderingItem.Paths.Path.ToLower()
                                    .Replace("/sitecore/layout/renderings/spitfire/", "/sitecore/layout/models/spitfire/");

                            // Check the model item's location in the content tree
                            if (!string.Equals(modelPath, expectedModelPath, StringComparison.InvariantCultureIgnoreCase))
                            {
                                var message = string.Format(
                                    "Expected Model path: {0} - Actual: {1}",
                                    expectedModelPath,
                                    modelPath);

                                AddRenderingIssue(
                                    new HealthIssueRendering(
                                        HealthIssueSeverity.Warning,
                                        message,
                                        renderingItem));
                            }

                            // Check the model type actually exists in the code
                            var modelType = modelItem["Model Type"];

                            var modelType2 = Type.GetType(modelType, false);
                            if (modelType2 == null)
                            {
                                AddRenderingIssue(
                                    new HealthIssueRendering(
                                        HealthIssueSeverity.Error,
                                        "Type not found on model: " + modelType,
                                        renderingItem));
                            }

                            // Check the namespaces match the structure of the content tree
                            var expectedNamespace =
                                renderingItem.Paths.Path.ToLower()
                                    .Replace("/sitecore/layout/renderings/spitfire/", string.Empty)
                                    .Replace("/", ".");

                            var expectedModelType = string.Format("Spitfire.Library.Models.{0},Spitfire.Library", expectedNamespace);
                            if (!string.Equals(modelType, expectedModelType, StringComparison.InvariantCultureIgnoreCase))
                            {
                                var message = string.Format(
                                    "Expected Model Type: {0} - Actual: {1}",
                                    expectedModelType,
                                    modelItem["Model Type"]);

                                AddRenderingIssue(
                                    new HealthIssueRendering(
                                        HealthIssueSeverity.Warning,
                                        message,
                                        renderingItem));
                            }

                            // Check the renderings actually reference the correct model
                            var renderingLocation = HttpContext.Current.Server.MapPath(path);
                            if (File.Exists(renderingLocation))
                            {
                                var renderingContents = File.ReadAllText(renderingLocation);

                                var namespaceWithoutAssembly = modelType.Replace(",Spitfire.Library", string.Empty);
                                var expectedModelDeclaration = "@model " + namespaceWithoutAssembly;

                                if (!renderingContents.Contains(expectedModelDeclaration))
                                {
                                    AddRenderingIssue(
                                        new HealthIssueRendering(
                                            HealthIssueSeverity.Warning,
                                            "Model declaration missing: " + expectedModelDeclaration,
                                            renderingItem));
                                }
                            }
                        }

                        break;
                }
            }

            var leftoverViewRenderings = viewRenderingFiles.Except(foundViewRenderings);
            foreach (var leftoverViewRendering in leftoverViewRenderings)
            {
                if (leftoverViewRendering.Contains("/shared/") || leftoverViewRendering.Contains("/layouts/"))
                {
                    continue;
                }

                AddRenderingIssue(new HealthIssue(HealthIssueSeverity.Warning, "Unused view: " + leftoverViewRendering));
            }
        }

        private bool IsRenderingCacheable(Item renderingItem)
        {
            if (renderingItem["Cacheable"] != "1")
            {
                return false;
            }

            return renderingItem["VaryByLogin"] == "1"
                || renderingItem["VaryByData"] == "1"
                || renderingItem["VaryByQueryString"] == "1"
                || renderingItem["VaryByDevice"] == "1"
                || renderingItem["VaryByParm"] == "1"
                || renderingItem["VaryByUser"] == "1";
        }

        private void AddRenderingIssue(HealthIssue issue)
        {
            if (issue.Severity == HealthIssueSeverity.Error)
            {
                result.Totals.NumErrors++;
                result.Renderings.Totals.NumErrors++;
            }
            else if (issue.Severity == HealthIssueSeverity.Warning)
            {
                result.Totals.NumWarnings++;
                result.Renderings.Totals.NumWarnings++;
            }
            else if (issue.Severity == HealthIssueSeverity.Info)
            {
                result.Totals.NumInfo++;
                result.Renderings.Totals.NumInfo++;
            }

            result.Renderings.Issues.Add(issue);
        }
    }
}