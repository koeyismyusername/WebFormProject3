using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormProject3.DAL;
using WebFormProject3.Models;

namespace WebFormProject3.BLL
{
    public class UserBLL
    {
        private static UserBLL _instance;
        public static UserBLL Instance
        {
            get
            {
                if (_instance == null) _instance = new UserBLL();
                return _instance;
            }
        }

        private UserBLL() { }

        public List<User> GetUsers()
        {
            return UserDAL.GetUsers();
        }
    }
}