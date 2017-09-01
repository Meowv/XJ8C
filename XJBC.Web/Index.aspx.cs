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
    public partial class Index : System.Web.UI.Page
    {
        public string _nav;
        public List<Articles> articlesList = new List<Articles>();
        ArticlesBll articlesBll = new ArticlesBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = int.Parse(string.IsNullOrEmpty(Request.QueryString["pagesize"]) ? "999" : Request.QueryString["pagesize"]);
            int pageIndex = int.Parse(string.IsNullOrEmpty(Request.QueryString["pageindex"]) ? "1" : Request.QueryString["pageindex"]);
            int totalCount = 0;
            int pageCount = 0;
            articlesList = articlesBll.GetArticlesList(pageIndex, pageSize, out totalCount, out pageCount);
            //_nav = PageHelper.strPage(totalCount, pageSize, pageCount, pageIndex, "Index.html?pagesize=999&pageindex=");
        }
    }
}