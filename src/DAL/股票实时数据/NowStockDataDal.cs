using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Net;
using System.IO;
namespace DAL
{
    public class NowStockDataDal
    {
        NowStockDataModel model;
        public NowStockDataModel GetNowStockData(string stockId)
        {
            model = new NowStockDataModel();
            if (stockId.Length > 5)
            {
                string stock = "";
                bool IsSuccess=CheckStockNumber(stockId, out stock);
                string url = StockNumberInput(stock);

                bool IsGetData=getstockdata(url);
                if(!IsGetData)
                {
                    model = null;
                }
                return model;              
            }
            else
                return null;
        }
        String StockNumberInput(string input)
        {

            string url = "http://hq.sinajs.cn/list=";
            url = url + input;
            return url;
        }
        public bool CheckStockNumber(string input)
        {
            bool PureNum = true;
            ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例  
            byte[] bytestr = ascii.GetBytes(input);         //把string类型的参数保存到数组里  

            if (input.Length != 6)
                return false;


            foreach (byte c in bytestr)                   //遍历这个数组里的内容  
            {
                if (c < 48 || c > 57)                          //判断是否为数字  
                {
                    PureNum = false;
                }
            }

            if (PureNum)
            {
                int StockNum = System.Convert.ToInt32(input);
                if (StockNum >= 600000 && StockNum <= 603998)
                {
                    
                }
                else if (StockNum >= 000001 && StockNum <= 300489)
                {

                }
                else
                {
                    return false;
                }

            }

            else
            {
                return false;
            }
            return true;
        }
        public bool CheckStockNumber(string input, out string stock)
        {

            bool PureNum = true;
            ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例  
            byte[] bytestr = ascii.GetBytes(input);         //把string类型的参数保存到数组里  

            stock = "";

            foreach (byte c in bytestr)                   //遍历这个数组里的内容  
            {
                if (c < 48 || c > 57)                          //判断是否为数字  
                {
                    PureNum = false;
                }
            }

            if (PureNum)
            {
                int StockNum = System.Convert.ToInt32(input);
                if (StockNum >= 600000 && StockNum <= 603998)
                {
                    stock = "sh" + input; //input加sh
                }
                else if (StockNum >= 000001 && StockNum <= 300489)
                {
                    //input加sz
                    stock = "sz" + input;
                }
                else
                {
                    return false;
                }
                    
            }

            else
            {
                return false;
            }
            return true;
        }
        bool getstockdata(string urlinput)
        {

            string strResponse = null;
            string url = urlinput;

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
               
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
          
            Stream receiveStream = myHttpWebResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("GB2312");  //select GB2312 as decoding
            
            StreamReader readStream = new StreamReader(receiveStream, encode);
            strResponse = readStream.ReadToEnd();
            readStream.Close();
            int StrLen = strResponse.Length;
            if (StrLen > 100)
            {
                int StockNumLocation = 0;
                if (strResponse.IndexOf("sz") >= 0)
                    StockNumLocation = strResponse.IndexOf("sz");
                else
                    StockNumLocation = strResponse.IndexOf("sh");

                int StockNameLocation = StockNumLocation + 10;

                model.StockId = strResponse.Substring(StockNumLocation, (StockNameLocation - StockNumLocation - 2));

                int OpeningPriceLocation = strResponse.IndexOf(",", StockNumLocation) + 1;
                model.StockName = strResponse.Substring(StockNameLocation, OpeningPriceLocation - StockNameLocation - 1);

                int YesClosingPriceLocation = strResponse.IndexOf(",", OpeningPriceLocation) + 1;

                model.TodayOpenPrice = strResponse.Substring(OpeningPriceLocation, YesClosingPriceLocation - OpeningPriceLocation - 1);

                int ClosingPriceLocation = strResponse.IndexOf(",", YesClosingPriceLocation) + 1;
                model.YesterdayClosePrice = strResponse.Substring(YesClosingPriceLocation, ClosingPriceLocation - YesClosingPriceLocation - 1);

                int HighestPriceLocation = strResponse.IndexOf(",", ClosingPriceLocation) + 1;
                model.CurrentPrice = strResponse.Substring(ClosingPriceLocation, HighestPriceLocation - ClosingPriceLocation - 1);

                int LowestPriceLocation = strResponse.IndexOf(",", HighestPriceLocation) + 1;
                model.HighestPrice = strResponse.Substring(HighestPriceLocation, LowestPriceLocation - HighestPriceLocation - 1);

                int DealPriceLocation = strResponse.IndexOf(",", LowestPriceLocation) + 1;
                model.LowestPrice = strResponse.Substring(LowestPriceLocation, DealPriceLocation - LowestPriceLocation - 1);

                int SellPriceLocation = strResponse.IndexOf(",", DealPriceLocation) + 1;
                int VolumeLocation = strResponse.IndexOf(",", SellPriceLocation) + 1;
                int TurnoverLocation = strResponse.IndexOf(",", VolumeLocation) + 1;
                int Buy1VolumeLocation = strResponse.IndexOf(",", TurnoverLocation) + 1;

                int Buy1PriceLocation = strResponse.IndexOf(",", Buy1VolumeLocation) + 1;
                model.BuyOneCount = strResponse.Substring(Buy1VolumeLocation, Buy1PriceLocation - Buy1VolumeLocation - 1);               

                int Buy2VolumeLocation = strResponse.IndexOf(",", Buy1PriceLocation) + 1;
                model.BuyOnePrice = strResponse.Substring(Buy1PriceLocation, Buy2VolumeLocation - Buy1PriceLocation - 1);             

                int Buy2PriceLocation = strResponse.IndexOf(",", Buy2VolumeLocation) + 1;
                model.BuyTwoCount= strResponse.Substring(Buy2VolumeLocation, Buy2PriceLocation - Buy2VolumeLocation - 1);
             
                int Buy3VolumeLocation = strResponse.IndexOf(",", Buy2PriceLocation) + 1;
                model.BuyTwoPrice = strResponse.Substring(Buy2PriceLocation, Buy3VolumeLocation - Buy2PriceLocation - 1);
            
                int Buy3PriceLocation = strResponse.IndexOf(",", Buy3VolumeLocation) + 1;
                model.BuyThreeCount = strResponse.Substring(Buy3VolumeLocation, Buy3PriceLocation - Buy3VolumeLocation - 1);
        
                int Buy4VolumeLocation = strResponse.IndexOf(",", Buy3PriceLocation) + 1;
                model.BuyThreePrice = strResponse.Substring(Buy3PriceLocation, Buy4VolumeLocation - Buy3PriceLocation - 1);
           
                int Buy4PriceLocation = strResponse.IndexOf(",", Buy4VolumeLocation) + 1;
                model.BuyFourCount = strResponse.Substring(Buy4VolumeLocation, Buy4PriceLocation - Buy4VolumeLocation - 1);

                int Buy5VolumeLocation = strResponse.IndexOf(",", Buy4PriceLocation) + 1;
                model.BuyFourPrice = strResponse.Substring(Buy4PriceLocation, Buy5VolumeLocation - Buy4PriceLocation - 1);
            
                int Buy5PriceLocation = strResponse.IndexOf(",", Buy5VolumeLocation) + 1;
                model.BuyFiveCount = strResponse.Substring(Buy5VolumeLocation, Buy5PriceLocation - Buy5VolumeLocation - 1);
             
                int Sell1VolumeLocation = strResponse.IndexOf(",", Buy5PriceLocation) + 1;
                model.BuyFivePrice = strResponse.Substring(Buy5PriceLocation, Sell1VolumeLocation - Buy5PriceLocation - 1);
      
                int Sell1PriceLocation = strResponse.IndexOf(",", Sell1VolumeLocation) + 1;
                model.SellOneCount = strResponse.Substring(Sell1VolumeLocation, Sell1PriceLocation - Sell1VolumeLocation - 1);
            
                int Sell2VolumeLocation = strResponse.IndexOf(",", Sell1PriceLocation) + 1;
                model.SellOnePrice = strResponse.Substring(Sell1PriceLocation, Sell2VolumeLocation - Sell1PriceLocation - 1);

                int Sell2PriceLocation = strResponse.IndexOf(",", Sell2VolumeLocation) + 1;
                model.SellTwoCount = strResponse.Substring(Sell2VolumeLocation, Sell2PriceLocation - Sell2VolumeLocation - 1);
              
                int Sell3VolumeLocation = strResponse.IndexOf(",", Sell2PriceLocation) + 1;
                model.SellTwoPrice = strResponse.Substring(Sell2PriceLocation, Sell3VolumeLocation - Sell2PriceLocation - 1);
             
                int Sell3PriceLocation = strResponse.IndexOf(",", Sell3VolumeLocation) + 1;
                model.SellThreeCount = strResponse.Substring(Sell3VolumeLocation, Sell3PriceLocation - Sell3VolumeLocation - 1);
             
                int Sell4VolumeLocation = strResponse.IndexOf(",", Sell3PriceLocation) + 1;
                model.SellThreePrice = strResponse.Substring(Sell3PriceLocation, Sell4VolumeLocation - Sell3PriceLocation - 1);
             
                int Sell4PriceLocation = strResponse.IndexOf(",", Sell4VolumeLocation) + 1;
                model.SellFourCount = strResponse.Substring(Sell4VolumeLocation, Sell4PriceLocation - Sell4VolumeLocation - 1);
            
                int Sell5VolumeLocation = strResponse.IndexOf(",", Sell4PriceLocation) + 1;
                model.SellFourPrice= strResponse.Substring(Sell4PriceLocation, Sell5VolumeLocation - Sell4PriceLocation - 1);
            
                int Sell5PriceLocation = strResponse.IndexOf(",", Sell5VolumeLocation) + 1;
                model.SellFiveCount = strResponse.Substring(Sell5VolumeLocation, Sell5PriceLocation - Sell5VolumeLocation - 1);
               
                int DateLocation = strResponse.IndexOf(",", Sell5PriceLocation) + 1;
                model.SellFivePrice = strResponse.Substring(Sell5PriceLocation, DateLocation - Sell5PriceLocation - 1);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
