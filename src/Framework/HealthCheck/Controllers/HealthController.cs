namespace Spitfire.Modules.HealthCheck.Controllers
{
    using System.Web.Http;

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