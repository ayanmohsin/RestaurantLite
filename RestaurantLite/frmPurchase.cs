using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmPurchase : Form
    {
        public frmPurchase()
        {
            InitializeComponent();
        }
        DataSet _DataSource;
        int _RecNo = 0;
        public int RecNo { get { return _RecNo; } set { _RecNo = value; } }

        public DataSet DataSource { get { return _DataSource; } set { _DataSource = value; } }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            DataSet ds = cls.GetDataSet("Select * from SetupDishes Where isStockItem = 'true' and Status = 'A';Select * from Customer Where Status = 'A'", ref strError);
            DataSet dsMaster = cls.GetDataSet("Select * from PurchaseMaster Where 1=2;Select * from PurchaseDetail Where 1=2", ref strError);
            _DataSource = dsMaster;
            repItem.DataSource = ds.Tables[0].Copy();
            repItem.DisplayMember = "DishName";
            repItem.ValueMember = "RecNo";
            BindData(dsMaster);
            ClearAll();
            lkpCustomer.Properties.DataSource = ds.Tables[1];
            lkpCustomer.Properties.ValueMember = "RecNo";
            lkpCustomer.Properties.DisplayMember = "Customer";
            lkpCustomer.EditValue = Company._Company.CashCustomer;
        }
        private void grdDetailView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
          
                SendKeys.Send("{DOWN}");
                object objQuantity = grdDetailView.GetRowCellValue(e.RowHandle, clmQty);
                object objRate = grdDetailView.GetRowCellValue(e.RowHandle, clmRate);

                decimal decQuantity = 0;
                decimal decRate = 0;

                if (objQuantity != null)
                {
                    if (objQuantity.ToString() != "")
                    {
                        decQuantity = Convert.ToDecimal(objQuantity);
                    }
                }
                if (objRate != null)
                {
                    if (objRate.ToString() != "")
                    {
                        decRate = Convert.ToDecimal(objRate);
                    }
                }
                if (e.Column == clmQty || e.Column == clmRate)
                {
                    grdDetailView.SetRowCellValue(e.RowHandle, clmAmount, (decQuantity * decRate));
                }
            
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
                _DataSource.Tables[1].Rows.Add();
                _DataSource.Tables[0].Rows[0]["RecNo"] = 0;
                _DataSource.Tables[0].Rows[0]["Status"] = "A";
                _DataSource.Tables[0].Rows[0]["CustomerId"] = Company._Company.CashCustomer;
            
            }
        }

        private void BindData(DataSet ds)
        {

            grdDetailControl.DataSource = ds.Tables[1];
            if (txtRecNo.DataBindings.Count > 0)
            {
                txtRecNo.DataBindings.Clear();
            }
        
            if (lkpCustomer.DataBindings.Count > 0)
            {
                lkpCustomer.DataBindings.Clear();
            }
          
            txtRecNo.DataBindings.Add("Text", ds.Tables[0], "RecNo", true, DataSourceUpdateMode.OnPropertyChanged);
            lkpCustomer.DataBindings.Add("EditValue", ds.Tables[0], "CustomerId", true, DataSourceUpdateMode.OnPropertyChanged);
       }
   
        private void PopulateCustomer()
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            DataSet ds = cls.GetDataSet("Select * from Customer Where Status = 'A'", ref strError);
            lkpCustomer.Properties.DataSource = ds.Tables[0];
            lkpCustomer.Properties.ValueMember = "RecNo";
            lkpCustomer.Properties.DisplayMember = "Customer";
        }

        private bool SaveRecord()
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            int iRecNo = _RecNo;
            RestaurantLite.clsDataAccessLayer.OurResult strError;

            string strQuery = "";
            if (iRecNo == 0)
            {
                strQuery += " Insert into PurchaseMaster(CustomerId,Status,TDate) values ";
                strQuery += " (@CustomerId,'A','"+ DateTime.Now +"')";
                strQuery = strQuery.Replace("@CustomerId", _DataSource.Tables[0].Rows[0]["CustomerId"].ToString());
       
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
                    string strqry = "Select Max(RecNo) from PurchaseMaster";
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
                strQuery += " Update PurchaseMaster set CustomerId='@CustomerId'";
                strQuery += " Where RecNo = @RecNo";
                strQuery += " ;Delete From  PurchaseDetail Where RecNo = @RecNo";
                strQuery = strQuery.Replace("@CustomerId", _DataSource.Tables[0].Rows[0]["CustomerId"].ToString());
            }

            int i = 0;
            foreach (DataRow dr in _DataSource.Tables[1].Rows)
            {
                strQuery += ";Insert into PurchaseDetail(RecNo,Sno,ItemId,Qty,Rate,Amount) values ";
                strQuery += " (@RecNo,@Sno,@ItemId,@Qty,@Rate,@Amount) ";
                strQuery = strQuery.Replace("@Sno", i.ToString());
                strQuery = strQuery.Replace("@ItemId", _DataSource.Tables[1].Rows[i]["ItemId"].ToString());
                strQuery = strQuery.Replace("@Rate", _DataSource.Tables[1].Rows[i]["Rate"].ToString());
                strQuery = strQuery.Replace("@Amount", _DataSource.Tables[1].Rows[i]["Amount"].ToString());
                strQuery = strQuery.Replace("@Qty", _DataSource.Tables[1].Rows[i]["Qty"].ToString());
                
                i += 1;
            }
            strQuery += "; Delete From Tracked Where TransType = 'PUR' and RefNo = @RecNo";
            strQuery += "; Insert into Tracked ";
            strQuery += " Select a.RecNo,ItemId,CustomerId,Qty,Rate,Amount,'C','P','PUR',a.TDate,c.DishName + ' ' + cast(b.Qty as nvarchar(10)) + ' X ' + cast(b.Rate as nvarchar(10)) from PurchaseMaster a ";
            strQuery += " Inner Join PurchaseDetail b on a.RecNo = b.RecNo ";
            strQuery += " Inner Join SetupDishes c on b.ItemId = c.RecNo ";
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
        private string GenerateRemarks(DataTable dtbDetail)
        {
            string strRemarks = "";
            foreach (DataRow dr in dtbDetail.Rows)
            {
                object oItemId = dr["ItemId"];
                int iItemId = 0;
                if (oItemId != null)
                {
                    if (oItemId.ToString() != "")
                    {
                        iItemId = Convert.ToInt32(oItemId);
                    }
                }
                object oQty = dr["Qty"];
                double dQty = 0;
                if (oQty != null)
                {
                    if (oQty.ToString() != "")
                    {
                        dQty = Convert.ToDouble(oQty);
                    }
                }
                object oRate = dr["Rate"];
                double dRate = 0;
                if (oRate != null)
                {
                    if (oRate.ToString() != "")
                    {
                        dRate = Convert.ToDouble(oRate);
                    }
                }
                DataTable dtb = (DataTable)repItem.DataSource;
                DataRow[] dr2 = dtb.Select("RecNo  = " + iItemId.ToString());
                string strItem = "";
                if (dr2.Count() >0)
                {
                    strItem = dr2[0]["DishName"].ToString();
                }

                strRemarks += strItem + " " + dQty.ToString() + " X " + dRate.ToString() + " = " + (dQty*dRate).ToString("n0") + "||";
            }



            return strRemarks; 
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
        private void AddNewRow(int iRowHandle)
        {
            grdDetailControl.Focus();
            grdDetailView.UpdateCurrentRow();
            grdDetailView.AddNewRow();
            grdDetailView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
            grdDetailView.FocusedColumn = clmItem;
            grdDetailView.ShowEditor();
            //     (grdDetailView.ActiveEditor as SearchLookUpEdit).ShowPopup();
            grdDetailView.SetRowCellValue(iRowHandle, clmAmount, "0");
            grdDetailView.SetRowCellValue(iRowHandle, clmRate, "0");
        }

        private void grdViewDetail_KeyDown(object sender, KeyEventArgs e)
        {
                GridView view = (GridView)(sender);
                GridColumn lastCol = clmAmount;
                if (view.FocusedRowHandle == view.RowCount - 1 && view.FocusedColumn == lastCol && e.KeyCode == Keys.Enter)
                {
                    AddNewRow(view.FocusedRowHandle + 1);
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Delete)
                {
                    view.DeleteRow(view.FocusedRowHandle);
                }
        }
   
        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            SaveRecord();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            DataSet ds = cls.GetDataSet("Select a.*,b.Customer from PurchaseMaster a Left Outer Join Customer b on a.CustomerId =b.RecNo Where a.Status = 'A' order by RecNo desc;Select * from Purchasedetail", ref strError);
            frmViewAll frm = new frmViewAll();
            frm.DataSource = ds;
            List<string> lstColumns = new List<string>();
            lstColumns.Add("RecNo");
            lstColumns.Add("Customer");
           
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

        private void bClearAll_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_RecNo != 0)
            {
                clsDataAccessLayer cls = new clsDataAccessLayer();
                RestaurantLite.clsDataAccessLayer.OurResult strError;
                string strQuery = " Update PurchaseMaster set Status='X' ";
                strQuery += " Where RecNo = " + _RecNo.ToString();
                strQuery += "; Delete From Tracked Where TransType = 'PUR' and RefNo = " + _RecNo.ToString();
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
