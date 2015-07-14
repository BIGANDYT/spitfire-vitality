﻿namespace Spitfire.Library.Models.Health
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class HealthIssue
    {
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