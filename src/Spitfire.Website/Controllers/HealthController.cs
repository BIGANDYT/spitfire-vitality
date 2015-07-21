namespace Spitfire.Website.Controllers
{
    using System.Web.Http;

    using Library.Models.Health;

    using Spitfire.Library.Services;

    /// <summary>
    /// Health ApiController
    /// </summary>
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