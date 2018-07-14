using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 股票交易实体
    /// </summary>
    public class StockTradeModel
    {
        /// <summary>
        /// 登录用户
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 股票代码
        /// </summary>
        public string StockID { get; set; }
        /// <summary>
        /// 股票名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 股票交易价格
        /// </summary>
        public double TradePrice { get; set; }
        /// <summary>
        /// 股票交易数量（单位为股）
        /// </summary>
        public int TradeCount { get; set; }
        /// <summary>
        /// 日盈利额
        /// </summary>
        public double DayEarn { get; set; }
        /// <summary>
        /// 总盈利额
        /// </summary>
        public double TotalEarn { get; set; }
    }
}
