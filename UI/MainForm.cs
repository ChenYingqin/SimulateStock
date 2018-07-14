using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;
using DAL;

namespace UI
{
    public partial class MainForm : Form
    {
        StockTradeBll stockTradeBll = new StockTradeBll();
        OptionalStockBll optionalBll = new OptionalStockBll();
        public MainForm()
        {
            InitializeComponent();
            UpdateUserAssetStatus();
            MyPosition();
        }

        /// <summary>
        /// 买入股票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if(textBoxBuyCount.Text==""||textBoxStockId.Text=="")
               return;
            stockTradeBll.UpdateUserInfo();
            string stockId;
            int buyCount;                
            stockId = textBoxStockId.Text;
            buyCount = int.Parse(textBoxBuyCount.Text);
            bool IsValid = stockTradeBll.StockIdValid(stockId);
            double invaliable = stockTradeBll.GetUserInvaliableFund();
            double currentPrice = stockTradeBll.GetCurrentStockPrice(stockId);
            int maxInvaliable = ((int)(invaliable / currentPrice));
            int buyStockCount = int.Parse(textBoxBuyCount.Text);

            if(IsValid&&buyStockCount<maxInvaliable)
            {
                bool IsBuySuccess=stockTradeBll.BuyStock(stockId, buyCount);   
                if(IsBuySuccess)  
                {
                    string available = (LoginInfo.loginInfo.AvailableFund - currentPrice * buyStockCount).ToString();
                    MyPositionBll myPositionBll = new MyPositionBll();
                    myPositionBll.UpdateAvailableFund(available);//卖出股票后，更新总资产、可用资金
                    labMaxBuyCount.Text = (maxInvaliable - buyStockCount).ToString();                    
                    MessageBox.Show("股票买入成功","信息提示",MessageBoxButtons.OK);
                    UpdateUserAssetStatus();
                    MyPosition();
                 }
                else
                {
                    MessageBox.Show("股票买入失败", "信息提示", MessageBoxButtons.OK);
                 }
            }  
            else
            {
                MessageBox.Show("股票买入失败", "信息提示", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// 焦点离开股票输入框发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxStockId_Leave(object sender, EventArgs e)
        {
            string stockId = textBoxStockId.Text;
            bool IsValid = stockTradeBll.StockIdValid(stockId);
            if(!IsValid)
            {
                textBoxStockId.Text = "";
                labStockValid.Visible = true;
            }
            else
            {
                labStockValid.Visible = false;
                double currentPrice = stockTradeBll.GetCurrentStockPrice(stockId);
                textBoxBuyPrice.Text = currentPrice.ToString();
                double invaliable = stockTradeBll.GetUserInvaliableFund(); 
                labMaxBuyCount.Text = ((int)(invaliable / currentPrice)).ToString();

                NowStockDataModel model = new NowStockDataModel();
                model = stockTradeBll.GetNowStockData(stockId);
                labStockName.Text = model.StockName;
                labClosePrice.Text = double.Parse(model.YesterdayClosePrice).ToString("0.00");
                labOpenPrice.Text = double.Parse(model.TodayOpenPrice).ToString("0.00");
                labHighestPrice.Text =double.Parse(model.HighestPrice).ToString("0.00");
                labLowestPrice.Text = double.Parse(model.LowestPrice).ToString("0.00");
                labCurrentPrice.Text = double.Parse(model.CurrentPrice).ToString("0.00");
                labBuyOnePrice.Text = double.Parse(model.BuyOnePrice).ToString("0.00");
                labBuyOneCount.Text = model.BuyOneCount;
                labBuyTwoPrice.Text = double.Parse(model.BuyTwoPrice).ToString("0.00");
                labBuyTwoCount.Text = model.BuyTwoCount;
                labBuyThreePrice.Text = double.Parse(model.BuyThreePrice).ToString("0.00");
                labBuyThreeCount.Text = model.BuyThreeCount;
                labBuyFourPrice.Text = double.Parse(model.BuyFourPrice).ToString("0.00");
                labBuyFourCount.Text = model.BuyFourCount;
                labBuyFivePrice.Text = double.Parse(model.BuyFivePrice).ToString("0.00");
                labBuyFiveCount.Text = model.BuyFiveCount;
                labSellOnePrice.Text = double.Parse(model.SellOnePrice).ToString("0.00");
                labSellOneCount.Text = model.SellOneCount;
                labSellTwoPrice.Text = double.Parse(model.SellTwoPrice).ToString("0.00");
                labSellTwoCount.Text = model.SellTwoCount;
                labSellThreePrice.Text = double.Parse(model.SellThreePrice).ToString("0.00");
                labSellThreeCount.Text = model.SellThreeCount;
                labSellFourPrice.Text = double.Parse(model.SellFourPrice).ToString("0.00");
                labSellFourCount.Text = model.SellFourCount;
                labSellFivePrice.Text = double.Parse(model.SellFivePrice).ToString("0.00");
                labSellFiveCount.Text = model.SellFiveCount;

                double growthRate = (double.Parse(model.CurrentPrice) - double.Parse(model.YesterdayClosePrice)) / double.Parse(model.YesterdayClosePrice)*100;
                if(growthRate > 0)
                {
                    labGrowthRate.Text = "+" + growthRate.ToString("0.00") + "%";
                    labGrowthRate.ForeColor = Color.Red;
                    
                }
                else
                {
                    labGrowthRate.Text = growthRate.ToString("0.00") + "%";
                    labGrowthRate.ForeColor = Color.Green;
                }
                double stockNum = double.Parse(stockId);
                if (stockNum >= 600000 && stockNum <= 603998)
                {
                    stockId = "sh" + stockId;
                }
                else if(stockNum >= 000001 && stockNum <= 300489)
                {
                    stockId = "sz" + stockId;
                }
                string pictureBuyOne = "http://image.sinajs.cn/newchart/min/n/" + stockId + ".gif";
                string pictureBuyTwo = "http://image.sinajs.cn/newchart/daily/n/" + stockId + ".gif";
               
                pictureBoxBuyOne.ImageLocation = pictureBuyOne;
                pictureBoxBuyTwo.ImageLocation = pictureBuyTwo;
            }
        }
        /// <summary>
        /// 校验买入的股票数量是否合法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxBuyCount_Leave(object sender, EventArgs e)
        {
            labBuyCountTip.Visible = false;
            if(textBoxBuyCount.Text=="")
            {
                labBuyCountTip.Text = "股票数量不能为空";
                labBuyCountTip.Visible = true;
                return;
            }
            if (textBoxStockId.Text!= "")
            {
                string stockId = textBoxStockId.Text;
                double invaliable = stockTradeBll.GetUserInvaliableFund();
                double currentPrice = stockTradeBll.GetCurrentStockPrice(stockId);
                int maxBuyCount = (int)(invaliable / currentPrice);
                labMaxBuyCount.Text = maxBuyCount.ToString();
                int buyCount = int.Parse(textBoxBuyCount.Text);
                if (buyCount > maxBuyCount)
                {
                    labBuyCountTip.Text = "买入数量过大";
                    labBuyCountTip.Visible = true;        
                    textBoxBuyCount.Text = "";
                }
                else
                {
                    labBuyCountTip.Visible = false;    
                }
            }
        }
        /// <summary>
        /// 显示可用资金
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPageBuyStock_Enter(object sender, EventArgs e)
        {
            double invaliable = stockTradeBll.GetUserInvaliableFund();
            labAvailableFund.Text = invaliable.ToString();
            string stockId = textBoxStockId.Text;
            double currentPrice = stockTradeBll.GetCurrentStockPrice(stockId);          
            labMaxBuyCount.Text = ((int)(invaliable / currentPrice)).ToString();            
        }
        /// <summary>
        /// 卖出股票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSellStock_Click(object sender, EventArgs e)
        {
            if (comBoxStockName.Text == "" || textBoxSellCount.Text == "" || textBoxSellPrice.Text == "" || labSellStockTip.Visible)
                return;
            stockTradeBll.UpdateUserInfo();
            int index = comBoxStockName.SelectedIndex;
            int count=int.Parse(textBoxSellCount.Text);
            int IsSellSuccess=stockTradeBll.SellStock(index, count);
            
            if(IsSellSuccess != -1)
            {
                string stockId="";
                stockTradeBll = new StockTradeBll(); //通过重新生成对象来刷新数据库中的数据
                DataTable dt = new DataTable();
                dt = stockTradeBll.GetUserStockInfo();
                if (dt.Rows.Count == 0)
                    return;
                if (dt.Rows[0][1].ToString() != "null")
                {                   
                    stockId = dt.Rows[index][1].ToString().Trim();                  
                    int stockCount = stockTradeBll.SelectStockCount(stockId);

                    if(stockCount==0)  //当用户的某支股票持有量为0时，删除该股票在数据库中的记录
                    {
                        stockTradeBll.DeleteStockInfo(stockId);
                    }
                    labAvailableCount.Text = stockCount.ToString();
                }
                double invaliable = stockTradeBll.GetUserInvaliableFund();
                labAvailableFund.Text = invaliable.ToString();                
                MessageBox.Show("股票卖出成功", "信息提示", MessageBoxButtons.OK);

                NowStockDataModel model = new NowStockDataModel();
                model = stockTradeBll.GetNowStockData(stockId);
                //string totalAsset = (LoginInfo.loginInfo.TotalAssets + double.Parse(model.CurrentPrice) * count).ToString("0.00");
                string available = (LoginInfo.loginInfo.AvailableFund + double.Parse(model.CurrentPrice) * count).ToString("0.00");
                MyPositionBll myPositionBll = new MyPositionBll();
                myPositionBll.UpdateAvailableFund(available);//卖出股票后，更新总资产、可用资金

                UpdateUserAssetStatus();
                MyPosition();
            }
            else
            {
                MessageBox.Show("股票卖出失败", "信息提示", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// 鼠标点击卖出股票的股票名称组合框后，查看可卖的股票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comBoxStockName_Enter(object sender, EventArgs e) 
        {
            int index=-1;
            if(comBoxStockName.SelectedIndex!=-1)
                index=comBoxStockName.SelectedIndex;
            DataTable dt = new DataTable();
            dt = stockTradeBll.GetUserStockInfo();
            if (dt.Rows.Count == 0)
            {
                comBoxStockName.Items.Clear();
                comBoxStockName.Text = "没有可卖的股票"; 
                return;
            }
            comBoxStockName.Items.Clear();                           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string stockName = dt.Rows[i][2].ToString().Trim();
                comBoxStockName.Items.Add(stockName);
            }
            comBoxStockName.SelectedIndex = index;                                              
        }
        /// <summary>
        /// 卖出股票模块中选择卖出股票名称的组合框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comBoxStockName_SelectedIndexChanged(object sender, EventArgs e)
        {      
            DataTable dt = new DataTable();
            dt = stockTradeBll.GetUserStockInfo();
            if (dt.Rows.Count == 0)
                return;
            int index = comBoxStockName.SelectedIndex;
            if (dt.Rows[0][1].ToString() != "null")
            {
                string stockId = dt.Rows[index][1].ToString().Trim();
                stockTradeBll = new StockTradeBll(); //通过重新生成对象来刷新数据库中的数据
                int stockCount = stockTradeBll.SelectStockCount(stockId);
                labAvailableCount.Text = stockCount.ToString();

                NowStockDataModel model = new NowStockDataModel();
                model = stockTradeBll.GetNowStockData(stockId);
                textBoxSellPrice.Text = model.CurrentPrice;

                labStockNameS.Text = model.StockName;
                labClosePriceS.Text = double.Parse(model.YesterdayClosePrice).ToString("0.00");
                labOpenPriceS.Text = double.Parse(model.TodayOpenPrice).ToString("0.00");
                labHighestPriceS.Text = double.Parse(model.HighestPrice).ToString("0.00");
                labLowestPriceS.Text = double.Parse(model.LowestPrice).ToString("0.00");
                labCurrentPriceS.Text = double.Parse(model.CurrentPrice).ToString("0.00");
                labBuyOnePriceS.Text = double.Parse(model.BuyOnePrice).ToString("0.00");
                labBuyOneCountS.Text = model.BuyOneCount;
                labBuyTwoPriceS.Text = double.Parse(model.BuyTwoPrice).ToString("0.00");
                labBuyTwoCountS.Text = model.BuyTwoCount;
                labBuyThreePriceS.Text = double.Parse(model.BuyThreePrice).ToString("0.00");
                labBuyThreeCountS.Text = model.BuyThreeCount;
                labBuyFourPriceS.Text = double.Parse(model.BuyFourPrice).ToString("0.00");
                labBuyFourCountS.Text = model.BuyFourCount;
                labBuyFivePriceS.Text = double.Parse(model.BuyFivePrice).ToString("0.00");
                labBuyFiveCountS.Text = model.BuyFiveCount;
                labSellOnePriceS.Text = double.Parse(model.SellOnePrice).ToString("0.00");
                labSellOneCountS.Text = model.SellOneCount;
                labSellTwoPriceS.Text = double.Parse(model.SellTwoPrice).ToString("0.00");
                labSellTwoCountS.Text = model.SellTwoCount;
                labSellThreePriceS.Text = double.Parse(model.SellThreePrice).ToString("0.00");
                labSellThreeCountS.Text = model.SellThreeCount;
                labSellFourPriceS.Text = double.Parse(model.SellFourPrice).ToString("0.00");
                labSellFourCountS.Text = model.SellFourCount;
                labSellFivePriceS.Text = double.Parse(model.SellFivePrice).ToString("0.00");
                labSellFiveCountS.Text = model.SellFiveCount;

                double growthRate = (double.Parse(model.CurrentPrice) - double.Parse(model.YesterdayClosePrice)) / double.Parse(model.YesterdayClosePrice)*100;
                if (growthRate > 0)
                {
                    labGrowthRateS.Text = "+" + growthRate.ToString("0.00") + "%";
                    labGrowthRateS.ForeColor = Color.Red;
                    
                }
                else
                {
                    labGrowthRateS.Text = growthRate.ToString("0.00") + "%";
                    labGrowthRateS.ForeColor = Color.Green;
                }
                double stockNum = double.Parse(stockId);
                if (stockNum >= 600000 && stockNum <= 603998)
                {
                    stockId = "sh" + stockId;
                }
                else if(stockNum >= 000001 && stockNum <= 300489)
                {
                    stockId = "sz" + stockId;
                }
                string pictureSellOne = "http://image.sinajs.cn/newchart/min/n/" + stockId + ".gif";
                string pictureSellTwo = "http://image.sinajs.cn/newchart/daily/n/" + stockId + ".gif";
                pictureBoxSellOne.ImageLocation = pictureSellOne;
                pictureBoxSellTwo.ImageLocation = pictureSellTwo; 
            
            }
        }
        /// <summary>
        /// 卖出股票模块的卖出股票数量输入框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSellCount_Leave(object sender, EventArgs e) 
        {
            DataTable dt = new DataTable();
            dt = stockTradeBll.GetUserStockInfo();
            if (dt.Rows.Count == 0)
                return;
            int index = comBoxStockName.SelectedIndex;
            if (dt.Rows[0][1].ToString() != "null")
            {
                string stockId = dt.Rows[index][1].ToString();
                int stockCount = stockTradeBll.SelectStockCount(stockId);
                int stockSellCount = 0;
                if(textBoxSellCount.Text!="")
                {
                     stockSellCount = int.Parse(textBoxSellCount.Text);
                }                   
                if (stockSellCount > stockCount)
                    labSellStockTip.Visible = true;
            }
        }
        /// <summary>
        /// 添加自选股
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOptionalStock_Click(object sender, EventArgs e)
        {
            NowStockDataModel nowStockModel = new NowStockDataModel();
            string stockId=textBoxOptionalStock.Text.Trim();
            nowStockModel = stockTradeBll.GetNowStockData(stockId);
            if(nowStockModel==null)
            {
                MessageBox.Show("该股票代码不合法", "信息提示", MessageBoxButtons.OK);
            }
            if(nowStockModel!=null)//nowStockModel不为空，说明该股票代码合法
            {
                labOptionalValid.Visible = false;

                DataTable dt = new DataTable();
                dt = optionalBll.GetUserOptionalStock();
                if(dt!=null)
                {
                    bool IsOptionalStockExist = false;//股票代码为stockId的股票是否已经是自选股
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        if(dt.Rows[i][1].ToString().Trim()==stockId)
                        {
                            IsOptionalStockExist = true;
                            break;
                        }
                    }
                    if (!IsOptionalStockExist)
                    {
                        optionalBll.AddOptionalStock(stockId);
                        UpdateOptionalStock(); //更新自选股信息
                        MessageBox.Show("已成功添加到自选股", "信息提示", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    optionalBll.AddOptionalStock(stockId);
                    UpdateOptionalStock();  //更新自选股信息
                    MessageBox.Show("已成功添加到自选股", "信息提示", MessageBoxButtons.OK);
                }
                DisplayOptionalPicture(stockId);
            }
            else
            {
                labOptionalValid.Visible = true;
            }
        }
        /// <summary>
        /// 更新自选股信息
        /// </summary>
        private void UpdateOptionalStock()
        {
            DataTable dt1 = optionalBll.GetUserOptionalStock();//重新查询当前用户自选股信息
            DataTable dtOptional = new DataTable();
            dtOptional.Columns.Add("Number", typeof(int));
            dtOptional.Columns.Add("stockId", typeof(string));
            dtOptional.Columns.Add("stockName", typeof(string));
            dtOptional.Columns.Add("growthRate", typeof(string));
            dtOptional.Columns.Add("currentPrice", typeof(string));
            dtOptional.Columns.Add("closePrice", typeof(string));
            dtOptional.Columns.Add("openPrice", typeof(string));
            dtOptional.Columns.Add("highestPrice", typeof(string));
            dtOptional.Columns.Add("lowestPrice", typeof(string));
            dtOptional.Columns.Add("buyOnePrice", typeof(string));
            dtOptional.Columns.Add("buyOneCount", typeof(string));
            dtOptional.Columns.Add("sellOnePrice", typeof(string));
            dtOptional.Columns.Add("sellOneCount", typeof(string));

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dtOptional.NewRow();
                NowStockDataModel model = new NowStockDataModel();
                model = stockTradeBll.GetNowStockData(dt1.Rows[i][1].ToString().Trim());
                double growthRate = (double.Parse(model.CurrentPrice) - double.Parse(model.YesterdayClosePrice)) / double.Parse(model.YesterdayClosePrice) * 100;
                string growthRateStr;
                if(growthRate>0)
                {
                    growthRateStr = "+" + growthRate.ToString("0.00") + "%";
                }
                else
                {
                    growthRateStr = growthRate.ToString("0.00") + "%";
                }
                
                dr[0] = i + 1;
                dr[1] = model.StockId;
                dr[2] = model.StockName;
                dr[3] = growthRateStr;
                dr[4] = model.CurrentPrice;
                dr[5] = model.YesterdayClosePrice;
                dr[6] = model.TodayOpenPrice;
                dr[7] = model.HighestPrice;
                dr[8] = model.LowestPrice;
                dr[9] = model.BuyOnePrice;
                dr[10] = model.BuyOneCount;
                dr[11] = model.SellOnePrice;
                dr[12] = model.SellOneCount;

                dtOptional.Rows.Add(dr);               
            }
            dataGridView1.DataSource = dtOptional;
            if(dt1.Rows.Count!=0)
            {
                DisplayOptionalPicture(dt1.Rows[0][1].ToString().Trim());
            }
        }
        /// <summary>
        /// 鼠标右键点击自选股，删除自选股信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                DataTable dt = new DataTable();
                dt = optionalBll.GetUserOptionalStock();
                string stockId = dt.Rows[index][1].ToString();
                optionalBll.DeleteOptionalStock(stockId); //删除自选股  
                MessageBox.Show("自选股删除成功", "信息提示", MessageBoxButtons.OK);
                UpdateOptionalStock();  //更新自选股信息
            }
        }
        /// <summary>
        /// 刷新自选股信息(每10秒刷新一次)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerOptionalStock_Tick(object sender, EventArgs e)
        {
            UpdateOptionalStock();
        }
        /// <summary>
        /// 更新当前用户资产状况 
        /// </summary>
        private void UpdateUserAssetStatus()  
        {
            
            labTotalAvailableFund.Text = LoginInfo.loginInfo.AvailableFund.ToString("0.00");
            labStockTotalEarn.Text = (LoginInfo.loginInfo.TotalAssets - LoginInfo.loginInfo.AvailableFund).ToString("0.00");
                        
            DataTable dt = new DataTable();
            dt = stockTradeBll.GetUserStockInfo();
            double totalDayEarn=0;  //当前持仓日盈利额
            double totalEarn=0;     //当前持仓总收益额
            double totalCost=0;     //当前持仓成本
            for(int i=0;i<dt.Rows.Count;i++)
            {
                string stockId = dt.Rows[i][1].ToString().Trim();
                NowStockDataModel model = new NowStockDataModel();
                totalCost += double.Parse(dt.Rows[i][3].ToString()) * double.Parse(dt.Rows[i][4].ToString());
                model = stockTradeBll.GetNowStockData(stockId);
                DateTime buyDate=Convert.ToDateTime(dt.Rows[i][5].ToString());
                double dayEarn=0.0;

                if (buyDate.ToShortDateString() == DateTime.Now.ToShortDateString())//该股票是今天才买的
                {
                    dayEarn = (double.Parse(model.CurrentPrice) - double.Parse(dt.Rows[i][3].ToString())) * int.Parse(dt.Rows[i][4].ToString());
                }
                else//该股票不是今天买的
                {
                    dayEarn = (double.Parse(model.CurrentPrice) - double.Parse(model.YesterdayClosePrice)) * int.Parse(dt.Rows[i][4].ToString());
                }
                              
                totalDayEarn += dayEarn;
                double earn = (double.Parse(model.CurrentPrice) - double.Parse(dt.Rows[i][3].ToString()))* int.Parse(dt.Rows[i][4].ToString());
                totalEarn += earn;
            }
            labTotalEarn.Text = (double.Parse(LoginInfo.loginInfo.TotalAssets.ToString("0.00"))+totalEarn).ToString("0.00");
            double totalGrowthRate = (double.Parse(labTotalEarn.Text) - 100000.00) / 100000.00 * 100;

            if (totalGrowthRate > 0)
            {
                labTotalGrowthRate.Text = "+" + totalGrowthRate.ToString("0.00") + "%";
            }
            else
            {
                labTotalGrowthRate.Text = totalGrowthRate.ToString("0.00") + "%";
            }
            double dayGrowth=0.0;
            if(totalCost!=0)
            {
                dayGrowth = totalDayEarn / totalCost * 100;
            }            
            if(dayGrowth>0)
            {
                labDayGrowth.Text = "+" + dayGrowth.ToString("0.00") + "%";
                
            }
            else
            {
                labDayGrowth.Text = dayGrowth.ToString("0.00") + "%";
            }
            labDayEarn.Text = totalDayEarn.ToString("0.00");        
            labTotalDayEarn.Text = totalEarn.ToString("0.00");
        }
        /// <summary>
        /// 刷新我的持仓 
        /// </summary>
        private void MyPosition()
        {
            MyPositionBll myPositionBll = new MyPositionBll();
            DataTable dt = new DataTable();
            dt = myPositionBll.GetUserPosition();
            dataGridViewMyPosition.DataSource = dt;
        }
        /// <summary>
        /// 鼠标单击某支自选股，窗体右侧就显示该自选股的日分时线，日K线图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = optionalBll.GetUserOptionalStock();
            if (dt.Rows.Count == 0||e.RowIndex>dt.Rows.Count-1)
                return;
            string stockId = dt.Rows[e.RowIndex][1].ToString().Trim();
            DisplayOptionalPicture(stockId);
        }
        /// <summary>
        /// 显示自选股的日分时图、日K线图
        /// </summary>
        /// <param name="stockId"></param>
        private void DisplayOptionalPicture(string stockId)
        {
            double stockNum = double.Parse(stockId);
            if (stockNum >= 600000 && stockNum <= 603998)
            {
                stockId = "sh" + stockId;
            }
            else if (stockNum >= 000001 && stockNum <= 300489)
            {
                stockId = "sz" + stockId;
            }
            pictureBoxOptionalOne.Image = null;
            pictureBoxOptionalTwo.Image = null;

            string pictureOptionalOne = "http://image.sinajs.cn/newchart/min/n/" + stockId + ".gif";
            string pictureOptionalTwo = "http://image.sinajs.cn/newchart/daily/n/" + stockId + ".gif";
            pictureBoxOptionalOne.ImageLocation = pictureOptionalOne;
            pictureBoxOptionalTwo.ImageLocation = pictureOptionalTwo;
        }
        /// <summary>
        /// radioButton1为true显示上证指数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            
        private void pictureBoxMenuOne_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pictureBoxMenuOne.Image = null;
                pictureBoxMenuTwo.Image = null;
                pictureBoxMenuOne.ImageLocation = "http://image.sinajs.cn/newchart/min/n/sh000001.gif";
                pictureBoxMenuTwo.ImageLocation = "http://image.sinajs.cn/newchart/daily/n/sh000001.gif";
            }
        }
        /// <summary>
        /// radioButton2为true显示深证指数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                pictureBoxMenuOne.Image = null;
                pictureBoxMenuTwo.Image = null;
                pictureBoxMenuOne.ImageLocation = "http://image.sinajs.cn/newchart/min/n/sz399001.gif";
                pictureBoxMenuTwo.ImageLocation = "http://image.sinajs.cn/newchart/daily/n/sz399001.gif";
            }
        }
        /// <summary>
        /// 鼠标点击自选股界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabCtMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUserAssetStatus();
            UpdateOptionalStock();           
        }
        /// <summary>
        /// 30秒刷新一次股票数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerStockTrade_Tick(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pictureBoxMenuOne.Image = null;
                pictureBoxMenuTwo.Image = null;
                pictureBoxMenuOne.ImageLocation = "http://image.sinajs.cn/newchart/min/n/sh000001.gif";
                pictureBoxMenuTwo.ImageLocation = "http://image.sinajs.cn/newchart/daily/n/sh000001.gif";
            }
            else
            {
                pictureBoxMenuOne.Image = null;
                pictureBoxMenuTwo.Image = null;
                pictureBoxMenuOne.ImageLocation = "http://image.sinajs.cn/newchart/min/n/sz399001.gif";
                pictureBoxMenuTwo.ImageLocation = "http://image.sinajs.cn/newchart/daily/n/sz399001.gif";
            }
            UpdateUserAssetStatus();
            MyPosition(); //刷新我的持仓

        }
        /// <summary>
        /// 获取上证指数分时图、K线图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                pictureBoxMenuOne.Image = null;
                pictureBoxMenuTwo.Image = null;
                pictureBoxMenuOne.ImageLocation = "http://image.sinajs.cn/newchart/min/n/sh000001.gif";
                pictureBoxMenuTwo.ImageLocation = "http://image.sinajs.cn/newchart/daily/n/sh000001.gif";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 股票交易页面属性值更改后发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabCtStockTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBoxStockName_Enter(sender, e);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
