namespace Spitfire.Library.Models.Core.Components.Multilists
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    using Constants;

    /// <summary>
    /// The base class for multilist models
    /// </summary>
    public class MultiList : RenderingModel
    {
        /// <summary>
        /// Gets the list of items
        /// </summary>
        public List<Item> Items { get; private set; }

        /// <summary>
        /// Initializes the rendering
        /// </summary>
        /// <param name="rendering">The rendering to initialize</param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            if (!string.IsNullOrEmpty(Item[FieldConstants.FieldNames.SourceField]))
            {
                MultilistField source = Item.Fields[FieldConstants.FieldNames.SourceField];

                if (source != null)
                {
                    Items = source.GetItems().ToList();
                }
            }
        }
    }
}
