using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crescent_POS
{
    public partial class POS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Showdate();
            ShowTime();
        }

        public void Showdate()
        {
            DateTime date = DateTime.Now;
            lblDate.Text = date.ToString("MM/dd/yyyy");
        }

        public void ShowTime()
        {
            DateTime time = DateTime.Now;
        }
    }
}