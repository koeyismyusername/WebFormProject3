using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormProject3.Models;

namespace WebFormProject3.DAL
{
    public class UserDAL
    {
        private UserDAL() { }
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                User.Of(1, "홍길동", "010-1234-5678", "1996-11-11", DateTime.Now, null, null),
                User.Of(2, "유관순", "010-5184-7946", "2000-10-23", DateTime.Now, null, null),
                User.Of(3, "이순신", null, "1990-08-05", DateTime.Now, null, null),
                User.Of(4, "봉준호", "010-7413-9874", "2005-04-22", DateTime.Now, null, null),
                User.Of(5, "안중근", "010-1596-6521", "1995-07-24", DateTime.Now, null, null),
            };
        }
    }
}