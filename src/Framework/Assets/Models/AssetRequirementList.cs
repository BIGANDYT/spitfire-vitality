using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Caching;

namespace Spitfire.Framework.Assets.Models
{
    internal class AssetRequirementList : ICacheable, IEnumerable<AssetRequirement>
    {
        private readonly List<AssetRequirement> items = new List<AssetRequirement>();

        public AssetRequirementList()
        {
            this.Cacheable = true;
        }

        public event DataLengthChangedDelegate DataLengthChanged;
        public bool Cacheable { get; set; }

        public bool Immutable => true;

        public long GetDataLength()
        {
            return this.items.Sum(x => x.GetDataLength());
        }

        public IEnumerator<AssetRequirement> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(AssetRequirement requirement)
        {
            this.items.Add(requirement);
        }
    }
}