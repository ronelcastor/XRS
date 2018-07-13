using System;
using System.Collections.Generic;
using System.Data;
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
        decimal essValue = 0;
        decimal submissionValue = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                method.loadRegion(this.ddlRegion);
                method.loadPeriodDate(this.ddlPeriod);
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            method.loadTemplate(this.ddlTemplate, this.ddlRegion.SelectedValue);
        }

        private void computeTotal()
        {
            essValue = 0;
            submissionValue = 0;

            DataTable dt = ((DataView)sdsReport.Select(DataSourceSelectArguments.Empty)).Table;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                essValue += Convert.ToDecimal(dt.Rows[i]["ESS"].ToString());
                submissionValue += Convert.ToDecimal(dt.Rows[i]["Submission"].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                this.lvReport.FindControl("ESSSumLabel");
                Label ESSSum = (Label)lvReport.FindControl("ESSSumLabel");
                Label SubmissionSum = (Label)lvReport.FindControl("SubmissionSumLabel");

                ESSSum.Text = string.Format("{0:#,0.00}", essValue);
                SubmissionSum.Text = string.Format("{0:#,0.00}", submissionValue);
            }
        }

        protected void lvReport_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                this.computeTotal();
            }
        }

    }
}