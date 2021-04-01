using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Crescent_POS
{
    public partial class Home : System.Web.UI.MasterPage
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_level"].ToString() == "Admin")
            {
                //gembakaizenrequest.Visible = true;
                //userregistration.Visible = true;
                //lbladmin.Visible = true;
                //frmKaizenUser.Visible = false;

            }

            else if (Session["user_level"].ToString() == "Management")
            {
                //gembakaizenrequest.Visible = false;
                //userregistration.Visible = false;
                //lbladmin.Visible = false;
                //frmKaizenUser.Visible = false;
                //frmKaizenAdmin.Visible = false;
            }

            else if (Session["user_level"].ToString() == "User")
            {
                //gembakaizenrequest.Visible = false;
                //userregistration.Visible = false;
                //lbladmin.Visible = false;
                //frmManagement.Visible = false;
                //frmKaizen.Visible = false;
                //frmKaizenAdmin.Visible = false;
            }
            lblfullname.Text = Session["full_name"].ToString();
        }
    }
}