namespace Spitfire.Library.Models.Multilists
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    using Spitfire.Library.Constants;

    /// <summary>
    /// The base class for multilist models
    /// </summary>
    public class MultiListModel : RenderingModel
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

            if (!string.IsNullOrEmpty(this.Item[FieldConstants.FieldNames.SourceField]))
            {
                MultilistField source = this.Item.Fields[FieldConstants.FieldNames.SourceField];

                if (source != null)
                {
                    this.Items = source.GetItems().ToList();
                }
            }
        }
    }
}
