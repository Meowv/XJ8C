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
    public partial class Article : System.Web.UI.Page
    {
        public Articles model = new Articles();
        ArticlesBll bll = new ArticlesBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"].ToString());
                model = bll.SelectById(id);
            }
            else
            {
                Response.Redirect("Index.html");
            }
        }

        public string Substr(string str)
        {
            str = str.Replace("\r", "").Replace("\n", "");
            string[] s = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", ".",  };
            for (int i = 0; i < s.Length; i++)
            {
                str = str.Replace(s[i], "");
            }
            if (str.Length > 120)
            {
                str = str.Substring(0, 120);
            }
            return str;
        }
    }
}