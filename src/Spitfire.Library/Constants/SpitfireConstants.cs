namespace Spitfire.Library.Constants
{
    using System;

    /// <summary>
    /// Class to contain constants for Spitfire project
    /// </summary>
    public static class SpitfireConstants
    {
        /// <summary>
        /// Class to contain Item constants for Spitfire project
        /// </summary>
        public static class ItemConstants
        {
            /// <summary>
            /// The root for the Home settings root item
            /// </summary>
            public const String SettingsRoot = "{F143A0D0-92E4-450E-8DBE-C7378B65E24A}";
        }

        /// <summary>
        /// Class to hold all template ids
        /// </summary>
        public static class TemplateIds
        {
            /// <summary>
            /// The id of the NavBar template
            /// </summary>
            public const String NavBar = "{A12D613D-7E9E-4392-A405-36B8A2CE659F}";

            /// <summary>
            /// The ID of the NavItem template
            /// </summary>
            public const String NavItem = "{21FC97B7-6622-4248-AA98-F2DDEBA46895}";
        }

        /// <summary>
        /// Class to contain constants from Parameter templates
        /// </summary>
        public static class ParameterConstants
        {
            /// <summary>
            /// The Autoplay field id
            /// </summary>
            public const String Autoplay = "Autoplay";

            /// <summary>
            /// The Loop field id
            /// </summary>
            public const String Loop = "Loop";

            /// <summary>
            /// The Mute field id
            /// </summary>
            public const String Mute = "Mute";
        }

        /// <summary>
        /// Class to contain Field constants for Spitfire project
        /// </summary>
        public static class FieldConstants
        {
            /// <summary>
            /// Class to hold all fields related to the Video template
            /// </summary>
            public static class Video
            {
                /// <summary>
                /// The Video Type field id
                /// </summary>
                public const String Type = "{A9713045-A435-4641-9140-4631B8FCABAE}";

                /// <summary>
                /// The Video Source field id
                /// </summary>
                public const String Source = "{1EC8FCD0-F411-41A7-9B11-1C0BBF6DF9F9}";

            }

            /// <summary>
            /// Class to hold all fields related to the VideoType template
            /// </summary>
            public static class VideoType
            {
                /// <summary>
                /// The Type Name field of the Video Type item
                /// </summary>
                public const String TypeName = "{4C69EEE5-ED95-455D-B28B-E9581A1D8FD5}";
            }

            /// <summary>
            /// Class to hold all fields related to the Style template
            /// </summary>
            public static class Style
            {
                /// <summary>
                /// The ID of the Background Image field in the Style template
                /// </summary>
                public const String BackgroundImage = "{78B4FAEE-F0EA-4956-A46E-0D1BF94D3AD5}";
            }

            /// <summary>
            /// The IDs for the fields on the Banner template
            /// </summary>
            public static class Banner
            {
                /// <summary>
                /// The background image field id
                /// </summary>
                public const String BackgroundImage = "{60F7B593-2092-42CD-96C3-6A83912D2704}";

                /// <summary>
                /// The title field id
                /// </summary>
                public const String Title = "{C7C0B642-1DE8-4724-BCCC-6B1C5CF3C14C}";

                /// <summary>
                /// The subtitle field id
                /// </summary>
                public const String Subtitle = "{8B50FBA2-F31C-4563-9B71-1CF7CADE180A}";

                /// <summary>
                /// The subtitle color field id
                /// </summary>
                public const String SubtitleColor = "{90F19F3A-9B1D-476A-B87E-7D14243E99A2}";

                /// <summary>
                /// The title color field id
                /// </summary>
                public const String TitleColor = "{EFEF5442-64FE-4C12-A981-3F2C372E28A8}";

                /// <summary>
                /// The link color field id
                /// </summary>
                public const String LinkColor = "{3A1F3132-7AA4-433B-BD18-C6B4CE37910F}";

                /// <summary>
                /// The logo field id
                /// </summary>
                public const String LogoTop = "{9929DCFB-56F7-4EA7-9167-4B5A8299D96D}";

                /// <summary>
                /// The logo left field id
                /// </summary>
                public const String LogoLeft = "{A473ED8D-28A2-4F55-A9D6-E9779484EE53}";

                /// <summary>
                /// The banner height field id
                /// </summary>
                public const String BannerHeight = "{7D43EAA1-757D-4E76-8EB8-1CA93DE9CE17}";
            }

            /// <summary>
            /// Fields on the OwlTeaser template
            /// </summary>
            public static class Teaser
            {
                /// <summary>
                /// The field id of the Title field.
                /// </summary>
                public const String Title = "{8F835316-A8FF-411A-905B-CFC143D7950C}";
                /// <summary>
                /// Image teaser tag - category of the projects
                /// </summary>
                public const String Tag = "{B933FD9E-7E74-4D6A-950D-A50F12C5BC82}";
            }

            /// <summary>
            /// Class to hold all fields of the TeaserGroup template
            /// </summary>
            public static class TeaserGroup
            {
                /// <summary>
                /// The field id of the Source field
                /// </summary>
                public const String Source = "{EFEB569B-6957-4572-BA2C-79C98D55DD93}";
                /// <summary>
                /// Parameter of display/hide social icons
                /// </summary>
                public const String Display = "{D6303669-FBF0-46B9-836A-74AD60DB0913}";
            }

            /// <summary>
            /// Class to hold all fields of the NavBar template
            /// </summary>
            public static class NavBar
            {
                /// <summary>
                /// The field id of the background color field.
                /// </summary>
                public const String BackgroundColor = "{7A40C9D8-1018-44F0-A341-E47C5DFAE811}";

                /// <summary>
                /// The field id of the Logo field
                /// </summary>
                public const String Logo = "{4C245976-F742-4291-843F-998DAD47708A}";
            }

            /// <summary>
            /// Class to hold all fields of the NavItem template
            /// </summary>
            public static class NavItem
            {
                public const String LinkName = "{68D478EF-F8B6-44EA-B6F3-1D4D191584CE}";

                public const String LinkAnchor = "{B7A2263F-59A0-4BD5-A94C-508D35155DF5}";
            }
        }
    }
}
