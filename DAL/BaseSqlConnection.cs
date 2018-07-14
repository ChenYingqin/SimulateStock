using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class BaseSqlConnection 
    {
        string connectionString = "server=.;database=SimulateStock;Trusted_Connection=SSPI";
        public SqlConnection con;
        public BaseSqlConnection()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
    }
    public class BaseMySqlConnection
    {
        //string connectionString = "server=593c19d541b9e.gz.cdb.myqcloud.com:4329;user id=cdb_outerroot;password=cyq123456;database=SimulateStock";
        string connectionString = "server =593c19d541b9e.gz.cdb.myqcloud.com; user id =cdb_outerroot; password =cyq123456 ; database = SimulateStock;port =4329";
        public MySqlConnection con; 
        public BaseMySqlConnection()
        {
            con= new MySqlConnection(connectionString);
            con.Open();
        }                  
    }
}
