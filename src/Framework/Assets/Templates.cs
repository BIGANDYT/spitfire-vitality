using Sitecore.Data;

namespace Spitfire.Framework.Assets
{
    public struct Templates
    {
        public struct RenderingAssets
        {
            public static ID ID => new ID("{7CEAC341-B953-4C69-B907-EE44302BF6AE}");
            public struct Fields
            {
                public static ID ScriptFiles => new ID("{E514A1EB-DDBA-44F7-8528-82CA2280F778}");
                public static ID StylingFiles => new ID("{4867D192-326A-4AA4-81EF-EA430E224AFF}");
                public static ID InlineScript => new ID("{11421560-0BCB-403A-B099-8595C34341FD}");
                public static ID InlineStyling => new ID("{FD0DEC96-B220-4196-B544-68B11EEE727A}");
            }
        }
    }
}