using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormProject3.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using SqlLib;

namespace WebFormProject3.DAL
{
    public class UserDAL
    {
        private UserDAL() { }
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            string connectionString = ConfigurationManager.ConnectionStrings["MySSMS"].ConnectionString;
            string query = "SELECT TOP 100 * FROM Users;";

            DataRowCollection rows = SqlHelper.ExecuteRowCollection(connectionString, query, IsolationLevel.ReadUncommitted);

            foreach (DataRow row in rows)
            {
                users.Add(User.Of(
                    Convert.ToInt32(row["Seq"]),
                    Convert.ToString(row["Name"]),
                    Convert.ToString(row["Phone"]),
                    Convert.ToString(row["Birthday"]),
                    Convert.ToString(row["Gender"]),
                    Convert.ToDateTime(row["CDate"]),
                    Convert.IsDBNull(row["MDate"]) ? (DateTime?)null : Convert.ToDateTime(row["MDate"]),
                    Convert.IsDBNull(row["DDate"]) ? (DateTime?)null : Convert.ToDateTime(row["DDate"])
                ));
            }

            return users;
        }
    }
}