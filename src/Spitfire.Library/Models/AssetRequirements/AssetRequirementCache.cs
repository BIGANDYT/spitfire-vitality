namespace Spitfire.Library.Models.AssetRequirements
{
    using Sitecore.Caching;
    using Sitecore.Data;

    public class AssetRequirementCache : CustomCache
    {
        public AssetRequirementCache(long maxSize)
            : base("Spitfire.AssetRequirements", maxSize)
        {
        }

        public AssetRequirementList Get(ID cacheKey)
        {
            return (AssetRequirementList)GetObject(cacheKey);
        }

        public void Set(ID cacheKey, AssetRequirementList requirementList)
        {
            SetObject(cacheKey, requirementList);
        }
    }
}