using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 数据库操作类的基类，定义了操作数据的接口
    /// </summary>
    public abstract class AbstractSqlBaseDal : BaseSqlConnection
    {          
        abstract public int Query(string sql,  DataTable dt);
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sql">要执行的</param>
        /// <param name="args">参数列表</param>
        /// <param name="dt">保存数据的数据表</param>
        /// <returns>查询结果的行数</returns>
   
        abstract public int Update(string sql);
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns>受影响行数，失败返回-1</returns>
       
        abstract public int Delete(string sql);
        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns>受到影响的行数,失败返回-1</returns>
      
        abstract public int Insert(string sql);
        /// <summary>
        /// 使用clob插入数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
    }
    /// <summary>
    /// 数据库操作类的基类，定义了操作数据的接口
    /// </summary>
    public abstract class AbstractMySqlBaseDal : BaseMySqlConnection
    {
        abstract public int Query(string sql, DataTable dt);
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sql">要执行的</param>
        /// <param name="args">参数列表</param>
        /// <param name="dt">保存数据的数据表</param>
        /// <returns>查询结果的行数</returns>

        abstract public int Update(string sql);
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns>受影响行数，失败返回-1</returns>

        abstract public int Delete(string sql);
        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns>受到影响的行数,失败返回-1</returns>

        abstract public int Insert(string sql);
        /// <summary>
        /// 使用clob插入数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
    }
}
