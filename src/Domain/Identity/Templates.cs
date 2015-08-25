using Sitecore.Data;

namespace Spitfire.Identity
{
    public struct Templates
    {
        public struct Identity
        {
            public static ID ID => new ID("{65D36FDB-AC16-46C9-8E56-57DD04743A24}");
            public struct Fields
            {
                public static ID Logo => new ID("{225DAF9F-3267-4CC8-9BDA-ADFAB764DF2A}");
                public static ID Company => new ID("{800B1462-5DA6-44E5-8CED-BF9AED236AE4}");
                public static ID Address1 => new ID("{8A0444DF-2E69-4973-A930-B402B480BFB8}");
                public static ID Address2 => new ID("{937B4F13-DD92-4DA7-AB90-7A9D73A1F469}");
                public static ID Address3 => new ID("{AE0B547F-9638-4C69-9A6E-4DF95D8AAFD1}");
                public static ID Phone => new ID("{B7F0955E-37E1-4AB0-BBAD-E4D4F2960AF1}");
                public static ID Fax => new ID("{0D257757-DE6F-44C9-82C4-86D940A4A0A8}");
                public static ID Email => new ID("{DCB8BC02-2F7D-41B7-8EF7-7ADFFCB5C50E}");
                public static ID Skype => new ID("{582B5D9C-5D21-45CE-BA09-B1431954A5CA}");
                public static ID AboutUs => new ID("{7545B38C-64BE-443B-9669-44A4B9ECE9FD}");
            }
        }
    }
}
