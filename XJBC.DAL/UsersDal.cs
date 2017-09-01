using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XJBC.Model;
using XJBC.Utility;

namespace XJBC.DAL
{
    public class UsersDal
    {
        /// <summary>
        /// int Login(string uid, string pwd)
        /// </summary>
        /// <param name="uid">string uid</param>
        /// <param name="pwd">string pwd</param>
        /// <returns>return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms)</returns>
        public int Login(string uid, string pwd)
        {
            string sql = "select count(*) from Users where Name=@uid and Password=@pwd";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@uid",SqlDbType.VarChar,50){Value=uid},
                new SqlParameter("@pwd",SqlDbType.VarChar,50){Value=MD5Helper.GetMD5String(pwd)}
            };
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// int UpdatePwd(Users model)
        /// </summary>
        /// <param name="model">Users model</param>
        /// <returns>SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms)</returns>
        public int UpdatePwd(Users model)
        {
            string sql = "update Users set Password=@pwd where Name=@uid";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@pwd",MD5Helper.GetMD5String(model.Password)),
                new SqlParameter("@uid",model.Name)
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        /// <summary>
        /// string GetOldPassword(string name)
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>SqlHelper.ExecuteScalar(sql, CommandType.Text, pms).ToString()</returns>
        public string GetOldPassword(string name)
        {
            string sql = "select Password from Users where Name=@uid";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@uid",SqlDbType.NVarChar,50){Value=name}
            };
            return SqlHelper.ExecuteScalar(sql, CommandType.Text, pms).ToString();
        }

        /// <summary>
        /// string GetChineseName(string name)
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>SqlHelper.ExecuteScalar(sql, CommandType.Text, pms).ToString()</returns>
        public string GetChineseName(string name)
        {
            string sql = "select ChineseName from Users where Name=@uid";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@uid",SqlDbType.NVarChar,50){Value=name}
            };
            return SqlHelper.ExecuteScalar(sql, CommandType.Text, pms).ToString();
        }
    }
}
