namespace Spitfire.Modules.AssetRequirements
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Caching;

    public class AssetRequirementList : ICacheable, IEnumerable<AssetRequirement>
    {
        public AssetRequirementList()
        {
            this.Cacheable = true;
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
            return this.items.Sum(x => x.GetDataLength());
        }

        public void Add(AssetRequirement requirement)
        {
            this.items.Add(requirement);
        }

        public IEnumerator<AssetRequirement> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}