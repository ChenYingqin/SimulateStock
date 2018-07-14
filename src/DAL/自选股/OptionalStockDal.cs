using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAL
{
    public class OptionalStockDal:SqlserverDal
    {
        /// <summary>
        /// 当前用户添加自选股
        /// </summary>
        /// <param name="stockId">股票代码</param>
        public void AddUserOptionalStock(string stockId)
        {
            string userId = LoginInfo.loginInfo.UserName;
            string sql = "INSERT INTO OptionalStock VALUES('" + userId + "','" + stockId + "')";
            this.Insert(sql);
        }
        /// <summary>
        /// 获取当前用户的自选股
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserOptionalStock()
        {
            DataTable dt = new DataTable();
            string userId = LoginInfo.loginInfo.UserName;
            string sql = "SELECT * FROM OptionalStock WHERE Number='" + userId + "'";
            this.Query(sql, dt);
            return dt;

        }
        /// <summary>
        /// 删除自选股
        /// </summary>
        /// <param name="stockId"></param>
        public void DeleteOptionalStock(string stockId)
        {
            string userId = LoginInfo.loginInfo.UserName;
            string sql = "DELETE FROM OptionalStock WHERE Number='" + userId + "' AND StockCode='" + stockId + "'";
            this.Delete(sql);
        }
    }
}
