namespace Spitfire.Library.Constants
{
    using Sitecore.Data;

    /// <summary>
    /// Class to contain Item constants for Spitfire project
    /// </summary>
    public static class ItemConstants
    {
        /// <summary>
        /// Gets the root for the Home settings root item
        /// </summary>
        public static ID SettingsRoot
        {
            get
            {
                return new ID("{F143A0D0-92E4-450E-8DBE-C7378B65E24A}");
            }
        }

        /// <summary>
        /// Gets the ID for the root of the Spitfire folder in renderings
        /// </summary>
        public static ID SpitfireRenderingsRoot
        {
            get
            {
                return new ID("{324F31CB-6D56-49F2-996E-A617691A9929}");
            }
        }

        /// <summary>
        /// Gets the ID for the Draft state in the Analytics workflow
        /// </summary>
        public static ID WorkflowAnalyticsDraft
        {
            get
            {
                return new ID("{39156DC0-21C6-4F64-B641-31E85C8F5DFE}");
            }
        }

        /// <summary>
        /// Gets the ID for the Deployed state in the Analytics workflow
        /// </summary>
        public static ID WorkflowAnalyticsDeployed
        {
            get
            {
                return new ID("{EDCBB550-BED3-490F-82B8-7B2F14CCD26E}");
            }
        }

        /// <summary>
        /// Gets the ID for the Initializing state in the Path Analyzer workflow
        /// </summary>
        public static ID WorkflowPathAnalyzerInitializing
        {
            get
            {
                return new ID("{C0DA66F8-4371-412B-B716-648DA4657459}");
            }
        }

        /// <summary>
        /// Gets the ID for the Deployed state in the Path Analyzer workflow
        /// </summary>
        public static ID WorkflowPathAnalyzerDeployed
        {
            get
            {
                return new ID("{D86A72B4-7C3D-447E-9622-66B0DC1243F8}");
            }
        }

        /// <summary>
        /// Gets the ID for the Initializing state in the Segment workflow
        /// </summary>
        public static ID WorkflowSegmentInitializing
        {
            get
            {
                return new ID("{E39E0ADC-9487-4BA4-950D-1993D5614B8E}");
            }
        }

        /// <summary>
        /// Gets the ID for the Deployed state in the Segment workflow
        /// </summary>
        public static ID WorkflowSegmentDeployed
        {
            get
            {
                return new ID("{3C70E8B1-D6D2-42CC-8E21-1AE8EC72A0FB}");
            }
        }
    }
}