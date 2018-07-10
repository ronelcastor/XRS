using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace CTRSv3
{
    public partial class WebFormCashTaxReport : System.Web.UI.Page
    {
        Methods method = new Methods();
        protected void Page_Load(object sender, EventArgs e)
        {
            method.loadRegion(this.ddlRegion);
            method.loadPeriodDate(this.ddlPeriod);
        }
    }
}