using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace printlabelqr
{
    class DAO
    {
		//private static string connectionString = "server=10.64.155.22;port=3306;userid=root;password=root;database=fd_busb;charset=utf8";
		//private MySqlConnection Conn;
		//public int TimeOut = 100;

		private static string connectionString = "Data Source=192.168.60.210/scard;User ID=FDLABEL;Password=FDLABEL";
		private OracleConnection Conn;

		public string ConnTo()
		{
			string result;
			try
			{
				Conn = new OracleConnection(connectionString);

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
			if (Conn.State == ConnectionState.Open)
			{
				Conn.Close();
				Conn.Dispose();
			}
		}

		public string add_supplies(string strItem, string supplies_id_old, string supplies_name_old,string supplies_id, string supplies_name)
		{
			string strMessage = "";
			string strSql = "";
			switch (strItem)
			{
				case "add":
					strSql = @"insert into fdlabel.supplies_desc (SUPPLIES_ID,SUPPLIES_NAME,USABLE_FLAG) VALUES ('" + supplies_id + "','" + supplies_name + "', 1)";
					break;
				case "update":
					strSql = "update fdlabel.supplies_desc  set supplies_id='"+ supplies_id + "',supplies_name='"+ supplies_name + "' where supplies_id='"+ supplies_id_old + "'";
					break;
				case "del":
					strSql = "";
					break;
			}
			 
			try
			{
				Conn = new OracleConnection(connectionString);
				Conn.Open();
			}
			catch (Exception ex)
			{
				return "資料庫連線失敗:" + ex.Message;
			}
			OracleCommand cmd = new OracleCommand(strSql, this.Conn);
			try
			{
				int i=cmd.ExecuteNonQuery();
				if (i > 0)
				{
					return "OK";
				}
				else
				{
					return "no";
				}
				
			}
			catch (Exception ex)
			{
				return "查询基本资料错误：" + ex.Message;
			}
			finally
			{
				if (Conn.State == ConnectionState.Open)
				{
					cmd.Dispose();
					Conn.Close();
					Conn.Dispose();
				}
			}

		}

		public string get_supplies(string supplies_id,ref DataTable dt)
		{
			string strMessage = "";
			string strSql = @"select * from fdlabel.supplies_desc where supplies_id='"+ supplies_id + "' and usable_flag=1";
			try
			{
				Conn = new OracleConnection(connectionString);
				Conn.Open();
			}
			catch (Exception ex)
			{
				return "資料庫連線失敗:" + ex.Message;
			}
			OracleCommand cmd = new OracleCommand(strSql, this.Conn);
			try
			{
				dt.Load(cmd.ExecuteReader());
				return "OK";
			}
			catch (Exception ex)
			{
				return "查询基本资料错误：" + ex.Message;
			}
			finally
			{
				if (Conn.State == ConnectionState.Open)
				{
					cmd.Dispose();
					Conn.Close();
					Conn.Dispose();
				}
			}

		}

		public string get_data(ref DataTable dt)
        {
			string strMessage = "";
			string strSql = @"SELECT supplies_desc.SUPPLIES_ID,
       SUPPLIES_NAME,
       PART_NO,
       PART_NAME,
       SPEC,
       BAND,
       MATERIAL,
       UNIT
  FROM    fdlabel.supplies_desc
       LEFT JOIN
          fdlabel.part_desc
       ON     supplies_desc.SUPPLIES_ID = part_desc.SUPPLIES_ID
          where supplies_desc.USABLE_FLAG = 1
          AND part_desc.USABLE_FLAG = 1";
			try
			{
				Conn = new OracleConnection(connectionString);
				Conn.Open();
			}
			catch(Exception ex) 
			{
				return "資料庫連線失敗:" + ex.Message;
			}
			OracleCommand cmd = new OracleCommand(strSql, this.Conn);
			try
			{
				dt.Load(cmd.ExecuteReader());		
				return strMessage;
			}
			catch (Exception ex) 
			{
				return "查询基本资料错误：" + ex.Message;
			}
			finally
			{
				if (Conn.State == ConnectionState.Open)
				{
					cmd.Dispose();
					Conn.Close();
					Conn.Dispose();
				}
			}

		}

		public string get_last_epNO(string PROD_DATE)
		{
			string strMessage = "";
			string strSql = "select * from (SELECT  EP_NO FROM fdlabel.sn_data_his WHERE PROD_DATE='" + PROD_DATE + "' order by EP_NO desc ) where   rownum=1";
			try
			{
				Conn = new OracleConnection(connectionString);
				Conn.Open();
			}
			catch (Exception ex)
			{
				return "NG:資料庫連線失敗:" + ex.Message;
			}
			OracleCommand cmd = new OracleCommand(strSql, this.Conn);
			DataTable tempDT = new DataTable();
			try
			{
				tempDT.Load(cmd.ExecuteReader());
				if (tempDT != null && tempDT.Rows.Count != 0)
				{
					strMessage = tempDT.Rows[0]["EP_NO"].ToString();
				}
				else
				{
					strMessage = "000";
				}
			}
			catch (Exception ex)
			{
				strMessage = "NG:get_last_epNO查询EP_NO资料失败:" + ex.Message;
			}
			finally
			{
				if (Conn.State == ConnectionState.Open)
				{
					cmd.Dispose();
					Conn.Close();
					Conn.Dispose();
				}
			}
			return strMessage;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="PROD_DATE"></param>
		/// <param name="tempDT"></param>
		/// <returns></returns>
		public string get_serial_no(string PROD_DATE)
		{
			string strSql = "select * from (SELECT  SERIAL_NO FROM fdlabel.sn_data_his WHERE PROD_DATE='" + PROD_DATE + "' order by SERIAL_NO desc ) where   rownum=1";
			OracleCommand cmd = new OracleCommand(strSql, this.Conn);
			DataTable tempDT = new DataTable();
			string strResult = "";
			try
			{
				tempDT.Load(cmd.ExecuteReader());
				if (tempDT != null && tempDT.Rows.Count != 0)
				{
					strResult= tempDT.Rows[0]["SERIAL_NO"].ToString();
				}
			}
			catch (Exception ex)
			{
				strResult= "NG:get_serial_no查询sn_data资料失败:" + ex.Message;
			}
			finally { cmd.Dispose(); }
			return strResult;
		}
		public string get_ep_sum(string strEP_DATA)
		{
			string strSql = "SELECT EP_NO  FROM fdlabel.sn_data_his where EP_NO='" + strEP_DATA + "'";
			OracleCommand cmd = new OracleCommand(strSql, this.Conn);
			DataTable tempDT = new DataTable();
			string strResult = "OK";
			try
			{
				tempDT.Load(cmd.ExecuteReader());
				if (tempDT != null && tempDT.Rows.Count != 0)
				{
					strResult = "NO";
				}
			}
			catch (Exception ex)
			{
				strResult = "NG:get_serial_no查询EP_NO资料失败 :" + ex.Message;
			}
			finally { cmd.Dispose(); }
			return strResult;
		}
		/// <summary>
		/// 写入
		/// </summary>
		/// <param name="SUPPLYER_ID"></param>
		/// <param name="LOT_NO"></param>
		/// <param name="PROD_DATE"></param>
		/// <param name="WO_NO"></param>
		/// <param name="QTY"></param>
		/// <param name="UNIT"></param>
		/// <param name="SUPPLYER"></param>
		/// <param name="PART_NO"></param>
		/// <param name="PART_NAME"></param>
		/// <param name="BAND"></param>
		/// <param name="SPEC"></param>
		/// <param name="MATERIAL"></param>
		/// <param name="BUY_NO"></param>
		/// <param name="BUY_ENTRY"></param>
		/// <param name="VERIFIER"></param>
		/// <param name="REMARK"></param>
		/// <returns></returns>
		public string Insert_sn_data(string strSERIAL_NO,string strEP_NO,string  SUPPLYER_ID,string LOT_NO, string PROD_DATE, string WO_NO, string QTY, string UNIT, string SUPPLYER, string PART_NO, string PART_NAME, string BAND, string SPEC, string MATERIAL, string BUY_NO, string BUY_ENTRY, string VERIFIER, string REMARK) 
		{

		string	strSql = string.Format("INSERT INTO fdlabel.SN_DATA_HIS (SERIAL_NO, EP_NO, LOT_NO, PROD_DATE, WO_NO, QTY, UNIT,SUPPLYER_ID, SUPPLYER, PART_NO, PART_NAME, BAND, SPEC, MATERIAL, BUY_NO, BUY_ENTRY, VERIFIER, REMARK,UPDATE_TIME) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}',{18})",
				strSERIAL_NO, strEP_NO, LOT_NO, PROD_DATE, WO_NO, QTY, UNIT, SUPPLYER_ID, SUPPLYER, PART_NO, PART_NAME, BAND, SPEC, MATERIAL, BUY_NO, BUY_ENTRY, VERIFIER, REMARK,"SYSDATE");

			OracleCommand cmd2 = new OracleCommand(strSql, this.Conn);
			try 
			{
				cmd2.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				if (ex.Message.IndexOf("ORA-00001") >= 0)
				{
					return "Duplicate";
				}
				else
				{
					return  "NG:Insert_sn_data失败:" + ex.Message;
				}
			}

			return "OK";

		}

	}
}
