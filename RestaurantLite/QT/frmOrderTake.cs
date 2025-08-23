using DevExpress.XtraEditors;
using RestaurantLite.QT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace RestaurantLite
{
    public partial class frmOrderTake : Form
    {

        private System.Windows.Forms.Timer searchTimer;

        decimal dblTax = Company._Company.Tax;
        public frmOrderTake()
        {
            InitializeComponent();
            // Initialize the timer
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 700; // Delay in milliseconds
            searchTimer.Tick += SearchTimer_Tick;
        }
        private void Calculate()
        {
            grdDetailView.UpdateSummary();
            object objSumAmount = grdDetailView.Columns["Amount"].SummaryText;
            decimal decSumAmount = 0;

            if (objSumAmount != null)
            {
                if (objSumAmount.ToString() != "")
                {
                    decSumAmount = Convert.ToDecimal(objSumAmount);
                }
            }
            decimal decDiscount = 0;
            object oDiscount = _DataSource.Tables[0].Rows[0]["Discount"];
            if (oDiscount != null)
            {
                if (oDiscount.ToString() != "")
                {
                    decDiscount = Convert.ToDecimal(oDiscount);
                }
            }
            lblTotal.Text = "Net Amount " + decSumAmount.ToString("N0");
            decimal dTax = Math.Round((decSumAmount * (dblTax / 100)), 0);
            lblTax.Text = "Tax " + dTax.ToString("N0");
            lblNet.Text = (decSumAmount + dTax).ToString("N0");
            _DataSource.Tables[0].Rows[0]["NetAmount"] = decSumAmount;
            _DataSource.Tables[0].Rows[0]["BillAmount"] = decSumAmount;
            _DataSource.Tables[0].Rows[0]["TotalAmount"] = ((decSumAmount + dTax) - decDiscount);
            _DataSource.Tables[0].Rows[0]["TaxAmount"] = dTax;
            _DataSource.Tables[0].Rows[0]["TaxPer"] = dblTax;

        }

        DataSet _DataSource;
        int _RecNo = 0;
        public int RecNo { get { return _RecNo; } set { _RecNo = value; } }

        public DataSet DataSource { get { return _DataSource; } set { _DataSource = value; } }

        private int GetOrderNo()
        {
            int iOrder = 0;
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            string strqry = "Select Max(OrderNo) from QTMaster Where CONVERT(nvarchar(11), TDAte)  = '" + DateTime.Now.ToString("MMM dd yyyy") + "'";
            DataSet ds = cls.GetDataSet(strqry, ref strError);
            if (ds.Tables[0].Rows.Count > 0)
            {
                object oOrderNo = ds.Tables[0].Rows[0][0];
                if (oOrderNo != null)
                {
                    if (oOrderNo.ToString() != "")
                    {
                        iOrder = Convert.ToInt32(oOrderNo);
                        iOrder += 1;
                    }
                }
            }
            if (iOrder == 0)
            {
                iOrder = 1;
            }

            return iOrder;

        }


        private void UpdateSales()
        {
            
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            double dblSales = 0;
            string strqry = "Select Sum(TotalAmount) from QTMaster Where CONVERT(nvarchar(11), TDAte)  = '" + DateTime.Now.ToString("MMM dd yyyy") + "' and Status = 'A' ";
            DataSet ds = cls.GetDataSet(strqry, ref strError);
            if (ds.Tables[0].Rows.Count > 0)
            {
                object oOrderNo = ds.Tables[0].Rows[0][0];
                if (oOrderNo != null)
                {
                    if (oOrderNo.ToString() != "")
                    {
                        dblSales = Convert.ToInt32(oOrderNo);
                    }
                }
            }
            lblSales.Text = dblSales.ToString("n0");

        }
        private DataTable dtCategory;
        private void Populatetop()
        {
            tlItem.Groups.Clear();

            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            string strPopular = " Select Top 10 * from ( ";
            strPopular += " SELECT        c.RecNo, c.DishName, c.SaleRate, SUM(b.Qty) AS Qty ";
            strPopular += " FROM    QTMaster a Inner Join  QTDetail AS b on a.RecNo = b.RecNo INNER JOIN ";
            strPopular += " SetupDishes AS c ON b.ItemId = c.RecNo ";
            strPopular += " Where a.TDate between '@DateFrom' and '@DateTo' ";
            strPopular += " GROUP BY c.DishName, c.SaleRate, c.RecNo ";
            strPopular += " )qty ";
            strPopular += " Order By Qty desc ";

            strPopular = strPopular.Replace("@DateFrom", DateTime.Now.AddMonths(-1).ToString("dd-MMM-yyyy"));
            strPopular = strPopular.Replace("@DateTo", DateTime.Now.AddDays(3).ToString("dd-MMM-yyyy"));


            DataSet ds = cls.GetDataSet(strPopular, ref strError);

            dtCategory = ds.Tables[0];

            
            DataRow[] ldr = dtCategory.Select();
            GenerateItemTiles(ldr);

            //TileGroup tg = new TileGroup();
            //foreach (DataRow pdrCategory in dtCategory.Rows)
            //{
            //    TileItem tl = new TileItem();
            //    Color cl = RandomColor();
            //    Color cl2 = DarkerColor(cl);
            //    tl.AppearanceItem.Normal.BackColor = cl2;
            //    //  tl.AppearanceItem.Normal.BackColor2 = cl2;
            //    tl.AppearanceItem.Normal.ForeColor = Color.Yellow;
            //    tl.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            //    tl.Name = pdrCategory["RecNo"].ToString();
            //    string strTitle = pdrCategory["DishName"].ToString() + "\n" + pdrCategory["SaleRate"].ToString();
            //    tl.Text = strTitle;
            //    tl.TextAlignment = TileItemContentAlignment.MiddleCenter;
            //    tl.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //    tg.Items.Add(tl);
            //    tl.ItemClick += tl_ItemClick;

            //}

            //tlItem.Groups.Add(tg);
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
        DataTable itemTable;
        private void frmOrderTake_Load(object sender, EventArgs e)
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";

         
            DataSet ds = cls.GetDataSet("Select * from SetupDishes a Inner Join Category b on a.CategoryId =  b.RecNo  Where Status = 'A'  order by priorty;Select * from Customer Where Status = 'A';Select * from Category   order by priorty;" , ref strError);
            DataSet dsMaster = cls.GetDataSet("Select * from QTMaster Where 1=2;Select * from QTDetail Where 1=2", ref strError);
            _DataSource = dsMaster;

            TileGroup tgCategory = new TileGroup();
            foreach (DataRow pdrCategory in ds.Tables[2].Rows)
            {
                TileItem tlCat = new TileItem();
                Color cl = RandomColor();
                Color cl2 = DarkerColor(cl);
                tlCat.AppearanceItem.Normal.BackColor = cl2;
                //  tl.AppearanceItem.Normal.BackColor2 = cl2;
                tlCat.AppearanceItem.Normal.ForeColor = Color.Yellow;
                tlCat.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                tlCat.Name = pdrCategory["RecNo"].ToString();
                tlCat.Text = pdrCategory["Category"].ToString();
                tlCat.TextAlignment = TileItemContentAlignment.MiddleCenter;
                tlCat.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tgCategory.Items.Add(tlCat);
                tlCat.ItemClick += tlCat_ItemClick;


            }
            tlCategory.Groups.Add(tgCategory);

            //tlCategory.Enabled = false;
            //tlItem.Enabled = false;



            itemTable = ds.Tables[0];

            repItem.DataSource = ds.Tables[0].Copy();
            repItem.DisplayMember = "DishName";
            repItem.ValueMember = "RecNo";

            BindData(dsMaster);
            //grdDetailControl.DataSource = dsMaster.Tables[1];

            //txtRecNo.DataBindings.Add("Text", dsMaster.Tables[0], "RecNo", true);
            //txtONumber.DataBindings.Add("Text", dsMaster.Tables[0], "OrderNo", true);
            //txtTable.DataBindings.Add("Text", dsMaster.Tables[0], "TableNo", true);
            //lkpCustomer.DataBindings.Add("EditValue", dsMaster.Tables[0], "CustomerId", true);
            //rdoQType.DataBindings.Add("EditValue", dsMaster.Tables[0], "QTType", true);
            ClearAll();
            rdoQType.EditValue = "D";
            lkpCustomer.Properties.DataSource = ds.Tables[1];
            lkpCustomer.Properties.ValueMember = "RecNo";
            lkpCustomer.Properties.DisplayMember = "Customer";
            lkpCustomer.EditValue = Company._Company.CashCustomer;
           
        }

        void tlCat_ItemClick(object sender, TileItemEventArgs e)
        {
            TileItem tli = sender as TileItem;
            string sName = tli.Name;
            DataRow[] dr =itemTable.Select("CategoryId = " +sName);
            GenerateItemTiles(dr);
        }
        //private void GenerateItemTiles(DataRow[] dr)
        //{
        //    tlItem.Groups.Clear();
        //    TileGroup tg = new TileGroup();
        //    foreach (DataRow pdrCategory in dr)
        //    {
        //        TileItem tl = new TileItem();
        //        Color cl = RandomColor();
        //        Color cl2 = DarkerColor(cl);
        //        tl.AppearanceItem.Normal.BackColor = cl2;
        //        //  tl.AppearanceItem.Normal.BackColor2 = cl2;
        //        tl.AppearanceItem.Normal.ForeColor = Color.Yellow;
        //        tl.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        //        tl.Name = pdrCategory["RecNo"].ToString();
        //        string strTitle = pdrCategory["DishName"].ToString() + "\n" + pdrCategory["SaleRate"].ToString();
        //        tl.Text = strTitle + $"  ({tl.Name})";
        //        tl.TextAlignment = TileItemContentAlignment.MiddleCenter;
        //        tl.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        tg.Items.Add(tl);
        //        tl.ItemClick += tl_ItemClick;

        //    }
        //    tlItem.Groups.Add(tg);
        //}


        private void GenerateItemTiles(DataRow[] dr)
        {
            tlItem.Groups.Clear();
            TileGroup tg = new TileGroup();

            foreach (DataRow pdrCategory in dr)
            {
                TileItem tl = new TileItem();
                Color cl = RandomColor();
                Color cl2 = DarkerColor(cl);

                tl.AppearanceItem.Normal.BackColor = cl2;
                tl.AppearanceItem.Normal.ForeColor = Color.White;
                tl.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;

                // ====== Dish Name (Prominent) ======
                TileItemElement elemName = new TileItemElement();
                elemName.Text = pdrCategory["DishName"].ToString();
                elemName.Appearance.Normal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                elemName.Appearance.Normal.ForeColor = Color.White;
                elemName.TextAlignment = TileItemContentAlignment.MiddleCenter;

                // ====== Price (Left Bottom) ======
                TileItemElement elemPrice = new TileItemElement();
                elemPrice.Text = "Rs. " + pdrCategory["SaleRate"].ToString();
                elemPrice.Appearance.Normal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                elemPrice.Appearance.Normal.ForeColor = Color.Lime;
                elemPrice.TextAlignment = TileItemContentAlignment.BottomRight;

                // ====== RecNo (Right Bottom) ======
                TileItemElement elemRecNo = new TileItemElement();
                elemRecNo.Text = "#" + pdrCategory["RecNo"].ToString();
                elemRecNo.Appearance.Normal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                elemRecNo.Appearance.Normal.ForeColor = Color.Yellow;
                elemRecNo.TextAlignment = TileItemContentAlignment.TopLeft;

                // Add elements to tile
                tl.Elements.Add(elemPrice);
                tl.Elements.Add(elemRecNo);
                tl.Elements.Add(elemName);
              

                // Name for reference
                tl.Name = pdrCategory["RecNo"].ToString();

                // Add to group
                tg.Items.Add(tl);
                tl.ItemClick += tl_ItemClick;
            }

            tlItem.Groups.Add(tg);
        }
        private void BindData(DataSet ds)
        {

            grdDetailControl.DataSource = ds.Tables[1];
            if (txtRecNo.DataBindings.Count >0)
            {
                txtRecNo.DataBindings.Clear();
            }
            if (txtONumber.DataBindings.Count > 0)
            {
                txtONumber.DataBindings.Clear();
            }
            if (txtTable.DataBindings.Count > 0)
            {
                txtTable.DataBindings.Clear();
            }
            if (lkpCustomer.DataBindings.Count > 0)
            {
                lkpCustomer.DataBindings.Clear();
            }
            if (rdoQType.DataBindings.Count > 0)
            {
                rdoQType.DataBindings.Clear();
            }
            txtRecNo.DataBindings.Add("Text", ds.Tables[0], "RecNo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtONumber.DataBindings.Add("Text", ds.Tables[0], "OrderNo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTable.DataBindings.Add("Text", ds.Tables[0], "TableNo", true, DataSourceUpdateMode.OnPropertyChanged);
            numDC.DataBindings.Add("Value", ds.Tables[0], "DeliveryCharges", true, DataSourceUpdateMode.OnPropertyChanged);
            lkpCustomer.DataBindings.Add("EditValue", ds.Tables[0], "CustomerId", true, DataSourceUpdateMode.OnPropertyChanged);
            rdoQType.DataBindings.Add("EditValue", ds.Tables[0], "QTType", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private Color RandomColor()
        {
            Thread.Sleep(20);
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            Color randomColor = Color.FromKnownColor(randomColorName);
            return randomColor;
        }
        private Color DarkerColor(Color color, float correctionfactory = 50f)
        {
            const float hundredpercent = 100f;
            return Color.FromArgb((int)(((float)color.R / hundredpercent) * correctionfactory),
                (int)(((float)color.G / hundredpercent) * correctionfactory), (int)(((float)color.B / hundredpercent) * correctionfactory));
        }
        //private Color LighterColor(Color color, float correctionfactory = 50f)
        //{
        //    correctionfactory = correctionfactory / 100f;
        //    const float rgb255 = 255f;
        //    return Color.FromArgb((int)((float)color.R + ((rgb255 - (float)color.R) * correctionfactory)), (int)((float)color.G + ((rgb255 - (float)color.G) * correctionfactory)), (int)((float)color.B + ((rgb255 - (float)color.B) * correctionfactory))
        //        );
        //}

        void tl_ItemClick(object sender, TileItemEventArgs e)
        {
            TileItem tli = sender as TileItem;
            int ItemId = 0;
            object oItem = tli.Name;
            if (oItem != null)
            {
                if (oItem.ToString() != "")
                {
                    ItemId = Convert.ToInt32(oItem);
                }
            }
            AddItems(ItemId);
        }


        private void AddItems(int iItemId)
        {

            DataTable dtb = (DataTable)grdDetailControl.DataSource;
            //if (dtb.Rows.Count == 1)
            //{
            //    object objItemId = dtb.Rows[0]["ItemId"];
            //    if (ItemId == 0)
            //    {
            //        dtb.Rows.Clear();
            //    }
            //}
            DataTable dtbItems = (DataTable)repItem.DataSource;
            DataRow[] dr = dtb.Select("Itemid = '" + iItemId + "'");
            DataRow[] drItems = dtbItems.Select("RecNo = '" + iItemId + "'");
            if (dr.Count() == 0)
            {
                double dblPrice = 0;
                frmNumber frm = new frmNumber();
                frm.TimerInterval = 700;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                double dblQuantity = Convert.ToDouble(frm.Value);
                object objPrice = drItems[0]["SaleRate"];
                if (objPrice != null)
                {
                    if (objPrice.ToString() != "")
                    {
                        dblPrice = Convert.ToDouble(objPrice);
                    }
                }
                if (dblQuantity > 0)
                {
                    int iRow = dtb.Rows.Count;
                    dtb.Rows.Add();
                    dtb.Rows[iRow]["ItemId"] = iItemId;
                    dtb.Rows[iRow]["Qty"] = dblQuantity;
                    dtb.Rows[iRow]["Rate"] = dblPrice;
                    dtb.Rows[iRow]["Amount"] = dblPrice * dblQuantity;
                }
                //    grdDetailView.FocusedRowHandle = grdDetailView.RowCount;
            }
            else
            {
                double dblPrice = 0;
                double dblQuantity = 0;
                object objPrice = drItems[0]["SaleRate"];
                if (objPrice != null)
                {
                    if (objPrice.ToString() != "")
                    {
                        dblPrice = Convert.ToDouble(objPrice);
                    }
                }
                object objQuantity = dr[0]["Qty"];
                if (objQuantity != null)
                {
                    if (objQuantity.ToString() != "")
                    {
                        dblQuantity = Convert.ToDouble(objQuantity);
                    }
                }
                dblQuantity += 1;
                dr[0]["ItemId"] = iItemId;
                dr[0]["Qty"] = dblQuantity;
                dr[0]["Rate"] = dblPrice;
                dr[0]["Amount"] = dblPrice * dblQuantity;
              
            }

            //r = GridView3.GetRowHandle(AccountsBindingSource.Find("ItemId", tli.Name))
            for (int i = 0; i < grdDetailView.RowCount; i++)
            {
                DataRow drs = grdDetailView.GetDataRow(i);
                object objItemId = drs["ItemID"];
                int ItemId = 0;
                if (objItemId != null)
                {
                    if (objItemId.ToString() != "")
                    {
                        ItemId = Convert.ToInt32(objItemId);
                    }
                }
                //if (ItemId == Convert.ToInt32(iItemId))
                //{

                //    //grdDetailView.FocusedRowHandle = i;
                //    //grdDetailView.FocusedColumn = clmQty;
                //    //grdDetailView.ShowEditor();
                //    //(grdDetailView.ActiveEditor as CalcEdit).ShowPopup();

                //    break;
                //};
                txtItem.Text = "";
                txtItem.Focus();
            }
            grdDetailView.UpdateCurrentRow();
            Calculate();



        }

        private void rdoQType_EditValueChanged(object sender, EventArgs e)
        {

            txtTable.Enabled = false;
            lkpCustomer.Enabled = false;
            lkpCustomer.EditValue = Company._Company.CashCustomer;
        

            if (rdoQType.EditValue == "DI")
            {
                txtTable.Enabled = true;
            }
            if (rdoQType.EditValue == "CR")
            {
                lkpCustomer.Enabled = true;
              
            }
            if (rdoQType.EditValue == "D")
            {
                DeliveryForm frm = new DeliveryForm();
                frm.DataSource = _DataSource;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                numDC.Value = 70;
                txtItem.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isSave = SaveRecord();
       
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            object oBillAmount = _DataSource.Tables[0].Rows[0]["BillAmount"];
            double dblBillAmount = 0;
                      
            if (oBillAmount != null)
            {
                if (oBillAmount.ToString() != "")
                {
                    dblBillAmount = Convert.ToDouble(oBillAmount);
                }
            }
            if (dblBillAmount > 0)
            {
                frmQTCashReceipt frm = new frmQTCashReceipt();
                frm.DataSource = this._DataSource;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                if (frm.isSuccess)
                {
                    _DataSource.Tables[0].Rows[0]["isCashReceived"] = true;
                    bool isSave = SaveRecord();
                   if (isSave)
                    {
                        //rptQT rpt = new rptQT();
                        //rpt.Parameters["CompanyName"].Value = "";
                        //rpt.Parameters["Address"].Value = "";
                        //rpt.Parameters["Phone"].Value = "";
                        _RecNo = 0;
                    }
                }
            }
       
        }
        private bool SaveRecord()
        {
            clsDataAccessLayer cls = new clsDataAccessLayer();
            int iRecNo = _RecNo;
            RestaurantLite.clsDataAccessLayer.OurResult strError;
            string sQType = clsDataAccessLayer.CleanValueNew<string>(rdoQType.EditValue);
            Calculate();
            DataRow drSave = _DataSource.Tables[0].Rows[0];

            if (sQType == "DI")
            {
                if (txtTable.Text == "")
                {
                    MessageBox.Show("Please Enter Table #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTable.Focus();
                    return false;
                }
            }
            else if (sQType == "D")
            {
                string sCName = clsDataAccessLayer.CleanValueNew<string>(drSave["CName"]);
                string sCMobile = clsDataAccessLayer.CleanValueNew<string>(drSave["CMobile"]);
                string sCAddress = clsDataAccessLayer.CleanValueNew<string>(drSave["CAddress"]);
                string sDName = clsDataAccessLayer.CleanValueNew<string>(drSave["DName"]);
                string sDMobile = clsDataAccessLayer.CleanValueNew<string>(drSave["DMobile"]);

                string strerror = "";
                if (sDName == "")
                {
                    strerror += "Delivery Boy Name must be Enter\n";
                }
                if (sDMobile == "")
                {
                    strerror += "Delivery Boy Mobile must be Enter\n";
                }
                if (sCName == "")
                {
                    strerror += "Customer must be Enter\n";
                }
                if (sCAddress == "")
                {
                    strerror += "Address must be Enter\n";
                }
                if (sCMobile == "")
                {
                    strerror += "Mobile must be Enter\n";
                }
                if (strerror != "")
                {
                    MessageBox.Show(strerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DeliveryForm frm = new DeliveryForm();
                    frm.DataSource = _DataSource;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                    return false;
                }
            }
            string strQuery = "";
            if (rdoQType.EditValue.ToString() == "CR" || rdoQType.EditValue.ToString() == "CS")
            {
                _DataSource.Tables[0].Rows[0]["isCashReceived"] = true;
                if (rdoQType.EditValue.ToString() == "CS")
                {
                    _DataSource.Tables[0].Rows[0]["CashReceipt"] = _DataSource.Tables[0].Rows[0]["TotalAmount"] ;
                }
            }
            object sumObject;
            sumObject = _DataSource.Tables[1].Compute("Sum(Amount)", string.Empty);
            double dblAmount = 0;
            if (sumObject != null)
            {
                if (sumObject.ToString() != "")
                {
                    dblAmount = Convert.ToDouble(sumObject);
                }   
            }
            if (dblAmount == 0)
            {
                return false;
            }
            double dblCashReceived = 0;
            //if (rdoQType.EditValue.ToString() == "CS")
            //{
            //    frmAmount frm = new frmAmount();
            //    frm.TimerInterval = 0;
            //    frm.BillAmount = dblAmount;
            //    frm.StartPosition = FormStartPosition.CenterScreen;

            //    frm.ShowDialog();
            //    if (frm.Value == "0")
            //    {
            //        return false;
            //    }
            //    dblCashReceived = Convert.ToDouble(frm.Value);
            //}
            bool isNewRecord = true;
            if (iRecNo == 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirm",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    txtItem.Focus();
                    return false;
                }
                strQuery += " Insert into QTMaster(OrderNo,TableNo,CustomerId,QTTYpe,CName,CAddress,CMobile ";
                strQuery += ",DName,DMobile,BillAmount,Discount,TotalAmount,CashReceipt,Balance,TDate,TaxAmount, ";
                strQuery += " NetAmount,TaxPer,isCashReceived,Status,DeliveryCharges) values ";
                strQuery += " ('@OrderNo','@TableNo',@CustomerId,'@QTTYpe','@CName','@CAddress','@CMobile' ";
                strQuery += ",'@DName','@DMobile',@BillAmount,@Discount,@TotalAmount," + dblCashReceived.ToString() + "," + (dblCashReceived-dblAmount) + ",'@TDate',@TaxAmount, ";
                strQuery += " @NetAmount,@TaxPer,'@isCashReceived','A',@DeliveryCharges)";
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
                    string strqry = "Select Max(RecNo) from QTMaster";
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
                isNewRecord = false;
                strQuery += " Update QTMaster set OrderNo='@OrderNo',TableNo='@TableNo',CustomerId='@CustomerId'";
                strQuery += ",QTTYpe='@QTTYpe',CName='@CName',CAddress='@CAddress',CMobile='@CMobile' ";
                strQuery += ",DeliveryCharges=@DeliveryCharges,DName='@DName',DMobile='@DMobile',BillAmount=@BillAmount,Discount=@Discount,TotalAmount=@TotalAmount,";
                strQuery += " CashReceipt=" + dblCashReceived.ToString() + ",Balance=" + (dblCashReceived - dblAmount) + ",TDate='@TDate',TaxAmount=@TaxAmount, ";
                strQuery += " NetAmount=@NetAmount,TaxPer=@TaxPer,isCashReceived='@isCashReceived' Where RecNo = @RecNo";
                strQuery += " ;Delete From  QTDetail Where RecNo = @RecNo";
                strQuery = ReplaceString(strQuery);
            }

            int i = 0;
            foreach (DataRow dr in _DataSource.Tables[1].Rows)
            {
                strQuery += ";Insert into QTDetail(RecNo,Sno,ItemId,Qty,Rate,Amount) values ";
                strQuery += " (@RecNo,@Sno,@ItemId,@Qty,@Rate,@Amount) ";
                strQuery = strQuery.Replace("@Sno", i.ToString());
                strQuery = strQuery.Replace("@ItemId", _DataSource.Tables[1].Rows[i]["ItemId"].ToString());
                strQuery = strQuery.Replace("@Rate", _DataSource.Tables[1].Rows[i]["Rate"].ToString());
                strQuery = strQuery.Replace("@Amount", _DataSource.Tables[1].Rows[i]["Amount"].ToString());
                strQuery = strQuery.Replace("@Qty", _DataSource.Tables[1].Rows[i]["Qty"].ToString());
                i += 1;
            }
            string strRemarks = GenerateRemarks(_DataSource.Tables[1]);
    
            strQuery += "; Delete From Tracked Where TransType = 'SAL' and RefNo = @RecNo";
          
            strQuery += "; Insert into Tracked ";
            strQuery += " Select a.RecNo,ItemId,0,Qty,Rate,Amount,'D','S','SAL',a.TDate,'' from QTMaster a ";
            strQuery += " Inner Join QTDetail b on a.RecNo = b.RecNo ";
            strQuery += " Where a.RecNo = " + iRecNo.ToString() + "  " ;
            strQuery += " Union All ";
            strQuery += " Select a.RecNo,0,CustomerId,0,0,TotalAmount,'D','S','SAL',a.TDate,'" + strRemarks + "' from QTMaster a ";
            strQuery += " Where a.RecNo = " + iRecNo.ToString() + " and isCashReceived ='true' ";


            strQuery = strQuery.Replace("@RecNo", iRecNo.ToString());
            strError = cls.MultipleDML(strQuery, "", "");
            if (strError.ErrorString != "OK")
            {
                MessageBox.Show(strError.ErrorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (isNewRecord)
            {
                Print(iRecNo,true);
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
                if (dr2.Count() > 0)
                {
                    strItem = dr2[0]["DishName"].ToString();
                }

                strRemarks += strItem + " " + dQty.ToString() + " X " + dRate.ToString() + " = " + (dQty * dRate).ToString("n0") + "||";
            }



            return strRemarks;
        }

        private string ReplaceString(string strQuery)
        {
            strQuery = strQuery.Replace("@DeliveryCharges", _DataSource.Tables[0].Rows[0]["DeliveryCharges"].ToString());
            strQuery = strQuery.Replace("@OrderNo", _DataSource.Tables[0].Rows[0]["OrderNo"].ToString());
            strQuery = strQuery.Replace("@TableNo", _DataSource.Tables[0].Rows[0]["TableNo"].ToString());
            strQuery = strQuery.Replace("@CustomerId", _DataSource.Tables[0].Rows[0]["CustomerId"].ToString());
            strQuery = strQuery.Replace("@QTTYpe", _DataSource.Tables[0].Rows[0]["QTTYpe"].ToString());
            strQuery = strQuery.Replace("@CName", _DataSource.Tables[0].Rows[0]["CName"].ToString());
            strQuery = strQuery.Replace("@CName", _DataSource.Tables[0].Rows[0]["CName"].ToString());
            strQuery = strQuery.Replace("@CAddress", _DataSource.Tables[0].Rows[0]["CAddress"].ToString());
            strQuery = strQuery.Replace("@CMobile", _DataSource.Tables[0].Rows[0]["CMobile"].ToString());
            strQuery = strQuery.Replace("@DName", _DataSource.Tables[0].Rows[0]["DName"].ToString());
            strQuery = strQuery.Replace("@DMobile", _DataSource.Tables[0].Rows[0]["DMobile"].ToString());
            strQuery = strQuery.Replace("@BillAmount", _DataSource.Tables[0].Rows[0]["BillAmount"].ToString());
            strQuery = strQuery.Replace("@Discount", _DataSource.Tables[0].Rows[0]["Discount"].ToString());
            strQuery = strQuery.Replace("@TotalAmount", _DataSource.Tables[0].Rows[0]["TotalAmount"].ToString());
            strQuery = strQuery.Replace("@CashReceipt", _DataSource.Tables[0].Rows[0]["CashReceipt"].ToString());
            strQuery = strQuery.Replace("@Balance", _DataSource.Tables[0].Rows[0]["Balance"].ToString());
            strQuery = strQuery.Replace("@TDate", _DataSource.Tables[0].Rows[0]["TDate"].ToString());
            strQuery = strQuery.Replace("@TaxAmount", _DataSource.Tables[0].Rows[0]["TaxAmount"].ToString());
            strQuery = strQuery.Replace("@NetAmount", _DataSource.Tables[0].Rows[0]["NetAmount"].ToString());
            strQuery = strQuery.Replace("@TaxPer", _DataSource.Tables[0].Rows[0]["TaxPer"].ToString());
            strQuery = strQuery.Replace("@isCashReceived", _DataSource.Tables[0].Rows[0]["isCashReceived"].ToString());
            return strQuery;
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = true;
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            DataSet ds = cls.GetDataSet("Select a.*,b.Customer from QTMaster a Left Outer Join Customer b on a.CustomerId =b.RecNo  order by RecNo desc;Select * from QTDetail", ref strError);
            frmViewAll frm = new frmViewAll();
            frm.DataSource = ds;
            List<string> lstColumns = new List<string>();
            lstColumns.Add("RecNo");
            lstColumns.Add("OrderNo");
            lstColumns.Add("TableNo");
            lstColumns.Add("QTType");
            //lstColumns.Add("Customer");
            lstColumns.Add("DName");
            lstColumns.Add("CName");
            lstColumns.Add("TotalAmount");
            lstColumns.Add("isCashReceived");
            lstColumns.Add("DeliveryCharges");

            frm.VisibleColumns = lstColumns;
            frm.TType = "QT";
            frm.StartPosition = FormStartPosition.CenterScreen;

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
                
                bool isCashReceived = clsDataAccessLayer.CleanValueNew<bool>(_DataSource.Tables[0].Rows[0]["isCashReceived"]);


                btnSave.Visible = !isCashReceived;
                btnPayment.Visible = !isCashReceived;

                string sStatus = clsDataAccessLayer.CleanValueNew<string>(_DataSource.Tables[0].Rows[0]["Status"]);
                if (sStatus == "X")
                {
                    btnSave.Visible = false;
                    btnPayment.Visible = false;
                    btnDelete.Visible = false;
                    btnPrint.Visible = false;

                }

                //_DataSource = frm.SelectedData;
                //BindData(_DataSource);
                Calculate();
                RecNo = Convert.ToInt32(frm.SelectedData.Tables[0].Rows[0]["RecNo"]);
            }
       }

        private void rdoQType_Click(object sender, EventArgs e)
        {
           
        }

        private void rdoQType_DoubleClick(object sender, EventArgs e)
        {
            if (rdoQType.EditValue == "D")
            {
                DeliveryForm frm = new DeliveryForm();
                frm.DataSource = _DataSource;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            btnSave.Visible = true;
            btnPayment.Visible = true;

            foreach (DataTable dtb in _DataSource.Tables)
            {
                dtb.Rows.Clear();
            }

            RecNo = 0;
            if (_RecNo == 0)
            {
                _DataSource.Tables[0].Rows.Add();
                _DataSource.Tables[0].Rows[0]["RecNo"] = 0;
                _DataSource.Tables[0].Rows[0]["OrderNo"] = GetOrderNo();
                _DataSource.Tables[0].Rows[0]["CustomerId"] = Company._Company.CashCustomer;
                _DataSource.Tables[0].Rows[0]["QTType"] = "CS";
                _DataSource.Tables[0].Rows[0]["DeliveryCharges"] = 0;
                _DataSource.Tables[0].Rows[0]["Discount"] = 0;
                _DataSource.Tables[0].Rows[0]["BillAmount"] = 0;
                _DataSource.Tables[0].Rows[0]["TotalAmount"] = 0;
                _DataSource.Tables[0].Rows[0]["CashReceipt"] = 0;
                _DataSource.Tables[0].Rows[0]["TDate"] = DateTime.Now;
                _DataSource.Tables[0].Rows[0]["TaxPer"] = dblTax;
                _DataSource.Tables[0].Rows[0]["NetAmount"] = 0;
                _DataSource.Tables[0].Rows[0]["TaxAmount"] = 0;
                _DataSource.Tables[0].Rows[0]["isCashReceived"] = false;
                _DataSource.Tables[0].Rows[0]["Balance"] = 0;
            }
            lblTotal.Text = "Net 0";
            lblTax.Text = "Tax 0";
            lblNet.Text = "Total 0";
            txtTable.Text = "";
            numDC.Value = 0;
            rdoQType.EditValue = "D";
            Populatetop();
        }



        private void Print(int iRecNo,bool isDirect)
        {
            if (iRecNo == 0)
            {
                return;
            }
            clsDataAccessLayer cls = new clsDataAccessLayer();
            string strError = "";
            string strQuery = $@"
                Select a.*,b.ItemId,DishName as ItemName,b.Qty,b.Rate,
                b.Amount,Category from QTMaster a 
                Inner Join QTDetail b on a.RecNo = b.RecNo
                Inner Join SetupDishes c on b.ItemId = c.RecNo 
                Left Outer Join Category d on c.CategoryId = d.RecNo 
                Where a.RecNo = {iRecNo}
                and a.Status = 'A' 
            ";
            DataSet ds = cls.GetDataSet(strQuery, ref strError);

            rptQT rpt = new rptQT();
            rpt.Parameters["CompanyName"].Value = Company._Company.CompanyName;
            rpt.Parameters["Address"].Value = Company._Company.Address;
            rpt.Parameters["Phone"].Value = Company._Company.Phone;
           
            rpt.RequestParameters = false;
            rpt.DataSource = ds.Tables[0];
            rpt.DataMember = ds.Tables[0].TableName;
            rpt.ShowPrintStatusDialog = false;
            rpt.ShowPrintMarginsWarning = false;
            if (isDirect)
            {
                rpt.Print();
            }
            else
            {
                rpt.ShowPreview();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(_RecNo,false);
        }

        private void rdoQType_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            DialogResult result = MessageBox.Show("Do you want to Delete QT?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                txtItem.Focus();
                return;
            }

            if (_RecNo != 0)
            {
                clsDataAccessLayer cls = new clsDataAccessLayer();
                RestaurantLite.clsDataAccessLayer.OurResult strError;
                string strQuery = " Update QTMaster set Status='X' ";
                strQuery += " Where RecNo = " + _RecNo.ToString();
                strQuery += "; Delete From Tracked Where TransType = 'SAL' and RefNo = " + _RecNo.ToString();
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

        private void grdDetailView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clmQty || e.Column == clmRate)
            {
                object oQty = grdDetailView.GetRowCellValue(e.RowHandle,clmQty);
                double dQty = 0;
                if (oQty != null)
                {
                    if (oQty.ToString() != "")
                    {
                        dQty = Convert.ToDouble(oQty);
                    }
                }
                object oRate = grdDetailView.GetRowCellValue(e.RowHandle, clmRate);
                double dRate = 0;
                if (oRate != null)
                {
                    if (oRate.ToString() != "")
                    {
                        dRate = Convert.ToDouble(oRate);
                    }
                }
                grdDetailView.SetRowCellValue(e.RowHandle, clmAmount, (dQty * dRate));
                grdDetailView.UpdateCurrentRow();
            }
        }

        private void grdDetailView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void grdDetailView_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void grdDetailControl_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void grdDetailView_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (hitInfo.InRow)
            {
                view.DeleteRow(view.FocusedRowHandle);
                _DataSource.AcceptChanges();
            }
        }

        private void lblSales_DoubleClick(object sender, EventArgs e)
        {

        }
        System.Windows.Forms.Timer tm;
        private void lblSales_Click(object sender, EventArgs e)
        {
            tm = new System.Windows.Forms.Timer();
            tm.Enabled = true;
            tm.Interval = 2000;
            UpdateSales();
            tm.Tick += tm_Tick;
        }

        void tm_Tick(object sender, EventArgs e)
        {
            tm.Enabled = false;
            lblSales.Text = "0";
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {

            if (txtItem.Text != "")
            {
                searchTimer.Stop();
                searchTimer.Start();
            }
            //if (txtItem.Text.Length > 0)
            //{
            //    DataRow[] dr = itemTable.Select($"DishName like '%{txtItem.Text}%' ");
            //    GenerateItemTiles(dr);
            //}
        }
        private string numberBuffer = "";  // stores typed digits
        private int enterPressCount = 0; // counter for Enter presses

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (txtItem.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    if (numberBuffer != "")
                    {
                        DataRow[] dr = itemTable.Select($"RecNo = {numberBuffer}");
                        if (dr.Count() > 0)
                        {
                            int iItemId = Convert.ToInt32(dr[0]["RecNo"]);
                            AddItems(iItemId);
                           
                        }
                        enterPressCount = 0;
                    }
                    else
                    {
                        enterPressCount++;
                        if (enterPressCount == 2) // second time Enter pressed
                        {
                            btnSave.Focus();      // focus Save button
                            enterPressCount = 0;  // reset counter
                        }
                    }
                    numberBuffer = "";
                    return true; // key handled
                }
                else if (keyData == (Keys.Control | Keys.S))
                {
                    MessageBox.Show("Ctrl+S Pressed!");
                    return true;
                }
                else if (keyData >= Keys.D0 && keyData <= Keys.D9)
                {
                    numberBuffer += (keyData - Keys.D0).ToString();
                    return true;
                }
                else if (keyData >= Keys.NumPad0 && keyData <= Keys.NumPad9)
                {
                    numberBuffer += (keyData - Keys.NumPad0).ToString();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            if (txtItem.Text.Length > 0)
            {
                DataRow[] dr = itemTable.Select($"DishName LIKE '%{txtItem.Text}%'");
                GenerateItemTiles(dr);
            }
        }

        private void txtItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a number
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block it
            }

            // Allow control keys (Backspace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.DodgerBlue;
        }

        private void btnSave_Leave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.White;
        }
    }
}
