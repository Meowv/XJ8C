using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XJBC.BLL;

namespace XJBC.Web.Process
{
    public class ProcessDelete : IHttpHandler
    {
        ArticlesBll bll = new ArticlesBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["id"] != null)
            {
                int id = int.Parse(context.Request.QueryString["id"]);
                bll.Delete(id);
                context.Response.Redirect("../List.html");
            }
            else
            {
                context.Response.Redirect("../Index.html");
            }
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