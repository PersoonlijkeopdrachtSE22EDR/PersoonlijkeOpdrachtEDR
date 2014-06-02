//-----------------------------------------------------------------------
// <copyright file="Database.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Webshop2
{
    /// <summary>
    /// Deze klass wordt gebruikt om verbinding te maken met de database.
    /// </summary>
    public static class Database
    {
        private static OracleConnection conn;

        static Database()
        {
            conn = new OracleConnection();
            string pcn = "dbi254244";
            string pw = "r6hUm1yeBa";
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//192.168.15.50:1521/fhictora" + ";";
        }

        /// <summary>
        /// Haalt gegevens op uit de database op basis va neen query.
        /// </summary>
        /// <param name="query">De query die gebruikt wordt om gegevens op te halen</param>
        /// <returns>Returnt een datatable met gegevens.</returns>
        public static DataTable GetData(string query)
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

        /// <summary>
        /// Deze methode wordt gebruikt om gegevens op te halen uit de database d.m.v. queries met parameters.
        /// </summary>
        /// <param name="cmd">Het oraclecommand met parameters</param>
        /// <returns>Returnt een datatable met gegevens.</returns>
        public static DataTable GetDataParameters(OracleCommand cmd)
        {
            DataTable dt = new DataTable();
            cmd.Connection = conn;

            try
            {
                conn.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
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

        /// <summary>
        /// Met deze functie wordt worden er gegevens ge-update of ge-instert in de database d.m.v. een query met parameters
        /// </summary>
        /// <param name="cmd">Het oraclecommand met parameters.</param>
        public static void InsertData(OracleCommand cmd)
        {
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(OracleException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}