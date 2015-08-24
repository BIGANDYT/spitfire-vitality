namespace Spitfire.Modules.AssetRequirements
{
    using Sitecore.Mvc.Pipelines.Response.GetPageRendering;

    /// <summary>
    /// Mvc.BuildPageDefinition pipeline processor to dynamically reference Cassette Bundles
    /// </summary>
    public class AddAssetsPipeline : GetPageRenderingProcessor
    {
        public override void Process(GetPageRenderingArgs args)
        {
            // Loop through all the renderings which are cacheable and might not have had their code executed
            foreach (var rendering in args.PageContext.PageDefinition.Renderings)
            {
                // Only run in "normal" page mode, otherwise we assume renderings are always executed.
                if (Sitecore.Context.PageMode.IsNormal && rendering.Caching.Cacheable)
                {
                    AssetRequirementService.Current.AddFromRenderingCache(rendering.RenderingItem.ID);
                }

                var renderingItem = rendering.RenderingItem.InnerItem;

                var javaScriptAssets = renderingItem["JavaScript assets"];
                foreach (var javaScriptAsset in javaScriptAssets.Split(';', ',', '\n'))
                {
                    AssetRequirementService.Current.AddJavaScriptFile(javaScriptAsset, true);
                }

                var javaScriptInline = renderingItem["JavaScript inline"];
                if (!string.IsNullOrEmpty(javaScriptInline))
                {
                    AssetRequirementService.Current.AddJavaScriptInline(javaScriptInline, renderingItem.ID.ToString(), true);
                }

                var cssAssets = renderingItem["Css assets"];
                foreach (var cssAsset in cssAssets.Split(';', ',', '\n'))
                {
                    AssetRequirementService.Current.AddCssFile(cssAsset, true);
                }

                var cssInline = renderingItem["Css inline"];
                if (!string.IsNullOrEmpty(cssInline))
                {
                    AssetRequirementService.Current.AddCssInline(cssInline, renderingItem.ID.ToString(), true);
                }
            }
        }
    }
}