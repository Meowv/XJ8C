using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XJBC.DAL;
using XJBC.Model;

namespace XJBC.BLL
{
    public class ArticlesBll
    {
        ArticlesDal dal = new ArticlesDal();

        /// <summary>
        /// int Insert(Articles model)
        /// </summary>
        /// <param name="model">Articles model</param>
        /// <returns>dal.Insert(model)</returns>
        public int Insert(Articles model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// int Delete(int id)
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>dal.Delete(id)</returns>
        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// int Update(Articles model)
        /// </summary>
        /// <param name="model">Articles model</param>
        /// <returns>dal.Update(model)</returns>
        public int Update(Articles model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// Articles SelectById(int id)
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>dal.SelectById(id)</returns>
        public Articles SelectById(int id)
        {
            return dal.SelectById(id);
        }

        /// <summary>
        /// List<Articles> GetArticlesList
        /// (int currentIndex, int pageSize, out int totalCount, out int pageCount)
        /// </summary>
        /// <param name="currentIndex">int currentIndex</param>
        /// <param name="pageSize">int pageSize</param>
        /// <param name="totalCount">out int totalCount</param>
        /// <param name="pageCount">out int pageCount</param>
        /// <returns>dal.GetArticlesList(currentIndex, pageSize, out totalCount, out pageCount)</returns>
        public List<Articles> GetArticlesList(int currentIndex, int pageSize, out int totalCount, out int pageCount)
        {
            return dal.GetArticlesList(currentIndex, pageSize, out totalCount, out pageCount);
        }
    }
}
