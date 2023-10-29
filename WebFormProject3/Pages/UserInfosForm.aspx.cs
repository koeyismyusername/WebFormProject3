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
            string name = tBoxName.Text;
            string birthday = tBoxBirthday.Text;
            string phone = tBoxPhone.Text;
            string gender;
            if (radioMan.Checked) gender = "M";
            else gender = "W";

            UserBLL.Instance.InsertUser(Models.User.New(name, phone, birthday, gender));

            tBoxName.Text = string.Empty;
            tBoxBirthday.Text = string.Empty;
            tBoxPhone.Text = string.Empty;
            radioWoman.Checked = false;
            radioMan.Checked = true;

            BindData();
        }
    }
}