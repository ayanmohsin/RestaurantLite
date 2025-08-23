using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace RestaurantLite.QT
{
    public partial class rptQT : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQT()
        {
            InitializeComponent();

        }

        private void rptQT_AfterPrint(object sender, EventArgs e)
        {
            //this.PrintDialog();
            //this.ClosePreview();
        }

        private void xrTable5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            tblTypeName.Text = "";
            tblTypeValue.Text = "";
            DataTable dtb = (DataTable)this.DataSource;
            string sQTType = Convert.ToString(dtb.Rows[0]["QTType"]);
            string sDName = Convert.ToString(dtb.Rows[0]["DName"]);
            string sTable = Convert.ToString(dtb.Rows[0]["TableNo"]);
            if (sQTType == "D")
            {
                tblTypeName.Text = "Rider";
                tblTypeValue.Text = sDName;
            }
            else if (sQTType == "DI")
            {
                tblTypeName.Text = "Table";
                tblTypeValue.Text = sTable;
            }
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTable6.Visible = false;
            DataTable dtb = (DataTable)this.DataSource;
            string sQTType = Convert.ToString(dtb.Rows[0]["QTType"]);
            string sDName = Convert.ToString(dtb.Rows[0]["DName"]);
            string sTable = Convert.ToString(dtb.Rows[0]["TableNo"]);
            double dTotalAmount = Convert.ToDouble(dtb.Rows[0]["BillAmount"]);
            double dDC = Convert.ToDouble(dtb.Rows[0]["DeliveryCharges"]);
            double TotalAmount = dTotalAmount + dDC;
            cellTotalAmount.Text = TotalAmount.ToString();
            if (sQTType == "D")
            {
                xrTable6.Visible = true;
            }
          
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void rptQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rptQTCopy rpt = new rptQTCopy();
            DataTable dtb = (DataTable)this.DataSource;
            rpt.DataSource = dtb;
            rpt.DataMember = dtb.TableName;
            xrSubreport1.ReportSource = rpt;
        }
    }
}
