namespace Spitfire.Library.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;

    using Sitecore.Data;

    using Spitfire.Library.Constants;
    using Spitfire.Library.Models.Health;

    /// <summary>
    /// Health Service responsible for preparing and returning a "HealthResult" analysis
    /// of the relationship between renderings, templates and models, their location in the content tree
    /// and also on the file system.
    /// </summary>
    public class HealthService
    {
        /// <summary>
        /// Root location of views
        /// </summary>
        private const string ViewRootPath = "/sitecore/layout/renderings/spitfire/";

        /// <summary>
        /// Root location of models
        /// </summary>
        private const string ModelRootPath = "/sitecore/layout/models/spitfire/";

        /// <summary>
        /// The HealthResult to be returned
        /// </summary>
        private HealthResult result;

        /// <summary>
        /// The Sitecore Database
        /// </summary>
        private Database db;

        /// <summary>
        /// Gets the HealthResult analysis of this Sitecore instance
        /// </summary>
        /// <returns>The HealthResult analysis</returns>
        public HealthResult GetHealthResult()
        {
            result = new HealthResult();
            db = Sitecore.Configuration.Factory.GetDatabase("master");

            DoRenderings();
            return result;
        }

        /// <summary>
        /// Analyze all Renderings and their relationships with models.
        /// </summary>
        private void DoRenderings()
        {
            var renderingsRootItem = db.GetItem(ItemConstants.SpitfireRenderingsRoot);

            // Check if the renderings root item exists
            if (renderingsRootItem == null)
            {
                AddRenderingIssue(new HealthIssue(HealthIssueSeverity.Error, "RenderingRootItem not found"));
                return;
            }

            var viewsFolder = HttpContext.Current.Server.MapPath("~/Views/");

            // Prepares a list of all the view renderings on the filesystem.
            var viewRenderingFiles =
                Directory.GetFiles(viewsFolder, "*.cshtml", SearchOption.AllDirectories)
                    .Select(x => ("/views/" + x.Replace(viewsFolder, string.Empty).Replace("\\", "/")).ToLower())
                    .ToList();

            // Initialize a list of "found" view renderings so that we can deduce later which are not used.
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
                            AddRenderingIssue(
                                new HealthIssueRendering(
                                    HealthIssueSeverity.Error,
                                    "Rendering's path not set",
                                    renderingItem));
                            continue;
                        }

                        // Does the rendering exist on the filesystem?
                        if (!viewRenderingFiles.Contains(path))
                        {
                            AddRenderingIssue(
                              new HealthIssueRendering(
                                  HealthIssueSeverity.Error,
                                  "File not found: " + path,
                                  renderingItem));
                            continue;
                        }

                        // We found a view rendering so make sure it doesn't show up in the list of "unused" renderings later.
                        foundViewRenderings.Add(path);

                        // Check the location on filesystem mirrors the location in content tree
                        var expectedFile =
                            renderingItem.Paths.Path.ToLower()
                                .Replace(ViewRootPath, string.Empty)
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

                        // Check caching enabled
                        if (renderingItem["Cacheable"] != "1")
                        {
                            AddRenderingIssue(
                                new HealthIssueRendering(
                                    HealthIssueSeverity.Info,
                                    "No caching enabled",
                                    renderingItem));
                        }

                        var modelPath = renderingItem["Model"].ToLower();
                        if (!string.IsNullOrEmpty(modelPath))
                        {
                            var modelItem = db.GetItem(modelPath);

                            // Check if the model item actually exists.
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
                                    .Replace(ViewRootPath, ModelRootPath);

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
                            var modelTypeString = modelItem["Model Type"];

                            var modelType = Type.GetType(modelTypeString, false);
                            if (modelType == null)
                            {
                                AddRenderingIssue(
                                    new HealthIssueRendering(
                                        HealthIssueSeverity.Error,
                                        "Type not found on model: " + modelTypeString,
                                        renderingItem));
                            }

                            // Check the namespaces match the structure of the content tree
                            var expectedNamespace =
                                renderingItem.Paths.Path.ToLower()
                                    .Replace(ViewRootPath, string.Empty)
                                    .Replace("/", ".");

                            var expectedModelType = string.Format("Spitfire.Library.Models.{0},Spitfire.Library", expectedNamespace);
                            if (!string.Equals(modelTypeString, expectedModelType, StringComparison.InvariantCultureIgnoreCase))
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

                                var namespaceWithoutAssembly = modelTypeString.Replace(" ", string.Empty).Replace(",Spitfire.Library", string.Empty);
                                var expectedModelDeclaration = "@model " + namespaceWithoutAssembly;

                                if (!renderingContents.Contains(expectedModelDeclaration))
                                {
                                    AddRenderingIssue(
                                        new HealthIssueRendering(
                                            HealthIssueSeverity.Warning,
                                            "Model declaration missing: " + expectedModelDeclaration,
                                            renderingItem));
                                }

                                // Check Datasource Template/Location set
                                if (renderingItem["Datasource Location"] == string.Empty
                                    || renderingItem["Datasource Template"] == string.Empty)
                                {
                                    AddRenderingIssue(
                                    new HealthIssueRendering(
                                        HealthIssueSeverity.Warning,
                                        "Datasource Location or Datasource Template not set",
                                        renderingItem));
                                }
                            }
                        }

                        break;
                }
            }

            // Now that we have our list of renderings on the filesystem and the ones which have been defined in Sitecore,
            // deduce which files are not being used.
            var leftoverViewRenderings = viewRenderingFiles.Except(foundViewRenderings);
            foreach (var leftoverViewRendering in leftoverViewRenderings)
            {
                if (leftoverViewRendering.Contains("/shared/")
                    || leftoverViewRendering.Contains("/layouts/")
                    || leftoverViewRendering.Contains("/form/"))
                {
                    continue;
                }

                AddRenderingIssue(new HealthIssue(HealthIssueSeverity.Warning, "Unused view: " + leftoverViewRendering));
            }
        }

        /// <summary>
        /// Adds the rendering issue to the list of issues and updates the totals
        /// depending on the issue's severity.
        /// </summary>
        /// <param name="issue">The issue to add to the list</param>
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