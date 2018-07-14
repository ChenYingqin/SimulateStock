using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;


namespace BLL
{
    public class LoginBLL:BaseBll
    {
        private LoginDal loginDal = new LoginDal();
        DataTable da = new DataTable();
        public LoginBLL(string userName, string userPasswd)
        {
            da = loginDal.SelectUser(userName, userPasswd);
        }
        public LoginBLL()
        {

        }
        /// <summary>
        /// 判断用户名、密码是否正确
        /// </summary>
        /// <returns></returns>
        public bool IsUserRight()
        {                     
            if (da.Rows.Count == 0)
                return false;
            else
                return true;           
        }
        /// <summary>
        /// 返回用户信息
        /// </summary>
        /// <returns></returns>
        public DataTable  GetUserInfo()
        {
            return da;
        }
        /// <summary>
        /// 将新注册用户的信息插入数据库中
        /// </summary>
        /// <param name="userInfo"></param>
        public void InsertUserInfo(UserInfo userInfo)
        {
            loginDal.InsertUser(userInfo);
        }
        /// <summary>
        /// 查询所有注册用户信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUserInfo()
        {
            DataTable dt = new DataTable();
            dt = loginDal.GetAllUserInfo();
            return dt;
        }
    }
}
