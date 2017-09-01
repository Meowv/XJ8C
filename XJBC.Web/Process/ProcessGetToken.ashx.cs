using Newtonsoft.Json;
using Qiniu.Conf;
using Qiniu.RS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XJBC.Web.Process
{
    public class Token
    {
        public string uptoken = "";
    }

    public class ProcessGetToken : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Config.ACCESS_KEY = "ykCoFVkO-NJMDHB_JFyHgAs9qb0PyDqe23KqQ9j-";
            Config.SECRET_KEY = "uqjMhYAOkERMawcRIh7d7QDubZ2QwKo3eOWXDhxO";
            string bucket = "xj8c";
            var policy = new PutPolicy(bucket, 3600);
            string upToken = policy.Token();
            Token token = new Token();
            token.uptoken = upToken;
            Console.WriteLine(JsonConvert.SerializeObject(token));
            upToken = JsonConvert.SerializeObject(token);
            context.Response.ContentType = "text/plain";
            context.Response.Write(upToken);
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