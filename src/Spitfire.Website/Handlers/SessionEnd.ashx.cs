namespace Spitfire.Website.Handlers
{
    using System.Web;
    using System.Web.SessionState;

    public class SessionEnd : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Session.Abandon();
        }
    }
}