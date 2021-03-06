﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace XJBC.Utility
{
    public static class MD5Helper
    {
        #region MD5
        // 计算字符串的MD5值
        public static string GetMD5String(string msg)
        {
            StringBuilder sb = new StringBuilder();
            //1. 创建一个MD5对象
            using (MD5 md5 = MD5.Create())
            {
                // 1.1把字符串转换成byte[]
                byte[] buffers = System.Text.Encoding.UTF8.GetBytes(msg);
                // 2. 进行计算,md5计算完毕后，返回的也是一个byte[]
                byte[] bytes = md5.ComputeHash(buffers);
                md5.Clear();//释放资源，清除内存
                // 3. 把bytes中的每个字节转换成一个16进制表示的字符串，并返回
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}
