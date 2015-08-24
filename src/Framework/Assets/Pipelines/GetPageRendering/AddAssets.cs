using Sitecore.Mvc.Pipelines.Response.GetPageRendering;

namespace Spitfire.Framework.Assets.Pipelines.GetPageRendering
{
    /// <summary>
    /// Mvc.BuildPageDefinition pipeline processor to dynamically reference Cassette Bundles
    /// </summary>
    public class AddAssets : GetPageRenderingProcessor
    {
        public override void Process(GetPageRenderingArgs args)
        {
            // Loop through all the renderings which are cacheable and might not have had their code executed
            foreach (var rendering in args.PageContext.PageDefinition.Renderings)
            {
                // Only run in "normal" page mode, otherwise we assume renderings are always executed.
                if (Sitecore.Context.PageMode.IsNormal && rendering.Caching.Cacheable)
                {
                    AssetRepository.Current.Add(rendering.RenderingItem.ID);
                }

                var renderingItem = rendering.RenderingItem.InnerItem;

                var javaScriptAssets = renderingItem[Templates.RenderingAssets.Fields.ScriptFiles];
                foreach (var javaScriptAsset in javaScriptAssets.Split(';', ',', '\n'))
                {
                    AssetRepository.Current.AddScript(javaScriptAsset, true);
                }

                var javaScriptInline = renderingItem[Templates.RenderingAssets.Fields.InlineScript];
                if (!string.IsNullOrEmpty(javaScriptInline))
                {
                    AssetRepository.Current.AddScript(javaScriptInline, renderingItem.ID.ToString(), true);
                }

                var cssAssets = renderingItem[Templates.RenderingAssets.Fields.StylingFiles];
                foreach (var cssAsset in cssAssets.Split(';', ',', '\n'))
                {
                    AssetRepository.Current.AddStyling(cssAsset, true);
                }

                var cssInline = renderingItem[Templates.RenderingAssets.Fields.InlineStyling];
                if (!string.IsNullOrEmpty(cssInline))
                {
                    AssetRepository.Current.AddStyling(cssInline, renderingItem.ID.ToString(), true);
                }
            }
        }
    }
}