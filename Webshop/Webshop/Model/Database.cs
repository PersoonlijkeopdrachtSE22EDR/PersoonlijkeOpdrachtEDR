using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Webshop.Model
{
    public class Database
    {
        private static OracleConnection conn;

        public Database()
        {
            conn = new OracleConnection();
            string pcn = "dbi254244";
            string pw = "r6hUm1yeB";
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//192.168.15.50:1521/fhictora" + ";";
        }

        public DataTable getDate(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public void InsertData(string query)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Clone();
            }
        }
    }
}