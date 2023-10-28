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
                    (int)row["Seq"],
                    (string)row["Name"],
                    (string)row["Phone"],
                    (string)row["Birthday"],
                    (string)row["Gender"],
                    (DateTime)row["CDate"],
                    row["MDate"] is DBNull ? (DateTime?)null : (DateTime)row["MDate"],
                    row["DDate"] is DBNull ? (DateTime?)null : (DateTime)row["DDate"]
                ));
            }

            return users;
        }
    }
}