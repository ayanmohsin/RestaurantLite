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
    public partial class frmDish : Form
    {
        public frmDish()
        {
            InitializeComponent();
        }

        DataSet _DataSource;
        int _RecNo = 0;
        public int RecNo { get { return _RecNo; } set { _RecNo = value; } }

        public DataSet DataSource { get { return _DataSource; } set { _DataSource = value; } }
      
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
                _DataSource.Tables[0].Rows[0]["DishName"] = "";
                _DataSource.Tables[0].Rows[0]["SaleRate"] = 0;
                _DataSource.Tables[0].Rows[0]["isStockItem"] = false;
                _DataSource.Tables[0].Rows[0]["TDate"] = DateTime.Now;
            }
            txtDishName.Focus();
        }
        private void PopulateCustomer()
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            DataSet ds = cls.GetDataSet("Select * from Category ", ref strError);
            lkpCategory.Properties.DataSource = ds.Tables[0];
            lkpCategory.Properties.ValueMember = "RecNo";
            lkpCategory.Properties.DisplayMember = "Category";
        }
        private void frmDish_Load(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            DataSet dsMaster = cls.GetDataSet("Select * from SetupDishes Where 1=2", ref strError);
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
            if (txtDishName.DataBindings.Count > 0)
            {
                txtDishName.DataBindings.Clear();
            }
            if (numSaleRate.DataBindings.Count > 0)
            {
                numSaleRate.DataBindings.Clear();
            }
            if (checkBox1.DataBindings.Count > 0)
            {
                checkBox1.DataBindings.Clear();
            }
            if (lkpCategory.DataBindings.Count > 0)
            {
                lkpCategory.DataBindings.Clear();
            }
            txtRecNo.DataBindings.Add("Text", ds.Tables[0], "RecNo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDishName.DataBindings.Add("Text", ds.Tables[0], "DishName", true, DataSourceUpdateMode.OnPropertyChanged);
            numSaleRate.DataBindings.Add("Text", ds.Tables[0], "SaleRate", true, DataSourceUpdateMode.OnPropertyChanged);
            checkBox1.DataBindings.Add("checked", ds.Tables[0], "isStockItem", true, DataSourceUpdateMode.OnPropertyChanged);
            lkpCategory.DataBindings.Add("EditValue", ds.Tables[0], "CategoryId", true, DataSourceUpdateMode.OnPropertyChanged);
       
        }

        private string ReplaceString(string strQuery)
        {
            strQuery = strQuery.Replace("@DishName", _DataSource.Tables[0].Rows[0]["DishName"].ToString());
            strQuery = strQuery.Replace("@SaleRate", _DataSource.Tables[0].Rows[0]["SaleRate"].ToString());
            strQuery = strQuery.Replace("@isStockItem", _DataSource.Tables[0].Rows[0]["isStockItem"].ToString());
            strQuery = strQuery.Replace("@TDate", _DataSource.Tables[0].Rows[0]["TDate"].ToString());
            strQuery = strQuery.Replace("@CategoryId", _DataSource.Tables[0].Rows[0]["CategoryId"].ToString());
       
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
                strQuery += " Insert into SetupDishes(DishName,SaleRate,isStockItem,TDate,Status,CategoryId) values ";
                strQuery += " ('@DishName','@SaleRate','@isStockItem','@TDate','A',@CategoryId)";
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
                    string strqry = "Select Max(RecNo) from SetupDishes";
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
                strQuery += " Update SetupDishes set DishName='@DishName',SaleRate='@SaleRate',isStockItem='@isStockItem'";
                strQuery += " Where RecNo = @RecNo";
                strQuery = ReplaceString(strQuery);
            }
         
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
            DataSet ds = cls.GetDataSet("Select a.* from SetupDishes a  order by RecNo desc", ref strError);
            frmViewAll frm = new frmViewAll();
            frm.TType = "IT";
            frm.DataSource = ds;
            List<string> lstColumns = new List<string>();
            lstColumns.Add("RecNo");
            lstColumns.Add("DishName");
            lstColumns.Add("SaleRate");
            lstColumns.Add("isStockItem");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_RecNo != 0)
            {
                clsDataAccessLayer cls = new clsDataAccessLayer();
                RestaurantLite.clsDataAccessLayer.OurResult strError;
                string strQuery = " Update SetupDishes set Status='X' ";
                strQuery += " Where RecNo = " + _RecNo.ToString() ;
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

        private void lkpCategory_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            RestaurantLite.clsDataAccessLayer.OurResult strError;


            string strFilterValue = lkpCategory.Properties.View.FindFilterText;
            if (strFilterValue != "")
            {
                DialogResult dr = MessageBox.Show("are you sure to Generate New Customer.", "Customer", MessageBoxButtons.OKCancel);
                if ((DialogResult.OK == dr))
                {
                    string strQuery = " Insert into Category(Category)values('" + strFilterValue + "') ";
                    strError = cls.MultipleDML(strQuery, "", "");
                    if (strError.ErrorString != "OK")
                    {
                        MessageBox.Show(strError.ErrorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    PopulateCustomer();
                    string lstrEr = "";

                    DataTable dtb = (DataTable)lkpCategory.Properties.DataSource;

                    object objItemId = dtb.Compute("Max([RecNo])", string.Empty);
                    int ItemId = 0;
                    if (objItemId != null)
                    {
                        if (objItemId.ToString() != "")
                        {
                            ItemId = Convert.ToInt32(objItemId);
                        }
                    }
                    lkpCategory.EditValue = ItemId;
                }
            }
        }

        private void numSaleRate_Enter(object sender, EventArgs e)
        {
            numSaleRate.Select(0, numSaleRate.Value.ToString().Length);
        }

   
    }
}
