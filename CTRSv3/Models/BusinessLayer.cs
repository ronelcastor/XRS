using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DataLayer;

namespace BusinessLayer
{
    public class Methods : DataAccess
    {
        public void loadRegion(DropDownList control)
        {
            control.Items.Clear();

            control.DataSource = FillDataTable("SELECT Distinct Region FROM [TDW].[dbo].[Cash Entry] WHERE Region IS NOT NULL", CommandType.Text);
            control.DataTextField = "Region";
            control.DataValueField = "Region";
            control.DataBind();
        }

        public void loadPeriodDate(DropDownList control)
        {
            control.Items.Clear();

            control.DataSource = FillDataTable("SELECT DISTINCT CAST(CONVERT(varchar(10),Period,101) AS DATE) Period FROM [TDW].[dbo].[Cash Entry] ORDER BY Period DESC", CommandType.Text);
            control.DataTextField = "Period";
            control.DataValueField = "Period";
            control.DataBind();
        }
    }
}