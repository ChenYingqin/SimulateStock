using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAL
{
    public class StocklTradeDal:SqlserverDal
    {
        /// <summary>
        /// 买入股票
        /// </summary>
        /// <param name="model">股票交易实体</param>
        public void BuyStock(StockTradeModel model)
        {
            string sql = "INSERT INTO TradeRecode VALUES('" + model.UserID + "','" + model.StockID + "','" + model.StockName + "','" + model.TradePrice + "','" + model.TradeCount + "','"+DateTime.Now.ToString()+"')";
            this.Insert(sql);
           
        }
        /// <summary>
        /// 买入股票后，更新当前用户可用资金
        /// </summary>
        /// <param name="model"></param>
        public void AfterBuyAvailableFund(StockTradeModel model)
        {
            double availableFund = LoginInfo.loginInfo.AvailableFund - model.TradeCount*model.TradePrice;
            string sql = "UPDATE UserInfo SET AvailableFund="+availableFund+" WHERE Number='"+model.UserID+"'";
            this.Update(sql);
        }
        /// <summary>
        /// 卖出股票后，更新当前用户可用资金
        /// </summary>
        /// <param name="model"></param>
        public void AfterSellAvailableFund(StockTradeModel model)
        {
            double availableFund = LoginInfo.loginInfo.AvailableFund + model.TradeCount * model.TradePrice;
            string sql = "UPDATE UserInfo SET AvailableFund=" + availableFund + " WHERE Number='" + model.UserID + "'";
            this.Update(sql);
        }
        /// <summary>
        /// 增持股票
        /// </summary>
        /// <param name="model"></param>
        /// <param name="str"></param>
        public void BuyStock(StockTradeModel model,string str)
        {
            string sql = "UPDATE TradeRecode SET BuyPrice=" + model.TradePrice + ",BuyCount=" + model.TradeCount + ",BuyDate='"+DateTime.Now.ToString()+"' WHERE Number='" + model.UserID + "' AND StockCode='" + model.StockID + "'";
            this.Insert(sql);
        }
        /// <summary>
        /// 卖出股票
        /// </summary>
        /// <param name="model">股票交易实体</param>
        public int SellStock(StockTradeModel model)
        {           
            string sql = "UPDATE TradeRecode SET BuyCount="+model.TradeCount+" WHERE Number='"+model.UserID+"' AND StockCode='"+model.StockID+"'";
            return  this.Update(sql);
        }
        /// <summary>
        /// 查询某支股票持有数量
        /// </summary>
        /// <param name="UserId">股票持有人</param>
        /// <param name="StockId">股票代码</param>
        /// <returns></returns>
        public DataTable SelectStockCount(string UserId,string StockId)
        {
            string sql = "SELECT * FROM TradeRecode WHERE Number='" + UserId + "' AND StockCode='" + StockId + "'";
            DataTable dt=new DataTable();
            this.Query(sql, dt);
            return dt;
        }
        /// <summary>
        /// 查询用户持有的股票
        /// </summary>
        /// <param name="UserId">用户账号名</param>
        /// <returns>返回用户持有的股票</returns>
        public DataTable SelectStocks(string UserId)
        {
            string sql="SELECT * FROM TradeRecode WHERE Number='"+UserId+"'";
            DataTable dt = new DataTable();
            this.Query(sql, dt);
            return dt;
        }
        /// <summary>
        /// 查询当前用户个人信息
        /// </summary>
        /// <returns>返回当前用户个人信息</returns>
        public DataTable QueryUserInfo()
        {
            DataTable dt = new DataTable();
            string userId=LoginInfo.loginInfo.UserName;
            string sql = "SELECT * FROM UserInfo WHERE Number='" + userId + "'";
            this.Query(sql, dt);
            return dt;
        }
        /// <summary>
        /// 查询当前用户的资产状况
        /// </summary>
        /// <returns>返回当前用户个人信息</returns>
        public DataTable GetUserAssetStatusNow()
        {
            UserInfo userInfo = new UserInfo();
            DataTable dt = new DataTable();
            string userId=LoginInfo.loginInfo.UserName;
            string sql="SELECT * From UserInfo WHERE Number='"+userId+"'";
            this.Query(sql, dt);
            return dt;
        }
        /// <summary>
        /// 当用户完全卖出某支股票时，删除股票记录
        /// </summary>
        /// <param name="StockId">股票代码</param>
        public void DeleteStockInfo(string StockId)
        {
            string userId = LoginInfo.loginInfo.UserName;
            string sql = "DELETE FROM TradeRecode WHERE Number='" + userId + "' AND StockCode='" + StockId + "'";
            this.Delete(sql);
        }
    }
}
