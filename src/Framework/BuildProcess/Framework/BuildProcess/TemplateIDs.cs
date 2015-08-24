namespace Spitfire.Framework.BuildProcess
{
    using Sitecore.Data;

    public static class TemplateIDs
    {
        /// <summary>
        /// Gets the ID of the Segment template
        /// </summary>
        public static ID Segment { get; } = new ID("{A87EE256-044E-450D-A73C-9A464AA773EF}");

        /// <summary>
        /// Gets the ID of the Visit Map template
        /// </summary>
        public static ID VisitMap { get; } = new ID("{1A0C1FE0-7956-4020-981B-4CEA3C4F114A}");

        /// <summary>
        /// Gets the ID of the Campaign Category template
        /// </summary>
        public static ID CampaignCategory { get; } = new ID("{56682FE6-9679-4B69-9589-60C99AA08BEC}");

        /// <summary>
        /// Gets the ID of the Campaign template
        /// </summary>
        public static ID Campaign { get; } = new ID("{94FD1606-139E-46EE-86FF-BC5BF3C79804}");

        /// <summary>
        /// Gets the ID of the Goal template
        /// </summary>
        public static ID Goal { get; } = new ID("{475E9026-333F-432D-A4DC-52E03B75CB6B}");

        /// <summary>
        /// Gets the ID of the Page Event template
        /// </summary>
        public static ID PageEvent { get; } = new ID("{059CFBDF-49FC-4F14-A4E5-B63E1E1AFB1E}");
    }
}