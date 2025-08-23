namespace RestaurantLite
{
    partial class frmPurchase
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdDetailControl = new DevExpress.XtraGrid.GridControl();
            this.grdDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItem = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecNo = new System.Windows.Forms.TextBox();
            this.lkpCustomer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bClearAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveRecord = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.grdDetailControl, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtRecNo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lkpCustomer, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.bClearAll, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnViewAll, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveRecord, 3, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 497);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdDetailControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grdDetailControl, 4);
            this.grdDetailControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdDetailControl.Location = new System.Drawing.Point(2, 70);
            this.grdDetailControl.MainView = this.grdDetailView;
            this.grdDetailControl.Margin = new System.Windows.Forms.Padding(2);
            this.grdDetailControl.Name = "grdDetailControl";
            this.grdDetailControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItem});
            this.tableLayoutPanel1.SetRowSpan(this.grdDetailControl, 3);
            this.grdDetailControl.Size = new System.Drawing.Size(777, 322);
            this.grdDetailControl.TabIndex = 3;
            this.grdDetailControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDetailView});
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
            this.grdDetailView.Name = "grdDetailView";
            this.grdDetailView.OptionsView.ShowGroupPanel = false;
            this.grdDetailView.RowHeight = 20;
            this.grdDetailView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdDetailView_CellValueChanged);
            this.grdDetailView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdViewDetail_KeyDown);
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
            this.clmAmount.OptionsColumn.AllowEdit = false;
            this.clmAmount.OptionsColumn.ReadOnly = true;
            this.clmAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmAmount.Visible = true;
            this.clmAmount.VisibleIndex = 3;
            this.clmAmount.Width = 113;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rec.#";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vendor";
            // 
            // txtRecNo
            // 
            this.txtRecNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtRecNo, 2);
            this.txtRecNo.Enabled = false;
            this.txtRecNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecNo.Location = new System.Drawing.Point(293, 3);
            this.txtRecNo.Name = "txtRecNo";
            this.txtRecNo.Size = new System.Drawing.Size(250, 26);
            this.txtRecNo.TabIndex = 5;
            // 
            // lkpCustomer
            // 
            this.lkpCustomer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.lkpCustomer, 2);
            this.lkpCustomer.Location = new System.Drawing.Point(293, 35);
            this.lkpCustomer.Name = "lkpCustomer";
            this.lkpCustomer.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpCustomer.Properties.Appearance.Options.UseFont = true;
            this.lkpCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpCustomer.Properties.ShowAddNewButton = true;
            this.lkpCustomer.Properties.View = this.searchLookUpEdit1View;
            this.lkpCustomer.Size = new System.Drawing.Size(476, 30);
            this.lkpCustomer.TabIndex = 6;
            this.lkpCustomer.AddNewValue += new DevExpress.XtraEditors.Controls.AddNewValueEventHandler(this.lkpCustomer_AddNewValue);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // bClearAll
            // 
            this.bClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClearAll.Location = new System.Drawing.Point(148, 396);
            this.bClearAll.Margin = new System.Windows.Forms.Padding(2);
            this.bClearAll.Name = "bClearAll";
            this.bClearAll.Size = new System.Drawing.Size(140, 57);
            this.bClearAll.TabIndex = 8;
            this.bClearAll.Text = "Clear All";
            this.bClearAll.UseVisualStyleBackColor = true;
            this.bClearAll.Click += new System.EventHandler(this.bClearAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(2, 396);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(142, 57);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveRecord
            // 
            this.btnSaveRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRecord.Location = new System.Drawing.Point(436, 396);
            this.btnSaveRecord.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveRecord.Name = "btnSaveRecord";
            this.btnSaveRecord.Size = new System.Drawing.Size(140, 57);
            this.btnSaveRecord.TabIndex = 7;
            this.btnSaveRecord.Text = "Save Record";
            this.btnSaveRecord.UseVisualStyleBackColor = true;
            this.btnSaveRecord.Click += new System.EventHandler(this.btnSaveRecord_Click);
            // 
            // btnViewAll
            // 
            this.btnViewAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAll.Location = new System.Drawing.Point(292, 396);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(140, 57);
            this.btnViewAll.TabIndex = 10;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 497);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPurchase";
            this.Text = "frmPurchase";
            this.Load += new System.EventHandler(this.frmPurchase_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdDetailControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDetailView;
        private DevExpress.XtraGrid.Columns.GridColumn clmItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repItem;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn clmQty;
        private DevExpress.XtraGrid.Columns.GridColumn clmRate;
        private DevExpress.XtraGrid.Columns.GridColumn clmAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecNo;
        private DevExpress.XtraEditors.SearchLookUpEdit lkpCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.Button bClearAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnSaveRecord;

    }
}