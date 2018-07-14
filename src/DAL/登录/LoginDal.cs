using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class LoginDal:SqlserverDal
    {    
        /// <summary>
        /// 判断用户名、密码是否正确
        /// </summary>
        /// <param name="userName">登录用户名</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        public DataTable SelectUser(string userName, string password)
        {          
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM UserInfo where Number='" + userName + "' and Passwd='" + password + "'";
            this.Query(sql, dt);
            return dt;
        }
        /// <summary>
        /// 将新注册的用户信息插入数据库中
        /// </summary>
        /// <param name="userInfo">用户信息实体</param>
        public void InsertUser(UserInfo userInfo)
        {
            DataTable da = new DataTable();
            string sql = "INSERT INTO UserInfo VALUES('"+userInfo.UserName+"','"+userInfo.Password+"',"+userInfo.TotalAssets+","+userInfo.AvailableFund+",'"+userInfo.Address+"','"+userInfo.Phone+"')";
            this.Insert(sql);
        }
        /// <summary>
        /// 查询所有已经注册的用户
        /// </summary>
        /// <returns>返回所有注册用户信息</returns>
        public DataTable GetAllUserInfo()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM UserInfo";
            this.Query(sql, dt);
            return dt;
        }
    }
}
