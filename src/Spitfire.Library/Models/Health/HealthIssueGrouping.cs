namespace Spitfire.Library.Models.Health
{
    using System.Collections.Generic;

    /// <summary>
    /// A grouping of Health issues and totals by severity
    /// </summary>
    public class HealthIssueGrouping
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthIssueGrouping"/> class
        /// </summary>
        public HealthIssueGrouping()
        {
            Totals = new HealthTotals();
            Issues = new List<HealthIssue>();
        }

        /// <summary>
        /// Gets or sets the total number of issues, grouped by severity
        /// </summary>
        public HealthTotals Totals { get; set; }

        /// <summary>
        /// Gets or sets the list of HealthIssues
        /// </summary>
        public List<HealthIssue> Issues { get; set; }
    }
}