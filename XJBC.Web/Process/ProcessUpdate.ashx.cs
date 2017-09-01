using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using XJBC.BLL;
using XJBC.Model;

namespace XJBC.Web.Process
{
    public class ProcessUpdate : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Request.Form["oldPwd"] != null)
            {   UsersBll bll = new UsersBll();
                Users model = new Users();
                string oldPwd = context.Request.Form["oldPwd"];
                string newPwd1 = context.Request.Form["newPwd1"];
                string newPwd2 = context.Request.Form["newPwd2"];
                model.Name = context.Session["Name"].ToString();
                model.Password=newPwd2;
                if (oldPwd != "" && newPwd1 != "" && newPwd2 != "")
                {
                    if (newPwd1 == newPwd2)
                    {
                        if (XJBC.Utility.MD5Helper.GetMD5String(oldPwd) == bll.GetOldPassword(model.Name))
                        {
                            int i = bll.UpdatePwd(model);
                            if (i > 0)
                            {
                                context.Response.Write("<script>alert('恭喜你，密码修改成功！');window.location='../list.html';</script>");
                            }
                        }
                        else
                        {
                            context.Response.Write("<script>alert('旧密码错误！');window.location='../list.html';</script>");
                        }
                    }
                    else
                    {
                        context.Response.Write("<script>alert('两次密码不一致！');window.location='../list.html';</script>");
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