using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BootStrapMVCDev.Models;
using System.Data;

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

        public Boolean CheckUserID(string userid, string pasword)
        {
            Boolean rCode = false;
            string query = "Select * from tblstaff x1 where x1.userid = @userid and x1.password = @password";
            using (var DBConn = DBConnectionSQL)
            {
                SqlCommand cmd = new SqlCommand(query, DBConn);
                cmd.Parameters.Add(new SqlParameter("@userid", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar));
                cmd.Parameters["@userid"].Value = userid;
                cmd.Parameters["@password"].Value = pasword;
                DBConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rCode = true;
                }
                reader.Close();
            }
            return rCode;
        }

    }
}
