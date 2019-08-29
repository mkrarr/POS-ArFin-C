namespace POS.PL
{
    partial class Sup_list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sup_list));
            this.dgvCL = new System.Windows.Forms.DataGridView();
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
            this.dgvCL.Size = new System.Drawing.Size(716, 335);
            this.dgvCL.TabIndex = 1;
            this.dgvCL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCL_CellContentClick);
            this.dgvCL.DoubleClick += new System.EventHandler(this.dgvCL_DoubleClick_1);
            // 
            // Sup_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 335);
            this.Controls.Add(this.dgvCL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sup_list";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sup_list";
            this.Load += new System.EventHandler(this.Sup_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvCL;
    }
}