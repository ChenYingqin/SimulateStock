using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
namespace DAL
{
   /* public class SqlserverDal : AbstractSqlBaseDal
    {
        
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="dt">保存数据的数据表</param>
        /// <returns>查询结果的行数</returns>

        override public int Query(String sql, DataTable dt)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql,this.con);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                return ada.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception(ex.StackTrace);
            }

        }
        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <returns>修改的行数</returns>
       
        override public int Update(string sql)
        {
            if (sql == null)
                throw new NullReferenceException("SQL语句为空");
            int result = -1;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, this.con);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    
        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>受到影响的行数,成功返回受影响的条数，失败返回值-1</returns>
        public override int Insert(string sql)
        {
            if (sql == null)
                throw new NullReferenceException("SQL语句为空");
            int result = -1;
            SqlCommand cmd = new SqlCommand(sql,this.con);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>受到影响的行数,成功返回受影响的条数，失败返回值-1</returns>
        override public int Delete(string sql)
        {
            if (sql == null)
                throw new NullReferenceException("SQL语句为空");
            int result = -1;
            try
            {
                SqlCommand cmd = new SqlCommand(sql,this.con);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }*/
        public class SqlserverDal : AbstractMySqlBaseDal
        {
            /// <summary>
            /// 查询操作
            /// </summary>
            /// <param name="sql">要执行的sql语句</param>
            /// <param name="dt">保存数据的数据表</param>
            /// <returns>查询结果的行数</returns>

            override public int Query(String sql, DataTable dt)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, this.con);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    return ada.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    throw new Exception(ex.StackTrace);
                }

            }
            /// <summary>
            /// 修改操作
            /// </summary>
            /// <param name="sql">要执行的sql语句</param>
            /// <returns>修改的行数</returns>

            override public int Update(string sql)
            {
                if (sql == null)
                    throw new NullReferenceException("SQL语句为空");
                int result = -1;
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, this.con);
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return result;
            }

            /// <summary>
            /// 插入操作
            /// </summary>
            /// <param name="sql"></param>
            /// <returns>受到影响的行数,成功返回受影响的条数，失败返回值-1</returns>
            public override int Insert(string sql)
            {
                if (sql == null)
                    throw new NullReferenceException("SQL语句为空");
                int result = -1;
                MySqlCommand cmd = new MySqlCommand(sql, this.con);
                result = cmd.ExecuteNonQuery();
                return result;
            }

            /// <summary>
            /// 删除操作
            /// </summary>
            /// <param name="sql"></param>
            /// <returns>受到影响的行数,成功返回受影响的条数，失败返回值-1</returns>
            override public int Delete(string sql)
            {
                if (sql == null)
                    throw new NullReferenceException("SQL语句为空");
                int result = -1;
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, this.con);
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return result;
            }
        }
 }
