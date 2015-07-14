﻿namespace Spitfire.Library.Models.Scaffolding
{
    using Sitecore.Mvc.Presentation;

    using Spitfire.Library.Constants;

    /// <summary>
    /// Aside component model 
    /// </summary>
    public class AsideModel : StyleModel
    {
        /// <summary>
        /// Gets the Component id
        /// </summary>
        /// <value>
        /// Component id value
        /// </value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets cssclass for the Div which is children of the Aside Dom 
        /// </summary>
        /// <value>
        /// Div within Aside Dom CssClass value, e.g., 
        /// </value>
        public string SubCssClass { get; private set; }

        /// <summary>
        /// Initialize rendering 
        /// </summary>
        /// <param name="rendering">The rendering to use</param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            this.Id = rendering.Parameters[ParameterConstants.Id];
            this.SubCssClass = rendering.Parameters[ParameterConstants.Style.SubCssClass];
        }
    }
}