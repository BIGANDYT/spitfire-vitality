namespace Spitfire.Modules.BuildProcess
{
    using Sitecore.Data;

    public static class ItemIDs
    {
        /// <summary>
        /// Gets the ID for the Draft state in the Analytics workflow
        /// </summary>
        public static ID WorkflowAnalyticsDraft { get; } = new ID("{39156DC0-21C6-4F64-B641-31E85C8F5DFE}");

        /// <summary>
        /// Gets the ID for the Deployed state in the Analytics workflow
        /// </summary>
        public static ID WorkflowAnalyticsDeployed { get; } = new ID("{EDCBB550-BED3-490F-82B8-7B2F14CCD26E}");

        /// <summary>
        /// Gets the ID for the Initializing state in the Path Analyzer workflow
        /// </summary>
        public static ID WorkflowPathAnalyzerInitializing { get; } = new ID("{C0DA66F8-4371-412B-B716-648DA4657459}");

        /// <summary>
        /// Gets the ID for the Deployed state in the Path Analyzer workflow
        /// </summary>
        public static ID WorkflowPathAnalyzerDeployed { get; } = new ID("{D86A72B4-7C3D-447E-9622-66B0DC1243F8}");

        /// <summary>
        /// Gets the ID for the Initializing state in the Segment workflow
        /// </summary>
        public static ID WorkflowSegmentInitializing { get; } = new ID("{E39E0ADC-9487-4BA4-950D-1993D5614B8E}");

        /// <summary>
        /// Gets the ID for the Deployed state in the Segment workflow
        /// </summary>
        public static ID WorkflowSegmentDeployed { get; } = new ID("{3C70E8B1-D6D2-42CC-8E21-1AE8EC72A0FB}");
    }
}