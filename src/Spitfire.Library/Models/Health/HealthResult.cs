namespace Spitfire.Library.Models.Health
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
            Totals = new HealthTotals();
            Renderings = new HealthIssueGrouping();
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