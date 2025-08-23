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
    public partial class DeliveryForm : Form
    {


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public DeliveryForm()
        {
            InitializeComponent();
        }
        public DataSet DataSource { get { return _DataSource; } set { _DataSource = value; } }
        DataSet _DataSource;
        Dictionary<string, string> nameMobileDict = new Dictionary<string, string>();

        private void LoadAutoCompleteData()
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();

            string strQuery = @"
                    
                    SELECT DName, DMobile
                    FROM QTMaster
                    GROUP BY  DName, DMobile
               
            ";

            DataSet ds = cls.GetDataSet(strQuery, ref strError);

            nameMobileDict.Clear();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string dName = row["DName"].ToString();
                    string dMobile = row["DMobile"].ToString();
                    // Show both in autocomplete
                    autoCompleteData.Add($"{dName} ({dMobile})");
                    // Keep mapping (for lookup later)
                    if (!nameMobileDict.ContainsKey(dName))
                        nameMobileDict.Add(dName, dMobile);
                }
            }
            txtDeliveryBoy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDeliveryBoy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDeliveryBoy.AutoCompleteCustomSource = autoCompleteData;
        }

        private void DeliveryForm_Load(object sender, EventArgs e)
        {
          
            txtName.DataBindings.Add("Text", _DataSource.Tables[0], "CName", true);
            txtMobile.DataBindings.Add("Text", _DataSource.Tables[0], "CMobile", true);
            txtAddress.DataBindings.Add("Text", _DataSource.Tables[0], "CAddress", true);
            txtDeliveryBoy.DataBindings.Add("Text", _DataSource.Tables[0], "DName", true);
            txtDMobile.DataBindings.Add("Text", _DataSource.Tables[0], "DMobile", true);
            txtMobile.Focus();
            LoadAutoCompleteData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string input = txtDeliveryBoy.Text;
            if (input.Contains("("))
            {
                input = input.Substring(0, input.IndexOf("(")).Trim();
            }
            if (nameMobileDict.ContainsKey(input))
            {
                DataSource.Tables[0].Rows[0]["DName"] = input;
                DataSource.Tables[0].Rows[0]["DMobile"] = nameMobileDict[input];
                txtDMobile.Text = nameMobileDict[input];
                txtDeliveryBoy.Text = input;
            }
            string strerror = "";
            if (txtDeliveryBoy.Text =="")
            {
                strerror += "Delivery Boy Name must be Enter\n";
            }
            if (txtDMobile.Text == "")
            {
                strerror += "Delivery Boy Mobile must be Enter\n";
            }
            if (txtName.Text == "")
            {
                strerror += "Customer must be Enter\n";
            }
            if (txtAddress.Text == "")
            {
                strerror += "Address must be Enter\n";
            }
            if (txtMobile.Text == "")
            {
                strerror += "Mobile must be Enter\n";
            }
            if (strerror != "")
            {
                MessageBox.Show(strerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                clsDataAccessLayer cls = new clsDataAccessLayer();
                string strError = "";
                if (txtMobile.Text.Length ==11)
                {
                    string strQuery = $@"Select Top 1 * from 
                                        QTMaster Where CMobile = '{txtMobile.Text}'
                                        order by RecNo desc
                                        ";
                    DataSet ds = cls.GetDataSet(strQuery, ref strError);
                    if (strError == "OK")
                    {
                        if (ds.Tables[0].Rows.Count >0)
                        {
                            DataRow ldr = ds.Tables[0].Rows[0];
                            string sAddress = ldr["CAddress"].ToString();
                            string sName = ldr["CName"].ToString();
                            txtName.Text = sName;
                            txtAddress.Text = sAddress;
                        }
                    }
                    txtName.Focus();
                }
                else
                {
                    MessageBox.Show("Invalid Mobile Number!","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtMobile.Text = "";
                  
                }
            }
        }

        private void txtDMobile_Leave(object sender, EventArgs e)
        {
                // Get only name part (if user selects "Rafeeq (03001234567)")
                string input = txtDeliveryBoy.Text;
                if (input.Contains("("))
                {
                    input = input.Substring(0, input.IndexOf("(")).Trim();
                }
                if (nameMobileDict.ContainsKey(input))
                {
                    DataSource.Tables[0].Rows[0]["DName"] = input;
                    DataSource.Tables[0].Rows[0]["DMobile"] = nameMobileDict[input];
                }
        }
    }
}
