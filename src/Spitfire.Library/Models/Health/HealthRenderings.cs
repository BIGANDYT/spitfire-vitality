namespace Spitfire.Library.Models.Health
{
    using System.Collections.Generic;

    public class HealthRenderings
    {
        public HealthRenderings()
        {
            this.Totals = new HealthTotals();
            this.Issues = new List<HealthIssue>();
        }

        public HealthTotals Totals { get; set; }

        public List<HealthIssue> Issues { get; set; }
    }
}