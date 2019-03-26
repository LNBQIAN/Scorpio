using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Reflection;
using System.Collections;
namespace Common
{
    #region ADO.NET 访问数据库辅助类 +SqlHelp
    //Author:兵兵 +SqlHelp
    public class DBHelper
    {
        /// <summary>
        /// DB连接字符串
        /// </summary>
        public static readonly string DB = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;


        #region ExecuteDataReader +ExecuteDataReader(string cmdText, List<SqlParameter> parameters,string connString)
        /// <summary>
        /// ExecuteDataReader(执行有参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>SqlDataReader对象</returns>
        public static SqlDataReader ExecuteDataReader(string cmdText, List<SqlParameter> parameters, string connString)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            CommandBuilder(cmdText, cmd, conn, parameters);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return reader;

        }
        #endregion

        #region ExecuteDataReader +ExecuteDataReader(string cmdText,string connString)
        /// <summary>
        /// ExecuteDataReader(执行无参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>SqlDataReader对象</returns>
        public static SqlDataReader ExecuteDataReader(string cmdText, string connString)
        {

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            CommandBuilder(cmdText, cmd, conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return reader;

        }
        #endregion

        #region ExecuteNonQuery +ExecuteNonQuery(string cmdText, List<SqlParameter> parameters, string connString)
        /// <summary>
        /// ExecuteNonQuery(执行有参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>数据库受影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, List<SqlParameter> parameters, string connString)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                CommandBuilder(cmdText, cmd, conn, parameters);
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return result;
            }
        }
        #endregion

        #region ExecuteNonQuery +ExecuteNonQuery(string cmdText, string connString)
        /// <summary>
        /// ExecuteNonQuery(执行无参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>数据库受影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, string connString)
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                CommandBuilder(cmdText, cmd, conn);
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return result;
            }


        }
        #endregion

        #region ExecuteScalar +ExecuteScalar(string cmdText, List<SqlParameter> parameters, string connString)
        /// <summary>
        /// ExecuteScalar(执行有参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string cmdText, List<SqlParameter> parameters, string connString)
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                CommandBuilder(cmdText, cmd, conn, parameters);
                object o = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return o;
            }


        }
        #endregion

        #region ExecuteScalar +ExecuteScalar(string cmdText, string connString)
        /// <summary>
        /// ExecuteScalar(执行无参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string cmdText, string connString)
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                CommandBuilder(cmdText, cmd, conn);
                object o = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return o;
            }


        }
        #endregion

        #region ExecuteDataTable +ExecuteDataTable(string cmdText, List<SqlParameter> parameters, string connString)
        /// <summary>
        /// ExecuteDataTable(用适配器执行有参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string cmdText, List<SqlParameter> parameters, string connString)
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
                //命令类型为存储过程
                da.DeleteCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddRange(parameters.ToArray());
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }


        }
        #endregion

        #region ExecuteDataTable +ExecuteDataTable(string cmdText, string connString)
        /// <summary>
        /// ExecuteDataTable(用适配器执行无参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string cmdText, string connString)
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
                //命令类型为存储过程
                da.DeleteCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region ExecuteDataTableProc(命令+适配器) +ExecuteDataTableProc(string cmdText, List<SqlParameter> parameters, string connString)
        /// <summary>
        /// ExecuteDataTableProc(执行有参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTableProc(string cmdText, List<SqlParameter> parameters, string connString)
        /// <summary>
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                CommandBuilder(cmdText, cmd, conn, parameters);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmd.Parameters.Clear();
                return dt;

            }

        }
        #endregion

        #region ExecuteDataTableProc(命令+适配器) +ExecuteDataTableProc(string cmdText, string connString)
        /// <summary>
        /// ExecuteDataTableProc(执行无参存储过程)
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <param name="connString">连接字符串</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTableProc(string cmdText, string connString)
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                CommandBuilder(cmdText, cmd, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmd.Parameters.Clear();
                return dt;

            }

        }
        #endregion

        #region 准备命令对象 -CommandBuilder(string cmdText, SqlCommand cmd, SqlConnection conn, List<SqlParameter> parameters)
        /// <summary>
        /// 准备命令对象(执行有参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="cmd">命令对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="parameters">参数列表</param>
        private static void CommandBuilder(string cmdText, SqlCommand cmd, SqlConnection conn, List<SqlParameter> parameters)
        {

            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (parameters.Count > 0)
                cmd.Parameters.AddRange(parameters.ToArray());

        }
        #endregion

        #region 准备命令对象 -CommandBuilder(string cmdText, SqlCommand cmd, SqlConnection conn)
        /// <summary>
        /// 准备命令对象(执行无参存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="cmd">命令对象</param>
        /// <param name="conn">连接对象</param>
        private static void CommandBuilder(string cmdText, SqlCommand cmd, SqlConnection conn)
        {

            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        }
        #endregion

        #region 批插入 void BulkInsert( DataTable dt, string tableName, string connStr)
        /// <summary>
        /// 批插入 void BulkInsert( DataTable dt, string tableName, string connStr)
        /// </summary>
        /// <param name="dt">所有数据的表格</param>
        /// <param name="tableName">表名</param>
        public static int BulkInsert(DataTable dt, string tableName, string connStr)
        {
            int result = -1;
            if (string.IsNullOrEmpty(tableName))
                throw new Exception("请指定你要插入的表名");
            var count = dt.Rows.Count;
            if (count == 0)
                return result;
            SqlTransaction sqlBulkTran = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                        conn.Open();
                    sqlBulkTran = conn.BeginTransaction();
                    using (SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.CheckConstraints, sqlBulkTran))
                    {
                        copy.DestinationTableName = tableName;//指定目标表
                        copy.WriteToServer(dt);//将dt中的所有行复制到SqlBulkCopy对象的DestinationTableName指定的目标表中
                        if (sqlBulkTran != null)
                        {
                            sqlBulkTran.Commit();
                        }
                        result = 1;
                    }

                }

            }
            catch (Exception)
            {
                if (sqlBulkTran != null)
                {
                    sqlBulkTran.Rollback();
                }
            }
            finally
            {
                sqlBulkTran = null;
            }

            return result;
        }
        #endregion


    }
    #endregion
}
#region list 扩展方法 Author:高兵兵
public static class IListUtil
{
    /// <summary>
    /// 将集合类转换成DataTable 
    /// </summary>
    /// <param name="list">集合</param>
    /// <returns></returns>
    public static DataTable AsDataTable<T>(this IList<T> list)
    {
        DataTable result = new DataTable();
        if (list.Count > 0)
        {
            PropertyInfo[] propertys = typeof(T).GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                result.Columns.Add(pi.Name, pi.PropertyType);
            }

            for (int i = 0; i < list.Count; i++)
            {
                ArrayList tempList = new ArrayList();
                foreach (var item in propertys)
                {
                    object obj = item.GetValue(list[i], null);
                    tempList.Add(obj);
                }

                object[] array = tempList.ToArray();
                result.LoadDataRow(array, true);
            }
        }
        return result;
    }


}
#endregion