namespace Spitfire.Library.Models
{
    using Sitecore.Mvc.Presentation;

    public class SectionModel : StyleModel
    {        
        public string Id = string.Empty;
        public string SubCssClass = string.Empty;

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            Id = rendering.Parameters["Id"];
            SubCssClass = rendering.Parameters["SubCssClass"];
        }
    }
}