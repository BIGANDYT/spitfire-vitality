namespace Spitfire.Library.Models.Health
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// A Health "issue" which has been identified on a running Sitecore instance
    /// </summary>
    public class HealthIssue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthIssue"/> class
        /// </summary>
        /// <param name="severity">The severity of the issue</param>
        /// <param name="message">The specific details about the issue</param>
        public HealthIssue(HealthIssueSeverity severity, string message)
        {
            Message = message;
            Severity = severity;
        }
        
        /// <summary>
        /// Gets or sets the specific details about the issue
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the issue severity
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public HealthIssueSeverity Severity { get; set; }
    }
}