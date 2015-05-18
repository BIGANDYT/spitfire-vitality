namespace Spitfire.Models
{
    using Constant;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    public class NavBarModel : IRenderingModel
    {
        /// <summary>
        /// Initialize the NavBar Model
        /// </summary>
        /// <param name="rendering">The Rendering to use</param>
        public void Initialize(Rendering rendering)
        {
            LogoItem = Sitecore.Context.Database.GetItem(SpitfireConstants.ItemConstants.Logo);
        }

        /// <summary>
        /// The item containing the logo
        /// </summary>
        public Item LogoItem { get; private set; }
    }
}
