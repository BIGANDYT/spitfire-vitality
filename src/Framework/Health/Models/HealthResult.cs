using Spitfire.Library.Models.Health;

namespace Spitfire.Framework.Health.Models
{
    /// <summary>
    /// The entire health check result which is sent over the wire
    /// </summary>
    public class HealthResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthResult"/> class
        /// </summary>
        public HealthResult()
        {
            this.Totals = new HealthTotals();
            this.Renderings = new HealthIssueGrouping();
        }

        /// <summary>
        /// Gets or sets the total number of issues, grouped by severity
        /// </summary>
        public HealthTotals Totals { get; set; }

        /// <summary>
        /// Gets or sets the issues relating to View renderings or Controller renderings
        /// </summary>
        public HealthIssueGrouping Renderings { get; set; }
    }
}