namespace Spitfire.Website.Handlers
{
    using System.Web;
    using System.Web.SessionState;

    using Sitecore.Security.Authentication;
    using Sitecore.Web;

    public class Logout : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            AuthenticationManager.Logout();
            WebUtil.Redirect("/");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}