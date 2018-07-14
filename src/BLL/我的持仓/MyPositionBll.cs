using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    /// <summary>
    /// 当前用户持仓模块
    /// </summary>
    public class MyPositionBll
    {
        MyPositionDal myPosition = new MyPositionDal();
        /// <summary>
        /// 获取当前用户持仓信息
        /// </summary>
        /// <returns>返回当前用户持仓信息</returns>
        public DataTable GetUserPosition()
        {
            DataTable dt = myPosition.GetUserPositon();
            if (dt == null)
                return null;
            DataTable dtPositon = new DataTable();
            dtPositon.Columns.Add("number", typeof(int));
            dtPositon.Columns.Add("stockId", typeof(string));
            dtPositon.Columns.Add("stockName", typeof(string));
            dtPositon.Columns.Add("growthRate", typeof(string));
            dtPositon.Columns.Add("totalEarn", typeof(string));
            dtPositon.Columns.Add("buyPrice", typeof(string));
            dtPositon.Columns.Add("buyCount", typeof(string));
            for(int i=0;i<dt.Rows.Count;i++)
            {
                NowStockDataModel model = new NowStockDataModel();
                NowStockDataDal nowStockDal=new NowStockDataDal();
                string stockId = dt.Rows[i][1].ToString().Trim();
                model = nowStockDal.GetNowStockData(stockId);
                double growthRate = (double.Parse(model.CurrentPrice) - double.Parse(dt.Rows[i][3].ToString())) / double.Parse(dt.Rows[i][3].ToString())*100;
                double totalEarn = (double.Parse(model.CurrentPrice) - double.Parse(dt.Rows[i][3].ToString())) * int.Parse(dt.Rows[i][4].ToString());
                string growthRateStr;
                if(growthRate>0)
                {
                    growthRateStr="+"+growthRate.ToString("0.00")+"%";
                }
                else
                {
                    growthRateStr=growthRate.ToString("0.00")+"%";
                }
                DataRow row = dtPositon.NewRow();
                row[0] = i + 1;
                row[1]=stockId;
                row[2]=dt.Rows[i][2].ToString().Trim();                
                row[3]=growthRateStr;
                row[4]=totalEarn.ToString("0.00");
                row[5]=dt.Rows[i][3].ToString().Trim();
                row[6]=dt.Rows[i][4].ToString().Trim();
                dtPositon.Rows.Add(row);                
            }
            return dtPositon;
        }
        /// <summary>
        /// 更新当前用户的可用金额
        /// </summary>
        /// <param name="available">用于当前可用金额</param>
        public void UpdateAvailableFund(string available)
        {
            myPosition.UpdateAvailableFund(available);            
            LoginInfo.loginInfo.AvailableFund = double.Parse(available);
        }
    }
}
