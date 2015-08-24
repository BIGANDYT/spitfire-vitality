using System.Web.Http;
using Spitfire.Framework.Health.Models;

namespace Spitfire.Framework.Health.Controllers
{
    /// <summary>
    /// Health ApiController
    /// </summary>
    public class HealthController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HealthResult Index()
        {
            var service = new HealthService();
            return service.GetHealthResult();
        }
    }
}