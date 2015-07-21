namespace Spitfire.Library.Models.Core.Components.Snippets
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    using Constants;

    /// <summary>
    /// Teaser gallery component
    /// </summary>
    public class TeaserGallery : RenderingModel
    {
        /// <summary>
        /// Gets the list of selected teaser items.
        /// </summary>
        /// <value>
        /// List of selected teaser items.
        /// </value>
        public IList<Item> TeaserItems { get; private set; }

        /// <summary>
        /// Initialize the rendering
        /// </summary>
        /// <param name="rendering">Rendering to initialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            if (!string.IsNullOrEmpty(Item[FieldConstants.TeaserGroup.Source]))
            {
                MultilistField teasers = Item.Fields[FieldConstants.TeaserGroup.Source];

                if (teasers != null)
                {
                    TeaserItems = teasers.GetItems().ToList();
                }
            }
        }
    }
}