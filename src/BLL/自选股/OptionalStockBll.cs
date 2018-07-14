using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using DAL;

namespace BLL
{
    public class OptionalStockBll
    {
        OptionalStockDal optionalDal = new OptionalStockDal();
        /// <summary>
        /// 添加自选股
        /// </summary>
        /// <param name="stockId"></param>
        public void AddOptionalStock(string stockId)
        {
            optionalDal.AddUserOptionalStock(stockId);
        }
        /// <summary>
        /// 查询当前用户自选股
        /// </summary>
        /// <returns>返回自选股信息</returns>
        public DataTable GetUserOptionalStock()
        {
            DataTable dt = new DataTable();
            dt = optionalDal.GetUserOptionalStock();
            return dt;
        }   
        /// <summary>
        /// 删除自选股
        /// </summary>
        /// <param name="stockId"></param>
        public void DeleteOptionalStock(string stockId)
        {
            optionalDal.DeleteOptionalStock(stockId);
        }
    }
}
