namespace Spitfire.Library.Models.Core.Components.Snippets
{
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    using Spitfire.Library.Constants;

    /// <summary>
    /// The model for the Step component
    /// </summary>
    public class Step : RenderingModel
    {
        /// <summary>
        /// Gets the background color
        /// </summary>
        public string BackgroundColor { get; private set; }

        /// <summary>
        /// Gets the background text
        /// </summary>
        public string BackgroundText { get; private set; }

        /// <summary>
        /// Gets the color of the text
        /// </summary>
        public string TextColor { get; private set; }
        
        /// <summary>
        /// Initialize the Step components properties
        /// </summary>
        /// <param name="rendering">The rendering to initialize</param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            var rawParameters = rendering["Parameters"];
            if (!string.IsNullOrEmpty(rawParameters))
            {
                var parameters = WebUtil.ParseUrlParameters(rawParameters);

                if (parameters != null && parameters.Count > 0)
                {
                    BackgroundColor = parameters[ParameterConstants.Step.BackgroundColor];
                    BackgroundText = parameters[ParameterConstants.Step.BackgroundText];
                    TextColor = parameters[ParameterConstants.Step.TextColor];
                }
            }
        }
    }
}
