using RestaurantLite.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace RestaurantLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOrderTake frm = new frmOrderTake();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            string strQuery = " Select * from Company;Select * from Customer Where Status = 'A' ";
            DataSet ds = cls.GetDataSet(strQuery, ref strError);
            if (ds.Tables[0].Rows.Count >0)
	        {
		        Company comp = new Company();
                comp.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                comp.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                comp.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                comp.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                comp.Website = ds.Tables[0].Rows[0]["Website"].ToString();
                comp.Tax = Convert.ToDecimal(ds.Tables[0].Rows[0]["Tax"].ToString());
                comp.Strn =ds.Tables[0].Rows[0]["STRN"].ToString();
                comp.CashCustomer = Convert.ToInt32(ds.Tables[0].Rows[0]["CashCustomer"].ToString());
                comp.DeliveryCustomer = Convert.ToInt32(ds.Tables[0].Rows[0]["DeliveryCustomer"].ToString());
                Company._Company = comp;
                lblCompany.Text = comp.CompanyName;
	        }
            lkpCustomer.Properties.DataSource = ds.Tables[1];
            lkpCustomer.Properties.ValueMember = "RecNo";
            lkpCustomer.Properties.DisplayMember = "Customer";
            dtTo.Value = DateTime.Now.AddDays(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPaymentReceipt frm = new frmPaymentReceipt();
            frm.Show();

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            frmPurchase frm = new frmPurchase();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmDish FRM = new frmDish();
            FRM.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void StockMenu_Click(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            string strQuery = "Select DishName as Item,Sum(case When TFlag = 'P' then Qty else -Qty end) as Stock from Tracked a ";
            strQuery += " Inner Join SetupDishes b on a.ItemId = b.RecNo Where b.isStockItem = 'true' Group by DishName having Sum(case When TFlag = 'P' then Qty else -Qty end) <> 0";
            DataSet ds = cls.GetDataSet(strQuery, ref strError);

            rptStock rpt = new rptStock();
            rpt.Parameters["CompanyName"].Value = Company._Company.CompanyName;

            rpt.RequestParameters = false;
            rpt.DataSource = ds.Tables[0];
            rpt.DataMember = ds.Tables[0].TableName;
            rpt.ShowPreview();
        }

        private void CustomerBalance_Click(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            string strQuery = "Select Customer,Sum(case When CFlag = 'D' then Amount else -Amount end) as Amount from Tracked a ";
            strQuery += " Inner Join Customer b on a.CustomerId = b.RecNo Group by Customer having Sum(case When CFlag = 'D' then Amount else -Amount end) <> 0";
            DataSet ds = cls.GetDataSet(strQuery, ref strError);

            rptCustomerBalances rpt = new rptCustomerBalances();
            rpt.Parameters["CompanyName"].Value = Company._Company.CompanyName;
     
            rpt.RequestParameters = false;
            rpt.DataSource = ds.Tables[0];
            rpt.DataMember = ds.Tables[0].TableName;
            rpt.ShowPreview();
        }

        private void SalesReport_Click(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";

            string strQuery = " Select DishName as Item,DateAdd(Day, DateDiff(Day, 0, a.TDate), 0) as TransDate,Sum(Qty) as Qty,Sum(Amount) as Amount from Tracked a ";
            strQuery += "Inner Join SetupDishes b on a.ItemId = b.RecNo ";
            strQuery += " Where a.TDate  between '@DateFrom' and '@DateTo' ";
            strQuery += " Group by DishName,DateAdd(Day, DateDiff(Day, 0, a.TDate), 0) ";
            strQuery = strQuery.Replace("@DateFrom", dtFrom.Value.ToString("dd-MMM-yyyy"));
            strQuery = strQuery.Replace("@DateTo", dtTo.Value.ToString("dd-MMM-yyyy"));


            DataSet ds = cls.GetDataSet(strQuery, ref strError);
            rptSales rpt = new rptSales();
            rpt.Parameters["CompanyName"].Value = Company._Company.CompanyName;
            //string sCriteria = lkpCustomer.Text + " " + dtFrom.Value.ToString("dd-MMM-yyyy") + " " + dtTo.Value.ToString("dd-MMM-yyyy");
            //rpt.Parameters["Criteria"].Value = sCriteria;

            rpt.RequestParameters = false;
            rpt.DataSource = ds.Tables[0];
            rpt.DataMember = ds.Tables[0].TableName;
            rpt.ShowPreview();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";

            string strQuery = "Select '@DateFrom' as TDate,'Opening Balance' as Remarks,Sum(case When CFlag = 'D' then Amount else -Amount end) as Amount from Tracked a ";
            strQuery += " Inner Join Customer b on a.CustomerId = b.RecNo Where a.CustomerId = " + lkpCustomer.EditValue;
            strQuery += " and a.TDate  < '@DateFrom' ";
            strQuery += " Union All ";
            strQuery += "Select TDate,Remarks,case When CFlag = 'D' then Amount else -Amount end as Amount from Tracked a ";
            strQuery += " Inner Join Customer b on a.CustomerId = b.RecNo Where a.CustomerId = " + lkpCustomer.EditValue;
            strQuery += " and a.TDate  between '@DateFrom' and '@DateTo' ";

            strQuery = strQuery.Replace("@DateFrom", dtFrom.Value.ToString("dd-MMM-yyyy"));
            strQuery = strQuery.Replace("@DateTo", dtTo.Value.ToString("dd-MMM-yyyy"));


            DataSet ds = cls.GetDataSet(strQuery, ref strError);
            rptLedger rpt = new rptLedger();
            rpt.Parameters["CompanyName"].Value = Company._Company.CompanyName;
            string sCriteria = lkpCustomer.Text + " " + dtFrom.Value.ToString("dd-MMM-yyyy") + " " + dtTo.Value.ToString("dd-MMM-yyyy");
            rpt.Parameters["Criteria"].Value = sCriteria;

            rpt.RequestParameters = false;
            rpt.DataSource = ds.Tables[0];
            rpt.DataMember = ds.Tables[0].TableName;
            rpt.ShowPreview();

        }




    }
  
}
