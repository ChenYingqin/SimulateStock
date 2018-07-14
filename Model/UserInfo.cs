using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 总资产
        /// </summary>
        public double TotalAssets { get; set; }
        /// <summary>
        /// 可用资金
        /// </summary>
        public double AvailableFund { get; set; }
        /// <summary>
        /// 用户地址信息
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 用户电话号码
        /// </summary>
        public string Phone { get; set; }
    }
    public class LoginInfo
    {
        /// <summary>
        /// 登录用户信息
        /// </summary>
        static public UserInfo loginInfo = new UserInfo();
    }
}
