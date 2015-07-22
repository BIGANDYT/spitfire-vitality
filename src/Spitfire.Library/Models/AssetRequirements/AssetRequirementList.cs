namespace Spitfire.Library.Models.AssetRequirements
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Caching;

    public class AssetRequirementList : ICacheable, IEnumerable<AssetRequirement>
    {
        public AssetRequirementList()
        {
            Cacheable = true;
        }

        private readonly List<AssetRequirement> items = new List<AssetRequirement>();

        public event DataLengthChangedDelegate DataLengthChanged;

        public bool Cacheable { get; set; }

        public bool Immutable
        {
            get
            {
                return true;
            }
        }

        public long GetDataLength()
        {
            return items.Sum(x => x.GetDataLength());
        }

        public void Add(AssetRequirement requirement)
        {
            items.Add(requirement);
        }

        public IEnumerator<AssetRequirement> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}