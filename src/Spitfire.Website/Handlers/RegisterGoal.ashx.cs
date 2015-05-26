﻿using System.Web;

namespace Spitfire.Handlers
{
    using System.Web.SessionState;

    using Spitfire.Helpers;
    using Sitecore.Data;
    using Sitecore.Diagnostics;

    public class RegisterGoal : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            ID id;
            if (!ID.TryParse(context.Request.QueryString["goalId"], out id))
            {
                Log.Warn("Cannot parse goal ID", this);
                return;
            }

            if (!AnalyticsHelper.TriggerGoal(id))
            {
                Log.Warn("Goal triggering failed", this);
                return;
            }

            context.Response.Write("OK");
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