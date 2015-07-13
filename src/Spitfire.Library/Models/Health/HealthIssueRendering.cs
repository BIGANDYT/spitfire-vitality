namespace Spitfire.Library.Models.Health
{
    using Sitecore.Data.Items;

    public class HealthIssueRendering : HealthIssueItem
    {
        public HealthIssueRendering(HealthIssueSeverity severity, string message, Item item)
            : base(severity, message, item)
        {
            this.FilePath = item["Path"];
        }

        public string FilePath { get; set; }
    }
}