using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace printlabelqr
{
    class MysqlHelper
    {
        /// <summary>
        /// 数据库连接串
        /// </summary>
        private string ConnString = "";
        /// <summary>
        /// 数据库连接
        /// </summary>
        private MySqlConnection Conn;
        /// <summary>
        /// 错误信息
        /// </summary>
        public static string ErrorString = "";
        /// <summary>
        /// 超时（秒）
        /// </summary>
        public int TimeOut = 100;
		/// <summary>
		/// 
		/// </summary>
		private MySqlDataReader Reader;

		/// <summary>
		/// 初始化数据库链接
		/// </summary>
		/// <param name="connString">数据库链接</param>
		public MysqlHelper(string connString)
        {
            ConnString = connString;
            ConnTo();
        }


        public string ConnTo()
		{
			string result;
			try
			{
				Conn = new MySqlConnection(ConnString);
				Conn.Open();
				result = "success";
			}
			catch (Exception ex)
			{
				result = "数据库连接错误：" + ex.Message;
			}
			return result;
		}
        public void Close()
        {
            try
            {
                Conn.Close();
                Conn = null;
            }
            catch
            {           }
        }

		public int Get_supplies_desc(ref Dictionary<string, string> Dic_supplyer_desc)
		{
			int result;
			try
			{
				string strSql = "SELECT SUPPLIES_ID,SUPPLIES_NAME FROM `supplies_desc` ORDER BY SUPPLIES_ID";
				MySqlCommand mySqlCommand = new MySqlCommand(strSql, this.Conn);
				Reader = mySqlCommand.ExecuteReader();
				if (Reader.HasRows)
				{
					while (Reader.Read())
					{
						Dic_supplyer_desc.Add(Reader.GetString(0), Reader.GetString(1));			
					}
					Reader.Close();
					mySqlCommand.Dispose();
					result = 0;
				}
				else
				{
					Reader.Close();
					mySqlCommand.Dispose();
					result = 1;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				this.Reader.Close();
				result = 100;
			}
			return result;
		}

        /// <summary>
        /// 执行sql返回DataTable
        /// </summary>
        /// <param name="SqlString">SQL语句</param>
        /// <param name="parms">Sql参数</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string SqlString, MySqlParameter[] parms)
        {
            if (Conn == null || Conn.State != ConnectionState.Open)    ConnTo();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SqlString;
                cmd.CommandTimeout = TimeOut;
                if (parms != null)
                    foreach (MySqlParameter pram in parms)
                        cmd.Parameters.Add(pram);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception e)
            {
                AddError(e.Message, SqlString);
                return null;
            }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sql"></param>
        private void AddError(string message, string sql)
        {
            ErrorString += "数据库连接错误：" + message + "\r\nSQL语句：" + sql + "\r\n";
            if (!string.IsNullOrEmpty(ErrorString) && ErrorString.Length > 1000)
                ErrorString = "";
        }
    }
}
