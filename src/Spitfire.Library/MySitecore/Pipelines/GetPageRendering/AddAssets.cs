namespace Spitfire.Library.MySitecore.Pipelines.GetPageRendering
{
    using System.Linq;
    using Service;
    using Sitecore.Mvc.Pipelines.Response.GetPageRendering;

    /// <summary>
    /// Mvc.BuildPageDefinition pipeline processor to dynamically reference Cassette Bundles
    /// </summary>
    public class AddAssets : GetPageRenderingProcessor
    {
        public override void Process(GetPageRenderingArgs args)
        {
            var javaScriptService = new JavaScriptService();

            // Loop through all the renderings which are cacheable and might not have had their code executed
            foreach (var rendering in args.PageContext.PageDefinition.Renderings.Where(rendering => rendering.Caching.Cacheable))
            {
                javaScriptService.AddFromRenderingCache(rendering.RenderingItem.ID);
            }
        }
    }
}