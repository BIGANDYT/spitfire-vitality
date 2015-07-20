namespace Spitfire.Library.Models.Health
{
    /// <summary>
    /// The severity of a Health issue
    /// </summary>
    public enum HealthIssueSeverity
    {
        /// <summary>
        /// An issue where it is not possible to ascertain whether this is a warning, so you are informed just in case.
        /// </summary>
        Info,

        /// <summary>
        /// An issue which will cause performance issues or perhaps confusion between your co-developers.
        /// </summary>
        Warning,

        /// <summary>
        /// An issue which will most likely cause exceptions in runtime
        /// </summary>
        Error
    }
}