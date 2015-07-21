namespace Spitfire.Library.MySitecore.Pipelines.GetPageRendering
{
    using System.Linq;

    using Sitecore.Mvc.Pipelines.Response.GetPageRendering;

    /// <summary>
    /// Mvc.BuildPageDefinition pipeline processor to dynamically reference Cassette Bundles
    /// </summary>
    public class AddAssets : GetPageRenderingProcessor
    {
        public override void Process(GetPageRenderingArgs args)
        {
            // Only run in "normal" page mode, otherwise we assume renderings are always executed.
            if (!Sitecore.Context.PageMode.IsNormal)
            {
                return;
            }

            // Loop through all the renderings which are cacheable and might not have had their code executed
            foreach (var rendering in args.PageContext.PageDefinition.Renderings.Where(rendering => rendering.Caching.Cacheable))
            {
                MyContext.AssetRequirementService.AddFromRenderingCache(rendering.RenderingItem.ID);
            }
        }
    }
}