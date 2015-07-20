namespace Spitfire.Library.Models.Health
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Model for Health services renderings
    /// </summary>
    public class HealthIssue
    {
        /// <summary>
        /// </summary>
        /// <param name="severity">
        /// </param>
        /// <param name="message">
        /// </param>
        public HealthIssue(HealthIssueSeverity severity, string message)
        {
            this.Message = message;
            this.Severity = severity;
        }
        
        public string Message { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public HealthIssueSeverity Severity { get; set; }
    }
}