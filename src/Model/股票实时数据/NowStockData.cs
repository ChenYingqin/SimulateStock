using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 股票实时数据实体
    /// </summary>
    public class NowStockDataModel
    {
        /// <summary>
        /// 股票代码
        /// </summary>
        public string StockId { get; set; }
        /// <summary>
        /// 股票名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 今日开盘价
        /// </summary>
        public string TodayOpenPrice { get; set; }
        /// <summary>
        /// 昨日收盘价
        /// </summary>
        public string YesterdayClosePrice { get; set; }
        /// <summary>
        /// 股票现在价格
        /// </summary>
        public string CurrentPrice { get; set; }
        /// <summary>
        /// 今日最高价
        /// </summary>
        public string HighestPrice { get; set; }
        /// <summary>
        /// 今日最低价
        /// </summary>
        public string LowestPrice { get; set; }
        /// <summary>
        /// 买一价格
        /// </summary>
        public string BuyOnePrice { get; set; }
        /// <summary>
        /// 买一数量
        /// </summary>
        public string BuyOneCount { get; set; }
        /// <summary>
        /// 买二价格
        /// </summary>
        public string BuyTwoPrice { get; set; }
        /// <summary>
        /// 买二数量
        /// </summary>
        public string BuyTwoCount { get; set; }
        /// <summary>
        /// 买三价格
        /// </summary>
        public string BuyThreePrice { get; set; }
        /// <summary>
        /// 买三数量
        /// </summary>
        public string BuyThreeCount { get; set; }
        /// <summary>
        /// 买四价格
        /// </summary>
        public string BuyFourPrice { get; set; }
        /// <summary>
        /// 买四数量
        /// </summary>
        public string BuyFourCount { get; set; }
        /// <summary>
        /// 买五价格
        /// </summary>
        public string BuyFivePrice { get; set; }
        /// <summary>
        /// 买五数量
        /// </summary>
        public string BuyFiveCount { get; set; }
        /// <summary>
        /// 卖一价格
        /// </summary>
        public string SellOnePrice { get; set; }
        /// <summary>
        /// 卖一数量
        /// </summary>
        public string SellOneCount { get; set; }
        /// <summary>
        /// 卖二价格
        /// </summary>
        public string SellTwoPrice { get; set; }
        /// <summary>
        /// 卖二数量
        /// </summary>
        public string SellTwoCount { get; set; }
        /// <summary>
        /// 卖三价格
        /// </summary>
        public string SellThreePrice { get; set; }
        /// <summary>
        /// 卖三数量
        /// </summary>
        public string SellThreeCount { get; set; }
        /// <summary>
        /// 卖四价格
        /// </summary>
        public string SellFourPrice { get; set; }
        /// <summary>
        /// 卖四数量
        /// </summary>
        public string SellFourCount { get; set; }
        /// <summary>
        /// 卖五价格
        /// </summary>
        public string SellFivePrice { get; set; }
        /// <summary>
        /// 卖五数量
        /// </summary>
        public string SellFiveCount { get; set; }
    }
}
