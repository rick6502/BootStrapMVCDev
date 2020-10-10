using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace BootStrapMVCDev.DAC
{
    public class StaffTableDAC
    {
        public static string ConnectionString { get; set; }

        public StaffTableDAC(string connectString)
        {
            StaffTableDAC.ConnectionString = connectString;
        }

        private static SqlConnection DBConnectionSQL
        {
            get
            {
                SqlConnection sqlConn = new SqlConnection();
                string connString = ConnectionString;
                sqlConn.ConnectionString = connString;
                return sqlConn;
            }
        }


    }
}
