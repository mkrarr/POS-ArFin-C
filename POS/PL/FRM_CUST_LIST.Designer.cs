namespace POS.PL
{
    partial class FRM_CUST_LIST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CUST_LIST));
            this.dgvCL = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCL)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCL
            // 
            this.dgvCL.AllowUserToAddRows = false;
            this.dgvCL.AllowUserToDeleteRows = false;
            this.dgvCL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCL.Location = new System.Drawing.Point(0, 0);
            this.dgvCL.Name = "dgvCL";
            this.dgvCL.ReadOnly = true;
            this.dgvCL.Size = new System.Drawing.Size(731, 292);
            this.dgvCL.TabIndex = 0;
            this.dgvCL.AllowUserToOrderColumnsChanged += new System.EventHandler(this.d);
            this.dgvCL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCL_CellContentClick);
            this.dgvCL.DoubleClick += new System.EventHandler(this.dgvCL_DoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(731, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FRM_CUST_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 292);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvCL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_CUST_LIST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers List";
            this.Load += new System.EventHandler(this.FRM_CUST_LIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvCL;
        private System.Windows.Forms.TextBox textBox1;

    }
}