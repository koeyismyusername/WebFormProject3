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
        private static readonly string tableName = bool.Parse(ConfigurationManager.AppSettings["IsHome"]) ? "Users" : "User_TEST";
        private static readonly string connectionStringKey = bool.Parse(ConfigurationManager.AppSettings["IsHome"]) ? "MySSMS" : "TomatoSSMS";

        private UserDAL() { }
        public static List<User> GetUsers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
            string query = $"SELECT TOP 100 * FROM {tableName};";

            return SqlHelper.ExecuteAll<User>(connectionString, query, null, IsolationLevel.ReadUncommitted);
        }

        public static void InsertUser(User user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
            string query = $@"INSERT INTO {tableName}(Phone, Name, Birthday, Gender)
VALUES
    (@phone, @name, @birthday, @genderCode)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@phone", user.Phone),
                new SqlParameter("@name", user.Name),
                new SqlParameter("@birthday", user.Birthday),
                new SqlParameter("@genderCode", user.GenderCode),
            };

            SqlHelper.ExecuteNone(connectionString, query, sqlParameters);
        }
    }
}