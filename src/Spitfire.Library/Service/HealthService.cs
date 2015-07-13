namespace Spitfire.Library.Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Sitecore.Data;
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

                        var modelPath = renderingItem["Model"].ToLower();
                        if (!string.IsNullOrEmpty(modelPath))
                        {
                            
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

        private void AddRenderingIssue(HealthIssue issue)
        {
            if (issue.Severity == HealthIssueSeverity.Error)
            {
                result.Totals.NumErrors++;
                result.Renderings.Totals.NumErrors++;
            }
            else
            {
                result.Totals.NumWarnings++;
                result.Renderings.Totals.NumWarnings++;
            }

            result.Renderings.Issues.Add(issue);
        }
    }
}