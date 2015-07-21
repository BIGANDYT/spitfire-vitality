namespace Spitfire.Library.Models.AssetRequirements
{
    using Sitecore.Caching;
    using Sitecore.Data;

    public class JavaScriptRequirementCache : CustomCache
    {
        public JavaScriptRequirementCache(long maxSize)
            : base("Spitfire.JavaScriptRequirements", maxSize)
        {
        }

        public JavaScriptRequirementList Get(ID cacheKey)
        {
            return (JavaScriptRequirementList)GetObject(cacheKey);
        }

        public void Set(ID cacheKey, JavaScriptRequirementList requirementList)
        {
            SetObject(cacheKey, requirementList);
        }
    }
}