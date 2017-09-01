using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XJBC.BLL;
using XJBC.Model;
using XJBC.Utility;

namespace XJBC.Web
{
    public partial class List : System.Web.UI.Page
    {
        public string chineseName;
        public string _nav;
        UsersBll bll = new UsersBll();
        Users model = new Users();
        public List<Articles> articlesList = new List<Articles>();
        ArticlesBll articlesBll = new ArticlesBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("Index.html");
            }
            model.Name = Session["Name"].ToString();
            chineseName = bll.GetChineseName(model.Name);
            GetArticlesList();
        }

        private void GetArticlesList()
        {
            int pageSize = int.Parse(string.IsNullOrEmpty(Request.QueryString["pagesize"]) ? "999" : Request.QueryString["pagesize"]);
            int pageIndex = int.Parse(string.IsNullOrEmpty(Request.QueryString["pageindex"]) ? "1" : Request.QueryString["pageindex"]);
            int totalCount = 0;
            int pageCount = 0;
            articlesList = articlesBll.GetArticlesList(pageIndex, pageSize, out totalCount, out pageCount);
            //_nav = PageHelper.strPage(totalCount, pageSize, pageCount, pageIndex, "List.aspx?pagesize=999&pageindex=");
        }
    }
}