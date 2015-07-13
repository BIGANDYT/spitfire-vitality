namespace Spitfire.Website
{
    using System.Web.Http;
    using Sitecore.Pipelines;

    public class SpitfireWebApiHandler
    {
        public void Process(PipelineArgs args)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}