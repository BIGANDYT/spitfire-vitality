namespace Spitfire.Library.Models.Health
{
    using Sitecore.Data;
    using Sitecore.Data.Items;

    public abstract class HealthIssueItem : HealthIssue
    {
        protected HealthIssueItem(HealthIssueSeverity severity, string message, Item item)
            : base(severity, message)
        {
            this.ID = item.ID;
            this.Path = item.Paths.Path;
        }

        public ID ID { get; set; }

        public string Path { get; set; }
    }
}