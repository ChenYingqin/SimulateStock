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
    public class StockTradeBll:BaseBll
    {
        StocklTradeDal stockTradeDal = new StocklTradeDal();
        NowStockDataDal nowStockDataDal = new NowStockDataDal();
        /// <summary>
        /// 买入股票
        /// </summary>
        /// <param name="StockId">股票代码</param>
        /// <param name="BuyCount">买入股票数量</param>
        /// <returns>放回true表示买入成功，返回false表示股票买入失败</returns>
        public bool BuyStock(string StockId,int BuyCount)
        {
            bool IsStockIDValid=nowStockDataDal.CheckStockNumber(StockId);
            if (!IsStockIDValid)  //股票代码无效
                return false;
            StockTradeModel model = new StockTradeModel();
            StockTradeModel availableModel = new StockTradeModel();
            NowStockDataModel nowStockModel = new NowStockDataModel();
            nowStockModel = nowStockDataDal.GetNowStockData(StockId);
            if(nowStockModel!=null)
            {
                bool IsStockExist=false; //查看数据库中是否存在股票代码为StockId的股票
                DataTable dt = new DataTable();
                dt = stockTradeDal.SelectStocks(LoginInfo.loginInfo.UserName);
                int index = 0;
                if(dt.Rows.Count!=0) 
                {
                    for(index=0;index<dt.Rows.Count ;index++)
                    {
                        if(dt.Rows[index][1].ToString().Trim()==StockId)
                        {
                            IsStockExist = true;
                            break;
                        }
                    }
                }
                model.UserID = LoginInfo.loginInfo.UserName;
                model.StockID = StockId;
                model.StockName = nowStockModel.StockName;
                availableModel.UserID = LoginInfo.loginInfo.UserName;
                availableModel.StockID = StockId;
                availableModel.StockName = nowStockModel.StockName;
                if(IsStockExist)
                {                  
                    double lastBuyPrice = double.Parse(dt.Rows[index][3].ToString());
                    int lastBuyCount = int.Parse(dt.Rows[index][4].ToString());
                    double nowBuyPrice = double.Parse(nowStockModel.CurrentPrice);
                    int nowBuyCount = BuyCount;

                    availableModel.TradePrice = nowBuyPrice;
                    availableModel.TradeCount = BuyCount;
                    //买入的价格应该上上次的买入价格与现在买入股票价格的加权平均价格
                    nowBuyPrice = (lastBuyPrice * lastBuyCount + nowBuyPrice * nowBuyCount)/(nowBuyCount+lastBuyCount);
                    nowBuyCount = lastBuyCount+nowBuyCount;

                    model.TradePrice = nowBuyPrice;
                    model.TradeCount = nowBuyCount;
                    stockTradeDal.AfterBuyAvailableFund(availableModel);//更新可用资金
                    stockTradeDal.BuyStock(model, "");//将买入股票的数据写入数据库（UPDATE)

                }
                else
                {                 
                    model.TradePrice = double.Parse(nowStockModel.CurrentPrice);
                    model.TradeCount = BuyCount;

                    stockTradeDal.AfterBuyAvailableFund(model);//更新可用资金
                    stockTradeDal.BuyStock(model);  //将买入股票的数据写入数据库（INSERT）
                }              
            }
            else
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取股票的实时数据
        /// </summary>
        /// <param name="stockId">股票代码</param>
        /// <returns>返回股票数据</returns>
        public NowStockDataModel GetNowStockData(string stockId)
        {
            NowStockDataModel nowStockModel = new NowStockDataModel();
            nowStockModel = nowStockDataDal.GetNowStockData(stockId);
            return nowStockModel;
        }
        /// <summary>
        /// 检测股票代码是否有效
        /// </summary>
        /// <param name="stockId">股票代码</param>
        /// <returns>返回true表示股票代码有效</returns>
        public bool StockIdValid(string stockId)
        {
            bool IsStockIDValid = nowStockDataDal.CheckStockNumber(stockId);
            NowStockDataModel nowStockModel = new NowStockDataModel();
            nowStockModel = nowStockDataDal.GetNowStockData(stockId);
            if (nowStockModel == null)
                IsStockIDValid = false;
            return IsStockIDValid;
        }
        /// <summary>
        /// 获取当前股票的买入或卖出价格
        /// </summary>
        /// <param name="stockId">股票代码</param>
        /// <returns>返回股票的买入或卖出价格</returns>
        public double GetCurrentStockPrice(string stockId)
        {
            double currentPrice=0.0;
            NowStockDataModel nowStockModel = new NowStockDataModel();
            nowStockModel = nowStockDataDal.GetNowStockData(stockId);
            if (nowStockModel!= null)
            {
                currentPrice = double.Parse(nowStockModel.CurrentPrice);
            }
            return currentPrice ;
        }
        /// <summary>
        /// 获取当前用户可用资金
        /// </summary>
        /// <returns>返回可用资金</returns>
        public double GetUserInvaliableFund()
        {
            double invaliableFund;
            DataTable dt = new DataTable();
            dt = stockTradeDal.QueryUserInfo();
            invaliableFund = double.Parse(dt.Rows[0][3].ToString());
            return invaliableFund;
        }
        /// <summary>
        /// 获取用户某支股票的可用数量
        /// </summary>
        /// <param name="UserID">用户名</param>
        /// <param name="StockId">股票代码</param>
        /// <returns></returns>
        public int SelectStockCount(string StockId)
        {
            DataTable dt = new DataTable();
            int count=0;
            string UserID = LoginInfo.loginInfo.UserName;
            dt=stockTradeDal.SelectStockCount(UserID, StockId);
            if(dt!=null)
            {
                count = int.Parse(dt.Rows[0][4].ToString());
            }
            return count;
        }
        /// <summary>
        /// 查询当前用户持有的所有股票
        /// </summary>
        /// <returns>返回持有的股票信息</returns>
        public DataTable GetUserStockInfo()
        {
            DataTable dt = new DataTable();
            dt = stockTradeDal.SelectStocks(LoginInfo.loginInfo.UserName);//获取用户持有的所有股票
            return dt;
        }
        /// <summary>
        /// 卖出股票
        /// </summary>
        /// <param name="index">股票在datatable中的位置</param>
        /// <param name="count">卖出股票后剩余的数量</param>
        public int SellStock(int index,int count)
        {
            NowStockDataModel nowStockModel = new NowStockDataModel();
            
            DataTable dt = new DataTable();
            dt = stockTradeDal.SelectStocks(LoginInfo.loginInfo.UserName);//获取用户持有的所有股票
            if (index > dt.Rows.Count-1||index==-1)
                return -1;
            string stockId=dt.Rows[index][1].ToString().Trim();

            nowStockModel = nowStockDataDal.GetNowStockData(stockId);
            StockTradeModel model = new StockTradeModel();
            StockTradeModel availableModel = new StockTradeModel();
            availableModel.UserID = LoginInfo.loginInfo.UserName;
            availableModel.StockID = stockId;
            availableModel.TradePrice = double.Parse(nowStockModel.CurrentPrice);
            availableModel.TradeCount = count;

            model.UserID = LoginInfo.loginInfo.UserName;
            model.StockID = stockId;
            model.TradePrice = double.Parse(nowStockModel.CurrentPrice);
            model.TradeCount =this.SelectStockCount(stockId)-count;
            
            stockTradeDal.AfterSellAvailableFund(availableModel);
            return stockTradeDal.SellStock(model);
        }
        /// <summary>
        /// 当用户的某支股票持有量为0时，删除该股票在数据库中的记录
        /// </summary>
        /// <param name="stockId">股票代码</param>
        public void DeleteStockInfo(string stockId)
        {
            stockTradeDal.DeleteStockInfo(stockId);
        }
        /// <summary>
        /// 更新当前用户资产状况
        /// </summary>
        public void  UpdateUserInfo()
        {
            DataTable dt = new DataTable();
            dt = stockTradeDal.GetUserAssetStatusNow();
            LoginInfo.loginInfo.TotalAssets = double.Parse(dt.Rows[0][2].ToString());
            LoginInfo.loginInfo.AvailableFund = double.Parse(dt.Rows[0][3].ToString());           
        }
    }
}
