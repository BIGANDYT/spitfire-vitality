using Sitecore.Caching;
using Sitecore.Data;

namespace Spitfire.Framework.Assets.Models
{
    internal class AssetRequirementCache : CustomCache
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