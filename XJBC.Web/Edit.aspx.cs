using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XJBC.BLL;
using XJBC.Model;

namespace XJBC.Web
{
    public partial class Edit : System.Web.UI.Page
    {
        public string chineseName;
        UsersBll bll = new UsersBll();
        Users model = new Users();
        Articles articlesModel = new Articles();
        ArticlesBll articlesBll = new ArticlesBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("Index.html");
            }
            model.Name = Session["Name"].ToString();
            chineseName = bll.GetChineseName(model.Name);

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    btnInsert.Text = "修改";
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    articlesModel = articlesBll.SelectById(id);
                    Title.Text = articlesModel.Title;
                    Editor.Value = Server.HtmlDecode(articlesModel.ContentHtml);
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "添加")
            {
                GetArticlesInfo(articlesModel);
                if (Title.Text != "" && Request.Form["Editor"].ToString() != "")
                {
                    int i = articlesBll.Insert(articlesModel);
                    if (i > 0)
                    {
                        Response.Write("<script>alert('添加成功!');window.location='List.html';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('鬼知道出了什么错误!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('请填写完整!')</script>");
                }
            }
            else
            {
                GetArticlesInfo(articlesModel);
                articlesModel.Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (Title.Text != "" && Request.Form["Editor"].ToString() != "")
                {
                    int i = articlesBll.Update(articlesModel);
                    if (i > 0)
                    {
                        Response.Write("<script>alert('修改成功!');window.location='List.html';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('鬼知道出了什么错误!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('请填写完整!')</script>");
                }
            }
        }

        private void GetArticlesInfo(Articles articlesModel)
        {
            string title = Title.Text.Trim();
            string html = Server.HtmlEncode(Request.Form["Editor"].ToString());
            string text = Regex.Replace(Request.Form["Editor"].ToString(), @"<script(\s[^>]*?)?>[\s\S]*?</script>", "", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"<style>[\s\S]*?</style>", "", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            text = text.Replace("&nbsp;", "");
            articlesModel.Title = title;
            articlesModel.ContentText = text;
            articlesModel.ContentHtml = html;
        }
    }
}