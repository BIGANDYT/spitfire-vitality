namespace Spitfire.Library.Constants
{
    using Sitecore.Data;

    /// <summary>
    /// Class to hold all template ids
    /// </summary>
    public static class TemplateIds
    {
        /// <summary>
        /// Gets the id of the NavBar template
        /// </summary>
        public static ID NavBar { get; private set; } = new ID("{A12D613D-7E9E-4392-A405-36B8A2CE659F}");

        /// <summary>
        /// Gets the ID of the NavItem template
        /// </summary>
        public static ID NavItem { get; private set; } = new ID("{21FC97B7-6622-4248-AA98-F2DDEBA46895}");

        /// <summary>
        /// Gets the ID of the SiteRoot template
        /// </summary>
        public static ID SiteRoot { get; private set; } = new ID("{0643D9D4-F30B-4B07-91D0-289CC324C9CF}");
    }
}