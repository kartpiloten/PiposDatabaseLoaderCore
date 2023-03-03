using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Npgsql;
using NpgsqlTypes;
using System.ComponentModel;
using System.Xml.Linq;

namespace PiposBefLoaderCore
{
    public class CPU_DBUtils
    {
        public static void VacuumTable(string ConnString, string Tablename)
        {
            // Vaccum table;
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);
            String CommandText = @"VACUUM FULL " + Tablename + ";";
            conn.Open();
            NpgsqlCommand m_setPrimaryKey_cmd = new NpgsqlCommand(CommandText, conn);
            m_setPrimaryKey_cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void CreateDB(string ShortConnString, string DbName)
        {
            //Kill all connections to the database
            //SELECT pg_terminate_backend(pid)FROM pg_stat_activity WHERE datname = 'YOUR_DATABASE_NAME_HERE'
            /*NpgsqlConnection conn = new NpgsqlConnection(ShortConnString);
            String CommandTextCloseConnections = @"SELECT pg_terminate_backend(pid)FROM pg_stat_activity WHERE datname = '" + DbName + "';";
            conn.Open();
            NpgsqlCommand m_setDropDB_cmd = new NpgsqlCommand(CommandTextCloseConnections, conn);
            
            int a = m_setDropDB_cmd.ExecuteNonQuery();
            conn.Close();*/

            // Create database;
            NpgsqlConnection conn2 = new NpgsqlConnection(ShortConnString);
 //           String CommandTextDrop = @" DROP DATABASE IF EXISTS " + DbName + ";";
            String CommandTextCreate = @"CREATE DATABASE " + DbName + ";";
            conn2.Open();
 //           NpgsqlCommand m_setDropDB_cmd2 = new NpgsqlCommand(CommandTextDrop, conn2);
 //           m_setDropDB_cmd2.ExecuteNonQuery();
            NpgsqlCommand m_setCreateDB_cmd3 = new NpgsqlCommand(CommandTextCreate, conn2);
            m_setCreateDB_cmd3.ExecuteNonQuery();
            conn2.Close();
        }
        public static void CreateSchema(string ConnString, string Schema)
        {
            // Create schema;
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);
            String CommandTextDrop = @" DROP SCHEMA IF EXISTS " + Schema + " CASCADE;";
            String CommandText = @"CREATE SCHEMA " + Schema + ";";
            conn.Open();
            NpgsqlCommand m_setPrimaryKey_cmd = new NpgsqlCommand(CommandTextDrop, conn);
            m_setPrimaryKey_cmd.ExecuteNonQuery();
            conn.Close();
            Task.Delay(20000);
            conn.Open();
            NpgsqlCommand m_setPrimaryKey_cmd2 = new NpgsqlCommand(CommandText, conn);
            m_setPrimaryKey_cmd2.ExecuteNonQuery();
            conn.Close();
        }
        public static void InstallPostGIS(string ConnString)
        {
            // Create schema;
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);
            String CommandText = @"CREATE EXTENSION postgis;";
            conn.Open();
            NpgsqlCommand m_setPrimaryKey_cmd = new NpgsqlCommand(CommandText, conn);
            m_setPrimaryKey_cmd.ExecuteNonQuery();
            conn.Close();
        }
 
        public static string GetPostgresVersion(string ConnString)
        {
            string result = "";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnString))
                {
                    conn.Open();
                    // Define a query
                    NpgsqlCommand command = new NpgsqlCommand(
                        "SELECT version();", conn);

                    // Execute the query and obtain a result set
                    NpgsqlDataReader dr = command.ExecuteReader();

                    // Output rows
                    while (dr.Read())
                    {
                        result = Convert.ToString(dr[0]);
                    }
                    conn.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e);
                return "Error";
            }
        }
 }
}

