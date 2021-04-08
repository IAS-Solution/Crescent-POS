using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crescent_POS
{
    public partial class Supplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbCredit_ServerChange(object sender, EventArgs e)
        {
            //pnl1.Visible = true;
        }

        protected void cbCredi_CheckedChanged(object sender, EventArgs e)
        {
            pnl1.Visible = cbCredi.Checked;
        }
    }
}