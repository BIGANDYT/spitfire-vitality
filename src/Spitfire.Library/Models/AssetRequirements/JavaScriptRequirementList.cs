namespace Spitfire.Library.Models.AssetRequirements
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Caching;

    public class JavaScriptRequirementList : ICacheable, IEnumerable<JavaScriptRequirement>
    {
        private readonly List<JavaScriptRequirement> items = new List<JavaScriptRequirement>();

        public event DataLengthChangedDelegate DataLengthChanged;

        public bool Cacheable { get; set; } = true;

        public bool Immutable => true;

        public long GetDataLength()
        {
            return items.Sum(x => x.GetDataLength());
        }

        public void Add(JavaScriptRequirement requirement)
        {
            items.Add(requirement);
        }

        public IEnumerator<JavaScriptRequirement> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}