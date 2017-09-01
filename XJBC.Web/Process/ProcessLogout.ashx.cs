using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace XJBC.Web.Process
{
    public class ProcessLogout : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Session.RemoveAll();
            context.Response.Redirect("../index.html");
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