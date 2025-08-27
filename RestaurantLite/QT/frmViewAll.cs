using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmViewAll : Form
    {
        public frmViewAll()
        {
            InitializeComponent();
        }

        public string TType { get; set; }
        DataSet _DataSource;
        public DataSet DataSource { get { return _DataSource; } set { _DataSource = value; } }
        List<string> _VisibleColumns;
        public List<string> VisibleColumns { get { return _VisibleColumns; } set { _VisibleColumns = value; } }
        private void frmViewAll_Load(object sender, EventArgs e)
        {
            foreach (string item in _VisibleColumns)
            {
                GridColumn clm = new GridColumn();
                clm.FieldName = item;
                clm.Caption = item;
                clm.Name = item;
                clm.Visible = true;
                clm.OptionsColumn.AllowEdit = false;
                grdView.Columns.Add(clm);
            }

            if (TType == "QT")
            {
                GridColumn clmAmount = grdView.Columns["TotalAmount"];
                if (clmAmount != null)
                {
                    clmAmount.Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "Amount: {0:n2}");
                }
                GridColumn clmDC = grdView.Columns["DeliveryCharges"];
                if (clmDC != null)
                {
                    clmDC.Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DeliveryCharges", "DC: {0:n2}");
                }
                GridColumn clmRecNo = grdView.Columns["RecNo"];
                if (clmRecNo != null)
                {
                    clmRecNo.Summary.Add(DevExpress.Data.SummaryItemType.Count, "RecNo", "Number: {0:n}");
                }
                GridColumn clm = new GridColumn();
                clm.FieldName = "isSelect";
                clm.Caption = "Select";
                clm.Name = "isSelect";
                clm.VisibleIndex = 0;
                clm.OptionsColumn.AllowEdit = true;
                grdView.Columns.Add(clm);
                _DataSource.Tables[0].Columns.Add("isSelect", typeof(bool));
                btnReceived.Visible = true;
            }
            else if (TType == "IT")
            {
                GridColumn clmAmount = grdView.Columns["SaleRate"];
                clmAmount.OptionsColumn.AllowEdit = true;
                grdView.CellValueChanged += GrdView_CellValueChanged;

                string strError = "";
                string strQry = "Select RecNo,Category From Category";
                clsDataAccessLayer cls = new clsDataAccessLayer();
                DataSet ds = cls.GetDataSet(strQry, ref strError);

                GridColumn clmCategory = grdView.Columns["CategoryId"];
                clmCategory.OptionsColumn.AllowEdit = true;
                RepositoryItemSearchLookUpEdit repoCategory = new RepositoryItemSearchLookUpEdit();
                repoCategory.DataSource = ds.Tables[0]; // e.g. DataTable, List<Category>
                repoCategory.DisplayMember = "Category";      // column to show
                repoCategory.ValueMember = "RecNo";          // column to save
                clmCategory.ColumnEdit = repoCategory;
                grdControl.RepositoryItems.Add(repoCategory);

            }
            foreach (DataRow item in _DataSource.Tables[0].Rows)
            {
                string sStatus  = Convert.ToString(item["Status"]);
                if (sStatus == "X")
                {
                    item["TotalAmount"] = 0;
                    item["DeliveryCharges"] = 0;
                }
            }


            grdControl.DataSource = _DataSource.Tables[0];
            grdView.BestFitColumns();
            grdView.ShowingEditor += GrdView_ShowingEditor;
            grdView.OptionsView.ShowAutoFilterRow = true;
        }

        private void GrdView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdView.FocusedColumn == grdView.Columns["SaleRate"])
            {
                clsDataAccessLayer cls = new clsDataAccessLayer();
                RestaurantLite.clsDataAccessLayer.OurResult strError;

                DataRow ldr = grdView.GetDataRow(grdView.FocusedRowHandle);
                int iItemId = clsDataAccessLayer.CleanValueNew<int>(ldr["RecNo"]);
                double dSaleRate = clsDataAccessLayer.CleanValueNew<double>(ldr["SaleRate"]);

                string strQuery = $@" Update SetupDishes set SaleRate = {dSaleRate} Where RecNo in ({iItemId}) ";
                strError = cls.MultipleDML(strQuery, "", "");
            }
            if (grdView.FocusedColumn == grdView.Columns["CategoryId"])
            {
                clsDataAccessLayer cls = new clsDataAccessLayer();
                RestaurantLite.clsDataAccessLayer.OurResult strError;

                DataRow ldr = grdView.GetDataRow(grdView.FocusedRowHandle);
                int iItemId = clsDataAccessLayer.CleanValueNew<int>(ldr["RecNo"]);
                int iCategory = clsDataAccessLayer.CleanValueNew<int>(ldr["CategoryId"]);

                string strQuery = $@" Update SetupDishes set CategoryId = {iCategory} Where RecNo in ({iItemId}) ";
                strError = cls.MultipleDML(strQuery, "", "");
            }




        }

        private void GrdView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grdView.FocusedColumn == grdView.Columns["isSelect"])
            {
                DataRow roww = grdView.GetDataRow(grdView.FocusedRowHandle);
                string sStatus = clsDataAccessLayer.CleanValueNew<string>(roww["Status"]);
                if (sStatus == "X")
                {
                    e.Cancel =  true;
                    return;
                }
                bool isCashReceived = clsDataAccessLayer.CleanValueNew<bool>(roww["isCashReceived"]);
                bool isSelect = clsDataAccessLayer.CleanValueNew<bool>(roww["isSelect"]);
                if (isCashReceived)
                {
                    e.Cancel = true;
                }
            }
        }

        DataSet _SelectedData;
        public DataSet SelectedData { get { return _SelectedData; } set { _SelectedData = value; } }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            object oRecNo = grdView.GetRowCellValue(grdView.FocusedRowHandle, "RecNo");
            int iRecNo = 0;
            if (oRecNo != null)
            {
                if (oRecNo.ToString() != "")
                {
                    iRecNo = Convert.ToInt32(oRecNo);
                }
            }
            if (iRecNo > 0 )
            {
                DataSet ds = new DataSet();
                foreach (DataTable dtb in _DataSource.Tables)
                {
                    DataRow[] dr = dtb.Select(" RecNo = " + iRecNo.ToString());
                    if (dr.Count() >0)
                    {

                        DataTable dtb2 = dr.CopyToDataTable();
                        dtb2.TableName = dtb.TableName;
                        ds.Tables.Add(dtb2);
                    }
                }
                _SelectedData = ds;
                this.Close();
            }
        }

        private void grdView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridColumn clm = grdView.Columns["isCashReceived"];
            if (clm == null)
            {
                return;
            }
             GridView view = sender as GridView;
             if(view == null) return;

            if (e.RowHandle >= 0)
            {
                DataRow ldr = view.GetDataRow(e.RowHandle);
                Color cb = Color.White;
                Color cf = Color.Black;

                DevExpress.XtraGrid.Views.Base.ColumnView cview = (DevExpress.XtraGrid.Views.Base.ColumnView)sender;
                bool bisReceived = clsDataAccessLayer.CleanValueNew<bool>(ldr["isCashReceived"]);
                if (bisReceived == true)
                {
                    cb = Color.Green;
                    cf = Color.White;
                }
                e.Appearance.BackColor = cb;
                e.Appearance.ForeColor = cf;
                e.Appearance.Options.UseBackColor = true;
                string sStatus = clsDataAccessLayer.CleanValueNew<string>(ldr["Status"]);
                if (sStatus == "X")
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.Options.UseBackColor = true;
                }
            }
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            DataTable dtbDetail = (DataTable)grdControl.DataSource;
            DataRow[] ldr = dtbDetail.Select("isSelect = 'true' and isCashReceived = 'false' ");
            string sRecNo = "";
            foreach (DataRow item in ldr)
            {
                int iRecNo = clsDataAccessLayer.CleanValueNew<int>(item["RecNo"]);
                sRecNo += $"{iRecNo},";
                item["isCashReceived"] = true;
            }
            if (!string.IsNullOrEmpty(sRecNo))
            {
                sRecNo = sRecNo.Remove(sRecNo.Length - 1);
            }
            clsDataAccessLayer cls = new clsDataAccessLayer();
            RestaurantLite.clsDataAccessLayer.OurResult strError;

            string strQuery = $@"; 
                Update QTMaster set isCashReceived = 'true' Where RecNo in ({sRecNo})
                ;Delete From Tracked Where TransType = 'SAL' and RefNo in  ({sRecNo})
                ;Insert into Tracked 
                Select a.RecNo,ItemId,0,Qty,Rate,Amount,'D','S','SAL',a.TDate,'' from QTMaster a 
                Inner Join QTDetail b on a.RecNo = b.RecNo 
                Where a.RecNo  in  ({sRecNo})
                Union All
                Select a.RecNo,0,CustomerId,0,0,TotalAmount,'D','S','SAL',a.TDate,'' from QTMaster a 
                Where a.RecNo in  ({sRecNo}) and isCashReceived ='true'
            ";
             strError = cls.MultipleDML(strQuery, "", "");
            if (strError.ErrorString == "OK")
            {
                MessageBox.Show("Payment Received", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Payment Received", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
