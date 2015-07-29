namespace Spitfire.Library.Models.Core.Components.Text
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using Constants;
    using Sitecore;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    /// <summary>
    /// The model for the testimonial component
    /// </summary>
    public class TestimonialModel : RenderingModel
    {
        /// <summary>
        /// Gets a value indicating whether the rating (in stars) needs to be displayed
        /// </summary>
        public bool DisplayStars { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the testimonial should be rendered as the variant with text balloon
        /// </summary>
        public bool TextBalloonVariant { get; private set; }

        public IList<Item> Testimonials { get; private set; }

        /// <summary>
        /// Parse the component parameters to get the correct display for the component
        /// </summary>
        /// <param name="rendering">The rendering to initialize</param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            Testimonials = new List<Item>();

            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                NameValueCollection parameters = WebUtil.ParseUrlParameters(rendering["Parameters"]);

                if (parameters == null || parameters.Count <= 0)
                {
                    return;
                }

                DisplayStars = MainUtil.GetBool(parameters["Show Star Rating"], false);
                TextBalloonVariant = MainUtil.GetBool(parameters["TitleFontSize"], false);
            }

            if (Item != null)
            {
                MultilistField field = Item.Fields[FieldConstants.TeaserGroup.Source];
                if (field != null)
                {
                    Testimonials = field.GetItems();
                }
            }
        }
    }
}