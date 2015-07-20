namespace Spitfire.Library.Models.Core.Scaffolding
{
    using Sitecore.Mvc.Presentation;

    using Spitfire.Library.Constants;

    /// <summary>
    /// Section component inhireted Style model
    /// </summary>
    public class Section : Style
    {
        /// <summary>
        /// Gets id of the section rendering
        /// </summary>
        /// <value>
        /// Section rendering Id value
        /// </value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets css class value of the child of Section dom
        /// </summary>
        /// <value>
        /// Sub Css class value of the child of section dom
        /// </value>
        public string SubCssClass { get; private set; }

        /// <summary>
        /// Gets Animcation class value; animiation class is set on child div of section
        /// </summary>
        /// <value>
        /// Animation class value
        /// </value>
        public string AnimationClass { get; private set; }

        /// <summary>
        /// Initialize the rendering
        /// </summary>
        /// <param name="rendering">Rendering to initialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            this.Id = rendering.Parameters[ParameterConstants.Id];
            this.SubCssClass = rendering.Parameters[ParameterConstants.Style.SubCssClass];
            this.AnimationClass = rendering.Parameters[ParameterConstants.Style.Animation];
        }
    }
}