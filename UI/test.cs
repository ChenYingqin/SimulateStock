using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Model;

namespace UI
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            string a=DateTime.Now.ToString();
            DateTime b = Convert.ToDateTime(a);
            textBox1.Text = b.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NowStockDataDal nowStockDataDal = new NowStockDataDal();
            NowStockDataModel model = nowStockDataDal.GetNowStockData(textBox1.Text);
            if (model != null)
            {
                label1.Text = "";
                label1.Text += model.StockId + " " + model.StockName + " " + model.TodayOpenPrice + " " + model.YesterdayClosePrice + " " + model.CurrentPrice + " " + model.HighestPrice + " " + model.LowestPrice+model.BuyOneCount+" "+model.BuyOnePrice+" "+model.SellOneCount+" "+model.SellOnePrice;
            }

        }
    }
}
