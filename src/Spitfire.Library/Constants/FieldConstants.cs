namespace Spitfire.Library.Constants
{
    using Sitecore.Data;

    /// <summary>
    /// Class to contain Field constants for Spitfire project
    /// </summary>
    public static class FieldConstants
    {
        /// <summary>
        /// Class to hold all fields related to the Style template
        /// </summary>
        public static class Style
        {
            /// <summary>
            /// Gets the ID of the Background Image field in the Style template
            /// </summary>
            public static ID BackgroundImage
            {
                get
                {
                    return new ID("{78B4FAEE-F0EA-4956-A46E-0D1BF94D3AD5}");
                }
            }
        }

        /// <summary>
        /// The IDs for the fields on the Banner template
        /// </summary>
        public static class Banner
        {
            /// <summary>
            /// Gets the background image field id
            /// </summary>
            public static ID BackgroundImage
            {
                get
                {
                    return new ID("{60F7B593-2092-42CD-96C3-6A83912D2704}");
                }
            }

            /// <summary>
            /// Gets the title field id
            /// </summary>
            public static ID Title
            {
                get
                {
                    return new ID("{C7C0B642-1DE8-4724-BCCC-6B1C5CF3C14C}");
                }
            }

            /// <summary>
            /// Gets the subtitle field id
            /// </summary>
            public static ID Subtitle
            {
                get
                {
                    return new ID("{8B50FBA2-F31C-4563-9B71-1CF7CADE180A}");
                }
            }

            /// <summary>
            /// Gets the subtitle color field id
            /// </summary>
            public static ID SubtitleColor
            {
                get
                {
                    return new ID("{90F19F3A-9B1D-476A-B87E-7D14243E99A2}");
                }
            }

            /// <summary>
            /// Gets the title color field id
            /// </summary>
            public static ID TitleColor
            {
                get
                {
                    return new ID("{EFEF5442-64FE-4C12-A981-3F2C372E28A8}");
                }
            }

            /// <summary>
            /// Gets the link color field id
            /// </summary>
            public static ID LinkColor
            {
                get
                {
                    return new ID("{3A1F3132-7AA4-433B-BD18-C6B4CE37910F}");
                }
            }

            /// <summary>
            /// Gets the logo field id
            /// </summary>
            public static ID LogoTop
            {
                get
                {
                    return new ID("{9929DCFB-56F7-4EA7-9167-4B5A8299D96D}");
                }
            }

            /// <summary>
            /// Gets the logo left field id
            /// </summary>
            public static ID LogoLeft
            {
                get
                {
                    return new ID("{A473ED8D-28A2-4F55-A9D6-E9779484EE53}");
                }
            }

            /// <summary>
            /// Gets the banner height field id
            /// </summary>
            public static ID BannerHeight
            {
                get
                {
                    return new ID("{7D43EAA1-757D-4E76-8EB8-1CA93DE9CE17}");
                }
            }
        }

        /// <summary>
        /// Fields on the OwlTeaser template
        /// </summary>
        public static class Teaser
        {
            /// <summary>
            /// Gets the field id of the Title field.
            /// </summary>
            public static ID Title
            {
                get
                {
                    return new ID("{8F835316-A8FF-411A-905B-CFC143D7950C}");
                }
            }

            /// <summary>
            /// Gets the Image teaser tag - category of the projects
            /// </summary>
            public static ID Tag
            {
                get
                {
                    return new ID("{B933FD9E-7E74-4D6A-950D-A50F12C5BC82}");
                }
            }
        }

        /// <summary>
        /// Class to hold all fields of the TeaserGroup template
        /// </summary>
        public static class TeaserGroup
        {
            /// <summary>
            /// Gets the field id of the Source field
            /// </summary>
            public static ID Source
            {
                get
                {
                    return new ID("{EFEB569B-6957-4572-BA2C-79C98D55DD93}");
                }
            }

            /// <summary>
            /// Gets the parameter of display/hide social icons
            /// </summary>
            public static ID Display
            {
                get
                {
                    return new ID("{D6303669-FBF0-46B9-836A-74AD60DB0913}");
                }
            }
        }

        /// <summary>
        /// Class to hold all fields of the NavBar template
        /// </summary>
        public static class NavBar
        {
            /// <summary>
            /// Gets the field id of the background color field.
            /// </summary>
            public static ID BackgroundColor
            {
                get
                {
                    return new ID("{7A40C9D8-1018-44F0-A341-E47C5DFAE811}");
                }
            }

            /// <summary>
            /// Gets the field id of the Logo field
            /// </summary>
            public static ID Logo
            {
                get
                {
                    return new ID("{4C245976-F742-4291-843F-998DAD47708A}");
                }
            }
        }

        /// <summary>
        /// Class to hold all fields of the NavItem template
        /// </summary>
        public static class NavItem
        {
            /// <summary>
            /// Gets the navigation item linkname field id
            /// </summary>
            public static ID LinkName
            {
                get
                {
                    return new ID("{68D478EF-F8B6-44EA-B6F3-1D4D191584CE}");
                }
            }

            /// <summary>
            /// Gets the navigation item link anchor for # value of the link
            /// </summary>
            public static ID LinkAnchor
            {
                get
                {
                    return new ID("{B7A2263F-59A0-4BD5-A94C-508D35155DF5}");
                }
            }
        }

        /// <summary>
        /// Class to hold fields of the footer component
        /// </summary>
        public static class Footer
        {
            /// <summary>
            /// Gets the footer background image field id
            /// </summary>
            public static ID BackgroundImage
            {
                get
                {
                    return new ID("{4A68E70A-5A57-412E-8B32-68D1D6557C32}");
                }
            }

            /// <summary>
            /// Gets the footer height field
            /// </summary>
            public static ID FooterHeight
            {
                get
                {
                    return new ID("{61F44A61-2D07-4E92-B38C-FFB94190B745}");
                }
            }
        }

        /// <summary>
        /// Class to hold all fields of the PortfolioGroup template
        /// </summary>
        public static class PortfolioGroup
        {
            /// <summary>
            /// Gets the field id of the Source field
            /// </summary>
            public static ID Source
            {
                get
                {
                    return new ID("{50B0A8D5-91BA-4B02-AA4C-CDC8AA682052}");
                }
            }
        }

        /// <summary>
        /// Naughty field name class
        /// </summary>
        public static class FieldNames
        {
            /// <summary>
            /// The name of the source field
            /// </summary>
            public const string SourceField = "Source";
        }
    }
}
