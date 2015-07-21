namespace Spitfire.Library.Models.Health
{
    using Sitecore.Data.Items;

    /// <summary>
    /// A HealthIssue related to a layout "Rendering" i.e. a View rendering or a Controller rendering
    /// </summary>
    public class HealthIssueRendering : HealthIssueItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthIssueRendering"/> class
        /// </summary>
        /// <param name="severity">The severity of the issue</param>
        /// <param name="message">The specific details about the issue</param>
        /// <param name="item">The Sitecore Item this issue relates to</param>
        public HealthIssueRendering(HealthIssueSeverity severity, string message, Item item)
            : base(severity, message, item)
        {
            FilePath = item["Path"];
        }

        /// <summary>
        /// Gets or sets the path on the filesystem of the View rendering
        /// </summary>
        public string FilePath { get; set; }
    }
}