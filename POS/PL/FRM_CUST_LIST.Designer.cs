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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCL)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCL
            // 
            this.dgvCL.AllowUserToAddRows = false;
            this.dgvCL.AllowUserToDeleteRows = false;
            this.dgvCL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCL.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCL.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCL.Location = new System.Drawing.Point(0, 24);
            this.dgvCL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCL.Name = "dgvCL";
            this.dgvCL.ReadOnly = true;
            this.dgvCL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvCL.Size = new System.Drawing.Size(853, 334);
            this.dgvCL.TabIndex = 0;
            this.dgvCL.AllowUserToOrderColumnsChanged += new System.EventHandler(this.d);
            this.dgvCL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCL_CellContentClick);
            this.dgvCL.DoubleClick += new System.EventHandler(this.dgvCL_DoubleClick);
            this.dgvCL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCL_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(853, 24);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Image = global::POS.Properties.Resources.Add;
            this.button1.Location = new System.Drawing.Point(0, -1);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(50, 25);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FRM_CUST_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 359);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvCL);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FRM_CUST_LIST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قائمة العملاء";
            this.Load += new System.EventHandler(this.FRM_CUST_LIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvCL;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}