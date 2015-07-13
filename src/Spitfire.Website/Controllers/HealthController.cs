namespace Spitfire.Website.Controllers
{
    using System.Web.Http;

    using Spitfire.Library.Models.Health;
    using Spitfire.Library.Service;

    public class HealthController : ApiController
    {
        [HttpGet]
        public HealthResult Index()
        {
            var service = new HealthService();
            return service.GetHealthResult();
        }
    }
}