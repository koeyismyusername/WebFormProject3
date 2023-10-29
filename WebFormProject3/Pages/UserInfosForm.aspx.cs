using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormProject3.BLL;
using WebFormProject3.Models;

namespace WebFormProject3
{
    public partial class UserInfosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindData();
        }

        private void BindData()
        {
            UserBLL bll = UserBLL.Instance;
            List<User> users = bll.GetUsers();
            UserInfos.DataSource = users;
            UserInfos.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Console.WriteLine("hello, world");
        }
    }
}