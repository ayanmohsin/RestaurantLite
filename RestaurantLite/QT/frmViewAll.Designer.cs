namespace RestaurantLite.QT
{
    partial class frmViewAll
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
            this.grdControl = new DevExpress.XtraGrid.GridControl();
            this.grdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnReceived = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdControl
            // 
            this.grdControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdControl.Location = new System.Drawing.Point(0, 0);
            this.grdControl.MainView = this.grdView;
            this.grdControl.Margin = new System.Windows.Forms.Padding(4);
            this.grdControl.Name = "grdControl";
            this.grdControl.Size = new System.Drawing.Size(984, 590);
            this.grdControl.TabIndex = 0;
            this.grdControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView});
            // 
            // grdView
            // 
            this.grdView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdView.Appearance.Row.Options.UseFont = true;
            this.grdView.GridControl = this.grdControl;
            this.grdView.Name = "grdView";
            this.grdView.OptionsView.ShowFooter = true;
            this.grdView.OptionsView.ShowGroupPanel = false;
            this.grdView.RowHeight = 50;
            this.grdView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grdView_RowCellStyle);
            this.grdView.DoubleClick += new System.EventHandler(this.grdView_DoubleClick);
            // 
            // btnReceived
            // 
            this.btnReceived.Location = new System.Drawing.Point(818, 594);
            this.btnReceived.Name = "btnReceived";
            this.btnReceived.Size = new System.Drawing.Size(155, 32);
            this.btnReceived.TabIndex = 1;
            this.btnReceived.Text = "Payment Received";
            this.btnReceived.UseVisualStyleBackColor = true;
            this.btnReceived.Visible = false;
            this.btnReceived.Click += new System.EventHandler(this.btnReceived_Click);
            // 
            // frmViewAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 628);
            this.Controls.Add(this.btnReceived);
            this.Controls.Add(this.grdControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmViewAll";
            this.Text = "frmViewAll";
            this.Load += new System.EventHandler(this.frmViewAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView;
        private System.Windows.Forms.Button btnReceived;
    }
}