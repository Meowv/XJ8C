using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XJBC.DAL;
using XJBC.Model;

namespace XJBC.BLL
{
    public class UsersBll
    {
        UsersDal dal = new UsersDal();

        /// <summary>
        /// int Login(string uid, string pwd)
        /// </summary>
        /// <param name="uid">string uid</param>
        /// <param name="pwd">string pwd</param>
        /// <returns>dal.Login(uid, pwd)</returns>
        public int Login(string uid, string pwd)
        {
            return dal.Login(uid, pwd);
        }

        /// <summary>
        /// int UpdatePwd(Users model)
        /// </summary>
        /// <param name="model">Users model</param>
        /// <returns>dal.UpdatePwd(model)</returns>
        public int UpdatePwd(Users model)
        {
            return dal.UpdatePwd(model);
        }

        /// <summary>
        /// string GetOldPassword(string name)
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>dal.GetOldPassword(name)</returns>
        public string GetOldPassword(string name)
        {
            return dal.GetOldPassword(name);
        }

        /// <summary>
        /// string GetChineseName(string name)
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>dal.GetChineseName(name)</returns>
        public string GetChineseName(string name)
        {
            return dal.GetChineseName(name);
        }
    }
}
