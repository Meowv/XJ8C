using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XJBC.Model;

namespace XJBC.DAL
{
    public class ArticlesDal
    {
        Articles model = new Articles();

        /// <summary>
        /// int Insert(Articles model)
        /// </summary>
        /// <param name="model">Articles model</param>
        /// <returns>SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms)</returns>
        public int Insert(Articles model)
        {
            string sql = "insert into Articles(Title,ContentText,ContentHtml)values(@Title,@ContentText,@ContentHtml)";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@Title",SqlDbType.NVarChar,100){Value=model.Title},
                new SqlParameter("@ContentText",SqlDbType.Text){Value=model.ContentText},
                new SqlParameter("@ContentHtml",SqlDbType.Text){Value=model.ContentHtml}
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// int Delete(int id)
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms)</returns>
        public int Delete(int id)
        {
            string sql = "delete Articles where Id=@Id";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@Id",SqlDbType.Int){Value=id}
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// int Update(Articles model)
        /// </summary>
        /// <param name="model">Articles model</param>
        /// <returns>SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms)</returns>
        public int Update(Articles model)
        {
            string sql = "update Articles set Title=@Title,ContentText=@ContentText,ContentHtml=@ContentHtml where Id=@id";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@Title",SqlDbType.NVarChar,100){Value=model.Title},
                new SqlParameter("@ContentText",SqlDbType.Text){Value=model.ContentText},
                new SqlParameter("@ContentHtml",SqlDbType.Text){Value=model.ContentHtml},
                new SqlParameter("@id",SqlDbType.Int){Value=model.Id}
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// Articles SelectById(int id)
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>model</returns>
        public Articles SelectById(int id)
        {
            string sql = "select * from Articles where Id=@Id";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@Id",SqlDbType.Int){Value=id}
            };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, pms);
            if (dt.Rows.Count > 0)
            {
                model = GetRows(dt.Rows[0]);
            }
            return model;
        }

        /// <summary>
        /// List<Articles> GetArticlesList
        /// (int currentIndex, int pageSize, out int totalCount, out int pageCount)
        /// </summary>
        /// <param name="currentIndex">int currentIndex</param>
        /// <param name="pageSize">int pageSize</param>
        /// <param name="totalCount">out int totalCount</param>
        /// <param name="pageCount">out int pageCount</param>
        /// <returns>articlesList</returns>
        public List<Articles> GetArticlesList(int currentIndex, int pageSize, out int totalCount, out int pageCount)
        {
            List<Articles> articlesList = new List<Articles>();
            SqlParameter[] pms = new SqlParameter[] 
           {
               new SqlParameter("@currentIndex",SqlDbType.Int){Value=currentIndex},
               new SqlParameter("@pageSize",SqlDbType.Int){Value=pageSize},
               new SqlParameter("@totalCount",SqlDbType.Int)
           };
            pms[2].Direction = ParameterDirection.Output;
            DataTable dt = SqlHelper.ExecuteDataTable("proc_GetArticles", CommandType.StoredProcedure, pms);
            totalCount = Convert.ToInt32(pms[2].Value.ToString());
            pageCount = totalCount % pageSize == 0 ? totalCount / pageSize : (totalCount / pageSize + 1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    articlesList.Add(GetRows(row));
                }
            }
            return articlesList;
        }

        /// <summary>
        /// Articles GetRows(DataRow dataRow)
        /// </summary>
        /// <param name="dataRow">DataRow dataRow</param>
        /// <returns>model</returns>
        private Articles GetRows(DataRow dataRow)
        {
            if (dataRow == null)
            {
                return null;
            }
            else
            {
                Articles model = new Articles();
                model.Id = Convert.ToInt32(dataRow["Id"].ToString());
                model.Title = dataRow["Title"].ToString();
                model.ContentText = dataRow["ContentText"].ToString();
                model.ContentHtml = dataRow["ContentHtml"].ToString();
                return model;
            }
        }
    }
}
