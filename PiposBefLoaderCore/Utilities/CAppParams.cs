using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiposBefLoaderCore
{
    // This class holds the parameters of the import application
    static public class CPU_AppParameters
    {

        //Setup for the MasterDBdatabas
        public static string MasterDBServer = "MasterDB";
        public static string MasterDB = "scenariodb";
        public static string MasterDBPort = "5432";
        public static string MasterDBUser = "rt_admin";
        public static string MasterDBPsw = "XM!Jsa0-5Nd!Zds";

        public static string shortConnstring()
        {
            return "Server=" + MasterDBServer + ";Port=" + MasterDBPort + ";User Id=" + MasterDBUser + ";Password=" + MasterDBPsw + ";Database = " + MasterDB + ";";  // Use when creating a new database
        }
        public static string connStringDB()
        {
            return "Server=" + MasterDBServer + ";Port=" + MasterDBPort + ";User Id=" + MasterDBUser + ";Password=" + MasterDBPsw + ";Database=" + MasterDB + ";CommandTimeout=50000;";
        }
    }
}

