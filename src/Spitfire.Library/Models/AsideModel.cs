﻿namespace Spitfire.Library.Models
{
    using Sitecore.Mvc.Presentation;

    public class AsideModel : StyleModel
    {
        public string Id { get; set; }
        public string SubCssClass { get; private set; }
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            Id = rendering.Parameters["Id"];
            SubCssClass = rendering.Parameters["SubCssClass"];
        }
    }
}