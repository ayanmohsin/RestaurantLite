using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantLite.QT
{
    public partial class frmAmount : Form
    {
        public frmAmount()
        {
            InitializeComponent();
            _Value = "1";
        }
        string _Value = "0";
        Timer tm;
        public string Value { get { return _Value; } set { _Value = value;} }

        double _BillAmount = 0;
        public double BillAmount { set { _BillAmount = value; txtBill.Text = _BillAmount.ToString(); txtBalance.Text = _BillAmount.ToString(); } }

        private void button1_Click(object sender, EventArgs e)
        {
            tm.Enabled = false;
            Button btn = (Button)sender;
            object oAmount = btn.Text;
            double dblAmount = 0;
            if (oAmount != null)
            {
                if (oAmount.ToString() != "")
                {
                    dblAmount = Convert.ToDouble(oAmount);
                }
            }
            object oExistAmount = txtCash.Text;
            double dblExistAmount = 0;
            if (oExistAmount != null)
            {
                if (oExistAmount.ToString() != "")
                {
                    dblExistAmount = Convert.ToDouble(oExistAmount);
                }
            }
            dblExistAmount += dblAmount;

            double dblBalance = (_BillAmount - dblExistAmount);
            txtCash.Text = dblExistAmount.ToString();
            txtBalance.Text = dblBalance.ToString();
            if (dblBalance <=0)
            {
                txtBalance.BackColor = Color.Green;
            }
            else
            {
                txtBalance.BackColor = Color.Red;
            }
            tm.Enabled = true;
        }

        void tm_Tick(object sender, EventArgs e)
        {
            _Value = txtCash.Text;
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tm.Enabled = false;




            if (txtCash.Text != "")
            {
                txtCash.Text = txtCash.Text.Remove(txtCash.Text.Length - 1);    


            }
            else
            {
                _Value = "0";
                this.Close();
            }
            object oExistAmount = txtCash.Text;
            double dblExistAmount = 0;
            if (oExistAmount != null)
            {
                if (oExistAmount.ToString() != "")
                {
                    dblExistAmount = Convert.ToDouble(oExistAmount);
                }
            }
            double dblBalance = (_BillAmount - dblExistAmount);
            txtBalance.Text = (dblBalance).ToString();
            if (dblBalance <= 0)
            {
                txtBalance.BackColor = Color.Green;
            }
            else
            {
                txtBalance.BackColor = Color.Red;
            }
            tm.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tm.Enabled = false;

            object oBalance = txtBalance.Text;
            double dblBalance = 0;
            if (oBalance != null)
            {
                if (oBalance.ToString() != "")
                {
                    dblBalance = Convert.ToDouble(oBalance);
                }
            }

            if (dblBalance > 0)
            {
                return;
            }


            if (txtCash.Text =="")
            {
                _Value = "1";
            }
            else
            {
                _Value = txtCash.Text;
            }
            
            this.Close();
        }
        int _TimerInterval = 0;
        public int TimerInterval { get { return _TimerInterval; } set { _TimerInterval = value; } }
        private void frmNumber_Load(object sender, EventArgs e)
        {
            tm = new Timer();
            if (_TimerInterval != 0)
            {
              
                tm.Tick += tm_Tick;
                tm.Interval = _TimerInterval;
                tm.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
           
            txtCash.Text = txtBill.Text;
            txtBalance.Text = "0";
            if (txtCash.Text == "")
            {
                _Value = "1";
            }
            else
            {
                _Value = txtCash.Text;
            }
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }
    }
}
