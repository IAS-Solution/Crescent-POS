﻿using System;
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
        //public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_level"].ToString() == "Admin")
            {
               
            }

            else if (Session["user_level"].ToString() == "Management")
            {
               
            }

            else if (Session["user_level"].ToString() == "User")
            {
                
            }
            
        }
    }
}