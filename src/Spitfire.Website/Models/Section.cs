using Sitecore.Mvc.Presentation;

namespace Spitfire.Website.Models
{
    /// <summary>
    /// Section component inherited Style model
    /// </summary>
    public class Section : RenderingModel
    {
        /// <summary>
        /// Gets id of the section rendering
        /// </summary>
        /// <value>
        /// Section rendering Id value
        /// </value>
        public string Id { get; private set; }

        /// <summary>
        /// Initialize the rendering
        /// </summary>
        /// <param name="rendering">Rendering to initialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            this.Id = rendering.Parameters[ParameterConstants.Id];
        }
    }
}