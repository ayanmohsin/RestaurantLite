namespace RestaurantLite
{
    partial class frmOrderTake
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdoQType = new DevExpress.XtraEditors.RadioGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdDetailControl = new DevExpress.XtraGrid.GridControl();
            this.grdDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItem = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSales = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRecNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtONumber = new System.Windows.Forms.TextBox();
            this.numDC = new ControlsLibrary.cNumericUpdown();
            this.lkpCustomer = new ControlsLibrary.cDevLookupEdit();
            this.cDevLookupEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNet = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tlItem = new DevExpress.XtraEditors.TileControl();
            this.tlCategory = new DevExpress.XtraEditors.TileControl();
            ((System.ComponentModel.ISupportInitialize)(this.rdoQType.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cDevLookupEdit1View)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoQType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rdoQType, 2);
            this.rdoQType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoQType.Location = new System.Drawing.Point(3, 2);
            this.rdoQType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoQType.Name = "rdoQType";
            this.rdoQType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoQType.Properties.Appearance.Options.UseFont = true;
            this.rdoQType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("CS", "Take Away  نقد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("CR", "Credit   اُدھار"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("D", "Delivery  ترسیل"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("DI", "Dine IN  ڈائن ان")});
            this.rdoQType.Size = new System.Drawing.Size(1355, 41);
            this.rdoQType.TabIndex = 0;
            this.rdoQType.SelectedIndexChanged += new System.EventHandler(this.rdoQType_SelectedIndexChanged);
            this.rdoQType.EditValueChanged += new System.EventHandler(this.rdoQType_EditValueChanged);
            this.rdoQType.Click += new System.EventHandler(this.rdoQType_Click);
            this.rdoQType.DoubleClick += new System.EventHandler(this.rdoQType_DoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.47759F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.52241F));
            this.tableLayoutPanel1.Controls.Add(this.rdoQType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdDetailControl, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tlItem, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tlCategory, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.812516F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.20184F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.73395F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.59103F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.387204F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.34138F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1361, 750);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grdDetailControl
            // 
            this.grdDetailControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetailControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdDetailControl.Location = new System.Drawing.Point(689, 97);
            this.grdDetailControl.MainView = this.grdDetailView;
            this.grdDetailControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdDetailControl.Name = "grdDetailControl";
            this.grdDetailControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItem,
            this.repositoryItemHyperLinkEdit1});
            this.tableLayoutPanel1.SetRowSpan(this.grdDetailControl, 3);
            this.grdDetailControl.Size = new System.Drawing.Size(669, 395);
            this.grdDetailControl.TabIndex = 2;
            this.grdDetailControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDetailView});
            this.grdDetailControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdDetailControl_MouseUp);
            // 
            // grdDetailView
            // 
            this.grdDetailView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDetailView.Appearance.Row.Options.UseFont = true;
            this.grdDetailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmItem,
            this.clmQty,
            this.clmRate,
            this.clmAmount});
            this.grdDetailView.GridControl = this.grdDetailControl;
            this.grdDetailView.IndicatorWidth = 80;
            this.grdDetailView.Name = "grdDetailView";
            this.grdDetailView.OptionsView.ShowGroupPanel = false;
            this.grdDetailView.RowHeight = 70;
            this.grdDetailView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grdDetailView_RowClick);
            this.grdDetailView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdDetailView_CellValueChanged);
            this.grdDetailView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdDetailView_MouseDown);
            this.grdDetailView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdDetailView_MouseUp);
            // 
            // clmItem
            // 
            this.clmItem.Caption = "Item";
            this.clmItem.ColumnEdit = this.repItem;
            this.clmItem.FieldName = "ItemId";
            this.clmItem.Name = "clmItem";
            this.clmItem.Visible = true;
            this.clmItem.VisibleIndex = 0;
            this.clmItem.Width = 275;
            // 
            // repItem
            // 
            this.repItem.AutoHeight = false;
            this.repItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItem.Name = "repItem";
            this.repItem.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // clmQty
            // 
            this.clmQty.Caption = "Qty";
            this.clmQty.FieldName = "Qty";
            this.clmQty.Name = "clmQty";
            this.clmQty.Visible = true;
            this.clmQty.VisibleIndex = 1;
            this.clmQty.Width = 83;
            // 
            // clmRate
            // 
            this.clmRate.Caption = "Rate";
            this.clmRate.FieldName = "Rate";
            this.clmRate.Name = "clmRate";
            this.clmRate.Visible = true;
            this.clmRate.VisibleIndex = 2;
            this.clmRate.Width = 85;
            // 
            // clmAmount
            // 
            this.clmAmount.Caption = "Amount";
            this.clmAmount.FieldName = "Amount";
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmAmount.Visible = true;
            this.clmAmount.VisibleIndex = 3;
            this.clmAmount.Width = 113;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnPrint, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnClear, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPayment, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnViewAll, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(689, 532);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(669, 187);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(449, 74);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(217, 68);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(449, 2);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(217, 68);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear All ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(3, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(217, 68);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save Record محفوظ کریں";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // btnPayment
            // 
            this.btnPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Location = new System.Drawing.Point(3, 74);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(217, 68);
            this.btnPayment.TabIndex = 0;
            this.btnPayment.Text = "Cash Receipt  رقم  ";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(226, 74);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(217, 68);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete حذف کریں";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnViewAll
            // 
            this.btnViewAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAll.Location = new System.Drawing.Point(226, 2);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(217, 68);
            this.btnViewAll.TabIndex = 0;
            this.btnViewAll.Text = "View All  سب دیکھیں";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel5, 3);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.78378F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.21622F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 239F));
            this.tableLayoutPanel5.Controls.Add(this.lbl, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblSales, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblCash, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 148);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(661, 35);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(47, 5);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(63, 25);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "Cash";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(351, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sales";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.BackColor = System.Drawing.Color.Green;
            this.lblSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSales.ForeColor = System.Drawing.Color.White;
            this.lblSales.Location = new System.Drawing.Point(424, 0);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(234, 35);
            this.lblSales.TabIndex = 5;
            this.lblSales.Text = "0";
            this.lblSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSales.Click += new System.EventHandler(this.lblSales_Click);
            this.lblSales.DoubleClick += new System.EventHandler(this.lblSales_DoubleClick);
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.BackColor = System.Drawing.Color.Green;
            this.lblCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.ForeColor = System.Drawing.Color.White;
            this.lblCash.Location = new System.Drawing.Point(116, 0);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(217, 35);
            this.lblCash.TabIndex = 5;
            this.lblCash.Text = "0";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 11;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel3.Controls.Add(this.txtRecNo, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTable, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtItem, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtONumber, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.numDC, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.lkpCustomer, 10, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 47);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1355, 46);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // txtRecNo
            // 
            this.txtRecNo.Enabled = false;
            this.txtRecNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecNo.Location = new System.Drawing.Point(345, 2);
            this.txtRecNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRecNo.Name = "txtRecNo";
            this.txtRecNo.Size = new System.Drawing.Size(125, 38);
            this.txtRecNo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1066, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Customer";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(866, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Table #";
            // 
            // txtTable
            // 
            this.txtTable.Enabled = false;
            this.txtTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTable.Location = new System.Drawing.Point(943, 2);
            this.txtTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(117, 38);
            this.txtTable.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Record #";
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItem.Location = new System.Drawing.Point(3, 2);
            this.txtItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(245, 38);
            this.txtItem.TabIndex = 1;
            this.txtItem.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            this.txtItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItem_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(476, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Order #";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(705, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "DC";
            // 
            // txtONumber
            // 
            this.txtONumber.Enabled = false;
            this.txtONumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtONumber.Location = new System.Drawing.Point(555, 2);
            this.txtONumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtONumber.Name = "txtONumber";
            this.txtONumber.Size = new System.Drawing.Size(144, 38);
            this.txtONumber.TabIndex = 1;
            // 
            // numDC
            // 
            this.numDC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numDC.DataField = null;
            this.numDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDC.isPkField = false;
            this.numDC.Location = new System.Drawing.Point(740, 6);
            this.numDC.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numDC.Name = "numDC";
            this.numDC.Size = new System.Drawing.Size(120, 34);
            this.numDC.TabIndex = 4;
            this.numDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lkpCustomer
            // 
            this.lkpCustomer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lkpCustomer.ControlType = ControlsLibrary.ControlType.Mendatory;
            this.lkpCustomer.DataField = null;
            this.lkpCustomer.DataSource = null;
            this.lkpCustomer.DisplayMember = null;
            this.lkpCustomer.isPkField = false;
            this.lkpCustomer.Location = new System.Drawing.Point(1162, 8);
            this.lkpCustomer.Name = "lkpCustomer";
            this.lkpCustomer.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.lkpCustomer.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpCustomer.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lkpCustomer.Properties.Appearance.Options.UseBackColor = true;
            this.lkpCustomer.Properties.Appearance.Options.UseFont = true;
            this.lkpCustomer.Properties.Appearance.Options.UseForeColor = true;
            this.lkpCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpCustomer.Properties.View = this.cDevLookupEdit1View;
            this.lkpCustomer.Size = new System.Drawing.Size(190, 30);
            this.lkpCustomer.TabIndex = 5;
            this.lkpCustomer.ValueMember = null;
            // 
            // cDevLookupEdit1View
            // 
            this.cDevLookupEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cDevLookupEdit1View.Name = "cDevLookupEdit1View";
            this.cDevLookupEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cDevLookupEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.lblNet, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblTax, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblTotal, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(689, 496);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(669, 32);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // lblNet
            // 
            this.lblNet.AutoSize = true;
            this.lblNet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNet.ForeColor = System.Drawing.Color.Blue;
            this.lblNet.Location = new System.Drawing.Point(448, 0);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(218, 32);
            this.lblNet.TabIndex = 6;
            this.lblNet.Text = "Total 0";
            this.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(226, 0);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(216, 32);
            this.lblTax.TabIndex = 5;
            this.lblTax.Text = "Tax 0";
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(217, 32);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Net 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlItem
            // 
            this.tlItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlItem.Location = new System.Drawing.Point(3, 246);
            this.tlItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlItem.Name = "tlItem";
            this.tlItem.Padding = new System.Windows.Forms.Padding(19, 18, 19, 18);
            this.tableLayoutPanel1.SetRowSpan(this.tlItem, 5);
            this.tlItem.Size = new System.Drawing.Size(680, 502);
            this.tlItem.TabIndex = 1;
            this.tlItem.Text = "tileControl1";
            // 
            // tlCategory
            // 
            this.tlCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCategory.ItemPadding = new System.Windows.Forms.Padding(5);
            this.tlCategory.ItemSize = 60;
            this.tlCategory.Location = new System.Drawing.Point(3, 97);
            this.tlCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlCategory.Name = "tlCategory";
            this.tlCategory.Padding = new System.Windows.Forms.Padding(19, 18, 19, 18);
            this.tlCategory.Size = new System.Drawing.Size(680, 145);
            this.tlCategory.TabIndex = 1;
            this.tlCategory.Text = "tileControl1";
            // 
            // frmOrderTake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1361, 750);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmOrderTake";
            this.Text = "frmOrderTake";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrderTake_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdoQType.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cDevLookupEdit1View)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup rdoQType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.TileControl tlItem;
        private DevExpress.XtraGrid.GridControl grdDetailControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDetailView;
        private DevExpress.XtraGrid.Columns.GridColumn clmItem;
        private DevExpress.XtraGrid.Columns.GridColumn clmQty;
        private DevExpress.XtraGrid.Columns.GridColumn clmRate;
        private DevExpress.XtraGrid.Columns.GridColumn clmAmount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtONumber;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblNet;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTable;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repItem;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.Label lblCash;
        private DevExpress.XtraEditors.TileControl tlCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private System.Windows.Forms.Label label5;
        private ControlsLibrary.cNumericUpdown numDC;
        private System.Windows.Forms.TextBox txtItem;
        private ControlsLibrary.cDevLookupEdit lkpCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView cDevLookupEdit1View;
    }
}