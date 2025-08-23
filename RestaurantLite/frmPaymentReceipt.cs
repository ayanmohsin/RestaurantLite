using RestaurantLite.QT;
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
    public partial class frmPaymentReceipt : Form
    {
        public frmPaymentReceipt()
        {
            InitializeComponent();
        }
        DataSet _DataSource;
        int _RecNo = 0;
        public int RecNo { get { return _RecNo; } set { _RecNo = value; } }

        public DataSet DataSource { get { return _DataSource; } set { _DataSource = value; } }
        private void PopulateCustomer()
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            DataSet ds = cls.GetDataSet("Select * from Customer Where RecNo  <> " + Company._Company.CashCustomer + " and Status = 'A' ", ref strError);
            lkpCustomer.Properties.DataSource = ds.Tables[0];
            lkpCustomer.Properties.ValueMember = "RecNo";
            lkpCustomer.Properties.DisplayMember = "Customer";
        }
        private void ClearAll()
        {
            foreach (DataTable dtb in _DataSource.Tables)
            {
                dtb.Rows.Clear();
            }

            RecNo = 0;
            if (_RecNo == 0)
            {
                _DataSource.Tables[0].Rows.Add();
                _DataSource.Tables[0].Rows[0]["RecNo"] = 0;
                _DataSource.Tables[0].Rows[0]["Remarks"] = "";
                _DataSource.Tables[0].Rows[0]["CustomerId"] = 0;
                _DataSource.Tables[0].Rows[0]["PaymentReceipt"] = "R";
                _DataSource.Tables[0].Rows[0]["Amount"] = 0;
                _DataSource.Tables[0].Rows[0]["TDate"] =DateTime.Now;
             }
            
        }

        private void frmPaymentReceipt_Load(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            DataSet dsMaster = cls.GetDataSet("Select * from PaymentReceipt Where 1=2", ref strError);
            _DataSource = dsMaster;
            BindData(_DataSource);
            PopulateCustomer();
            ClearAll();
        }
        private void BindData(DataSet ds)
        {

            if (txtRecNo.DataBindings.Count > 0)
            {
                txtRecNo.DataBindings.Clear();
            }
            if (txtRemarks.DataBindings.Count > 0)
            {
                txtRemarks.DataBindings.Clear();
            }
            if (numAmount.DataBindings.Count > 0)
            {
                numAmount.DataBindings.Clear();
            }
            if (lkpCustomer.DataBindings.Count > 0)
            {
                lkpCustomer.DataBindings.Clear();
            }
            txtRecNo.DataBindings.Add("Text", ds.Tables[0], "RecNo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtRemarks.DataBindings.Add("Text", ds.Tables[0], "Remarks", true, DataSourceUpdateMode.OnPropertyChanged);
            numAmount.DataBindings.Add("Value", ds.Tables[0], "Amount", true, DataSourceUpdateMode.OnPropertyChanged);
            lkpCustomer.DataBindings.Add("EditValue", ds.Tables[0], "CustomerId", true, DataSourceUpdateMode.OnPropertyChanged);
            rdoPaymentType.DataBindings.Add("EditValue", ds.Tables[0], "PaymentReceipt", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private string ReplaceString(string strQuery)
        {
            strQuery = strQuery.Replace("@Remarks", _DataSource.Tables[0].Rows[0]["Remarks"].ToString());
            strQuery = strQuery.Replace("@Amount", _DataSource.Tables[0].Rows[0]["Amount"].ToString());
            strQuery = strQuery.Replace("@CustomerId", _DataSource.Tables[0].Rows[0]["CustomerId"].ToString());
            strQuery = strQuery.Replace("@TDate", _DataSource.Tables[0].Rows[0]["TDate"].ToString());
            strQuery = strQuery.Replace("@PaymentReceipt", _DataSource.Tables[0].Rows[0]["PaymentReceipt"].ToString());
            return strQuery;
        }

        private bool SaveRecord()
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            int iRecNo = _RecNo;
            RestaurantLite.clsDataAccessLayer.OurResult strError;

            string strQuery = "";
         
            if (iRecNo == 0)
            {
                strQuery += " Insert into PaymentReceipt(CustomerId,Remarks,Amount,TDate,PaymentReceipt,Status) values ";
                strQuery += " (@CustomerId,'@Remarks',@Amount,'@TDate','@PaymentReceipt','A')";
                strQuery = ReplaceString(strQuery);
                strError = cls.MultipleDML(strQuery, "", "");
                strQuery = "";
                if (strError.ErrorString != "OK")
                {
                    MessageBox.Show(strError.ErrorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    string lstrError = "";
                    string strqry = "Select Max(RecNo) from PaymentReceipt";
                    DataSet ds = cls.GetDataSet(strqry, ref lstrError);
                    if (lstrError != "OK")
                    {
                        MessageBox.Show(lstrError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        object oOrderNo = ds.Tables[0].Rows[0][0];
                        if (oOrderNo != null)
                        {
                            if (oOrderNo.ToString() != "")
                            {
                                iRecNo = Convert.ToInt32(oOrderNo);
                            }
                        }
                    }

                }
            }
            else
            {
                strQuery += " Update PaymentReceipt set CustomerId='@CustomerId',Remarks='@Remarks',Amount=@Amount";
                strQuery += ",PaymentReceipt='@PaymentReceipt' Where RecNo = @RecNo";
                strQuery = ReplaceString(strQuery);
            }
            strQuery += "; Delete From Tracked Where TransType = 'PYRE' and RefNo = @RecNo";
            strQuery += "; Insert into Tracked ";
            strQuery += " Select a.RecNo,0,CustomerId,0,0,Amount,case When PaymentReceipt = 'P' then 'D' else 'C' end";
            strQuery += " ,'S','PYRE',a.TDate,a.Remarks from PaymentReceipt a ";
            strQuery += " Where a.RecNo = " + iRecNo.ToString() + "  ";


            strQuery = strQuery.Replace("@RecNo", iRecNo.ToString());
            strError = cls.MultipleDML(strQuery, "", "");
            if (strError.ErrorString != "OK")
            {
                MessageBox.Show(strError.ErrorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ClearAll();
            return true;

        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            SaveRecord();
        }

        private void bClearAll_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            DataSet ds = cls.GetDataSet("Select a.*,b.Customer from PaymentReceipt a Left Outer Join Customer b on a.CustomerId =b.RecNo Where a.Status = 'A' order by RecNo desc", ref strError);
            frmViewAll frm = new frmViewAll();
            frm.DataSource = ds;
            List<string> lstColumns = new List<string>();
            lstColumns.Add("RecNo");
            lstColumns.Add("Customer");
            lstColumns.Add("PaymentReceipt");
            lstColumns.Add("Amount");
            frm.VisibleColumns = lstColumns;
            frm.ShowDialog();
            if (frm.SelectedData != null)
            {
                foreach (DataTable dtb in frm.SelectedData.Tables)
                {
                    _DataSource.Tables[dtb.TableName].Rows.Clear();
                    foreach (DataRow dr in dtb.Rows)
                    {
                        _DataSource.Tables[dtb.TableName].ImportRow(dr);
                    }
                }
                RecNo = Convert.ToInt32(frm.SelectedData.Tables[0].Rows[0]["RecNo"]);
            }
        }

        private void lkpCustomer_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
        {
            
            clsDataAccessLayer cls = new clsDataAccessLayer();
            RestaurantLite.clsDataAccessLayer.OurResult strError;

       
            string strFilterValue = lkpCustomer.Properties.View.FindFilterText;
            if (strFilterValue != "")
            {
                DialogResult dr = MessageBox.Show("are you sure to Generate New Customer.", "Customer", MessageBoxButtons.OKCancel);
                if ((DialogResult.OK == dr))
                {
                    string strQuery = " Insert into Customer(Customer,Status)values('" + strFilterValue + "','A') ";
                    strError = cls.MultipleDML(strQuery, "", "");
                    if (strError.ErrorString != "OK")
                    {
                        MessageBox.Show(strError.ErrorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    PopulateCustomer();
                    string lstrEr = "";

                    DataTable dtb = (DataTable)lkpCustomer.Properties.DataSource;

                    object objItemId = dtb.Compute("Max([RecNo])", string.Empty);
                    int ItemId = 0;
                    if (objItemId != null)
                    {
                        if (objItemId.ToString() != "")
                        {
                            ItemId = Convert.ToInt32(objItemId);
                        }
                    }
                    lkpCustomer.EditValue = ItemId;
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_RecNo != 0)
            {
                clsDataAccessLayer cls = new clsDataAccessLayer();
                RestaurantLite.clsDataAccessLayer.OurResult strError;
                string strQuery = " Update PaymentReceipt set Status='X' ";
                strQuery += " Where RecNo = " + _RecNo.ToString();
                strQuery += "; Delete From Tracked Where TransType = 'PYRE' and RefNo = " + _RecNo.ToString();
                strError = cls.MultipleDML(strQuery, "", "");
                if (strError.ErrorString != "OK")
                {
                    MessageBox.Show(strError.ErrorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Record Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
    
        }
    
    }
}
