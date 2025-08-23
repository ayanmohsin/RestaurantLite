namespace RestaurantLite
{
    partial class frmQTCashReceipt
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numBillAmount = new System.Windows.Forms.NumericUpDown();
            this.numTaxPercentage = new System.Windows.Forms.NumericUpDown();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.numTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.numCashReceipt = new System.Windows.Forms.NumericUpDown();
            this.numBalance = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numTaxAmount = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFullPaid = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBillAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCashReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.29453F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.43074F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.27474F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numBillAmount, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numTaxPercentage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numDiscount, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numTotalAmount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numCashReceipt, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.numBalance, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numTaxAmount, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnFullPaid, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 409);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill Amount";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tax Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numBillAmount
            // 
            this.numBillAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.numBillAmount, 2);
            this.numBillAmount.Enabled = false;
            this.numBillAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBillAmount.Location = new System.Drawing.Point(189, 6);
            this.numBillAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numBillAmount.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numBillAmount.Name = "numBillAmount";
            this.numBillAmount.Size = new System.Drawing.Size(367, 45);
            this.numBillAmount.TabIndex = 1;
            this.numBillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBillAmount.ThousandsSeparator = true;
            // 
            // numTaxPercentage
            // 
            this.numTaxPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numTaxPercentage.Enabled = false;
            this.numTaxPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTaxPercentage.Location = new System.Drawing.Point(189, 64);
            this.numTaxPercentage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numTaxPercentage.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numTaxPercentage.Name = "numTaxPercentage";
            this.numTaxPercentage.Size = new System.Drawing.Size(108, 45);
            this.numTaxPercentage.TabIndex = 1;
            this.numTaxPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTaxPercentage.ThousandsSeparator = true;
            // 
            // numDiscount
            // 
            this.numDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.numDiscount, 2);
            this.numDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDiscount.Location = new System.Drawing.Point(189, 122);
            this.numDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numDiscount.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(367, 45);
            this.numDiscount.TabIndex = 2;
            this.numDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDiscount.ThousandsSeparator = true;
            this.numDiscount.ValueChanged += new System.EventHandler(this.numDiscount_ValueChanged);
            // 
            // numTotalAmount
            // 
            this.numTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.numTotalAmount, 2);
            this.numTotalAmount.Enabled = false;
            this.numTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalAmount.Location = new System.Drawing.Point(189, 180);
            this.numTotalAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numTotalAmount.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numTotalAmount.Name = "numTotalAmount";
            this.numTotalAmount.Size = new System.Drawing.Size(367, 45);
            this.numTotalAmount.TabIndex = 1;
            this.numTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTotalAmount.ThousandsSeparator = true;
            // 
            // numCashReceipt
            // 
            this.numCashReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.numCashReceipt, 2);
            this.numCashReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCashReceipt.Location = new System.Drawing.Point(189, 238);
            this.numCashReceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numCashReceipt.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numCashReceipt.Name = "numCashReceipt";
            this.numCashReceipt.Size = new System.Drawing.Size(367, 45);
            this.numCashReceipt.TabIndex = 0;
            this.numCashReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCashReceipt.ThousandsSeparator = true;
            this.numCashReceipt.ValueChanged += new System.EventHandler(this.numCashReceipt_ValueChanged);
            this.numCashReceipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numCashReceipt_KeyDown);
            this.numCashReceipt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numCashReceipt_KeyPress);
            // 
            // numBalance
            // 
            this.numBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.numBalance, 2);
            this.numBalance.Enabled = false;
            this.numBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBalance.Location = new System.Drawing.Point(189, 296);
            this.numBalance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numBalance.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numBalance.Name = "numBalance";
            this.numBalance.Size = new System.Drawing.Size(367, 45);
            this.numBalance.TabIndex = 1;
            this.numBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBalance.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Balance";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cash Receipt";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Amount";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Discount";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numTaxAmount
            // 
            this.numTaxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numTaxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTaxAmount.Location = new System.Drawing.Point(303, 64);
            this.numTaxAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numTaxAmount.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numTaxAmount.Name = "numTaxAmount";
            this.numTaxAmount.Size = new System.Drawing.Size(253, 45);
            this.numTaxAmount.TabIndex = 3;
            this.numTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTaxAmount.ThousandsSeparator = true;
            this.numTaxAmount.ValueChanged += new System.EventHandler(this.numTaxAmount_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnSave, 2);
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(190, 352);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(365, 53);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFullPaid
            // 
            this.btnFullPaid.BackColor = System.Drawing.Color.Teal;
            this.btnFullPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullPaid.ForeColor = System.Drawing.Color.White;
            this.btnFullPaid.Location = new System.Drawing.Point(4, 352);
            this.btnFullPaid.Margin = new System.Windows.Forms.Padding(4);
            this.btnFullPaid.Name = "btnFullPaid";
            this.btnFullPaid.Size = new System.Drawing.Size(178, 53);
            this.btnFullPaid.TabIndex = 1;
            this.btnFullPaid.Text = "Full Paid";
            this.btnFullPaid.UseVisualStyleBackColor = false;
            this.btnFullPaid.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmQTCashReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 409);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmQTCashReceipt";
            this.Text = "frmQTCashReceipt";
            this.Load += new System.EventHandler(this.frmQTCashReceipt_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmQTCashReceipt_KeyPress);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBillAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCashReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numBillAmount;
        private System.Windows.Forms.NumericUpDown numTaxPercentage;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.NumericUpDown numTotalAmount;
        private System.Windows.Forms.NumericUpDown numCashReceipt;
        private System.Windows.Forms.NumericUpDown numBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numTaxAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFullPaid;
    }
}