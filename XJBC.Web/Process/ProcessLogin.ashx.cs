using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using XJBC.BLL;

namespace XJBC.Web.Process
{
    public class ProcessLogin : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Request.Form["username"] != null)
            {
                string username = context.Request.Form["username"];
                string password = context.Request.Form["password"];
                UsersBll bll = new UsersBll();
                if (username != "" && password != "")
                {
                    int i = bll.Login(username, password);
                    if (i > 0)
                    {
                        context.Session["Name"] = username;
                        context.Response.Redirect("../list.html");
                    }
                    else
                    {
                        context.Response.Write("<script>alert('Error');window.location='../index.html';</script>");
                    }
                }
            }
            else
            {
                context.Response.Redirect("../index.html");
            }
            
            context.Response.End();
            
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