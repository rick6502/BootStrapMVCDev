using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BootStrapMVCDev.Models;

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

        public StaffList GetStaffList()
        {
            StaffList aList = new StaffList();
            string query = "Select * from tblstaff order by userid";

            using (var DBConn = DBConnectionSQL)
            {
                SqlCommand cmd = new SqlCommand(query, DBConn);
                DBConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Staff staffItem = new Staff();
                    staffItem.UserID = reader["userid"].ToString().Trim();
                    staffItem.PersonnelName = reader["personnelName"].ToString().Trim();
                    staffItem.FirstName = reader["first_Name"].ToString().Trim();
                    staffItem.LastName = reader["last_Name"].ToString().Trim();
                    aList.Add(staffItem);
                }
                reader.Close();
            }
            return aList;
        }

    }
}
