using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantLite
{
    public partial class frmQTCashReceipt : Form
    {
        public frmQTCashReceipt()
        {
            InitializeComponent();
        }
        DataSet _DataSource;
        bool _isSuccess = false;
        public bool isSuccess { get { return _isSuccess; } set { _isSuccess = value; } }
        public DataSet DataSource { get { return _DataSource; } set { _DataSource = value; } }

        private void frmQTCashReceipt_Load(object sender, EventArgs e)
        {
            
            numBillAmount.DataBindings.Add("Value", _DataSource.Tables[0], "BillAmount", true);
            numTaxPercentage.DataBindings.Add("Value", _DataSource.Tables[0], "TaxPer", true);
            numTaxAmount.DataBindings.Add("Value", _DataSource.Tables[0], "TaxAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            numDiscount.DataBindings.Add("Value", _DataSource.Tables[0], "Discount", true, DataSourceUpdateMode.OnPropertyChanged);
            numCashReceipt.DataBindings.Add("Value", _DataSource.Tables[0], "CashReceipt", true, DataSourceUpdateMode.OnPropertyChanged);
            numBalance.DataBindings.Add("Value", _DataSource.Tables[0], "Balance", true, DataSourceUpdateMode.OnPropertyChanged);
            numTotalAmount.DataBindings.Add("Value", _DataSource.Tables[0], "TotalAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            numCashReceipt.Focus();
            Calculate();
        }

        private void Calculate()
        {
            decimal dBillAmount = numBillAmount.Value;
            decimal dTaxAmount = numTaxAmount.Value;
            decimal dDiscount = numDiscount.Value;
            decimal dCashReceipt = numCashReceipt.Value;
            decimal dTotalAmount = numTotalAmount.Value;

            decimal dTotalAmount2 = ((dBillAmount + dTaxAmount) - dDiscount);
            if (dTotalAmount2 >=0)
            {
                numTotalAmount.Value = dTotalAmount2;
        
            }
            else
            {
                numTotalAmount.Value = 0;
            }
       
            decimal dBalance=dCashReceipt-((dBillAmount + dTaxAmount) - dDiscount);
            if (dBalance <0)
	        {
	        	   numBalance.Value = 0;
	        }
            else
            {
                numBalance.Value = dBalance;
            }

          
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            numCashReceipt.Value = numTotalAmount.Value;
            Calculate();

            decimal dCashReceipt = numCashReceipt.Value;
            decimal dTotalAmount = numTotalAmount.Value;
            if (dCashReceipt < dTotalAmount)
            {
                numCashReceipt.Focus();
            }
            else
            {
                _isSuccess = true;
                this.Close();
            }
            
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void numCashReceipt_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void numTaxAmount_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void frmQTCashReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void numCashReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
      
        }

        private void numCashReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                decimal dCashReceipt = numCashReceipt.Value;
                decimal dTotalAmount = numTotalAmount.Value;
                if (dCashReceipt< dTotalAmount)
                {
                    numCashReceipt.Focus();
                }
                else
                {
                    btnSave.Focus();
                }
            }
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
