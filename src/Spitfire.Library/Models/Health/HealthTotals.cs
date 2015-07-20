namespace Spitfire.Library.Models.Health
{
    /// <summary>
    /// The total number of issues, grouped by severity.
    /// </summary>
    public class HealthTotals
    {
        /// <summary>
        /// Gets or sets the number of issues with "Error" severity.
        /// </summary>
        public int NumErrors { get; set; }

        /// <summary>
        /// Gets or sets the number of issues with "Warning" severity.
        /// </summary>
        public int NumWarnings { get; set; }

        /// <summary>
        /// Gets or sets the number of issues with "Info" severity.
        /// </summary>
        public int NumInfo { get; set; }
    }
}