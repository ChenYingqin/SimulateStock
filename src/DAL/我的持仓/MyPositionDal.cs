using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 我的持仓模块
    /// </summary>
    public class MyPositionDal:SqlserverDal
    {
        /// <summary>
        /// 查询当前用户持有的股票
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserPositon()
        {
            DataTable dt = new DataTable();
            String userId=LoginInfo.loginInfo.UserName;
            string sql = "SELECT * FROM TradeRecode WHERE Number='" + userId + "'";
            this.Query(sql, dt);
            return dt;
        }
        /// <summary>
        /// 更新当前用户的可用金额
        /// </summary>
        /// <param name="totalAsset"></param>
        public void UpdateAvailableFund(string available)
        {
            string userID = LoginInfo.loginInfo.UserName;
            string sql = "UPDATE UserInfo SET AvailableFund='"+available+"' WHERE Number='" + userID + "'";
            this.Update(sql);
        }
    }
}
