using Sitecore.Data;
using Sitecore.Data.Items;

namespace Spitfire.Framework.Health.Models
{
    /// <summary>
    /// A HealthIssue related to a specific Sitecore Item
    /// </summary>
    public abstract class HealthIssueItem : HealthIssue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthIssueItem"/> class
        /// </summary>
        /// <param name="severity">The severity of the issue</param>
        /// <param name="message">The specific details about the issue</param>
        /// <param name="item">The Sitecore Item this issue relates to</param>
        protected HealthIssueItem(HealthIssueSeverity severity, string message, Item item)
            : base(severity, message)
        {
            this.ID = item.ID;
            this.Path = item.Paths.Path;
        }

        /// <summary>
        /// Gets or sets the Sitecore ID of the item with the issue
        /// </summary>
        public ID ID { get; set; }

        /// <summary>
        /// Gets or sets the Sitecore Path of the item with the issue
        /// </summary>
        public string Path { get; set; }
    }
}