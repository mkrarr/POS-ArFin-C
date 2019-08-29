namespace POS.RPT
{
    partial class FRM_RPT_PRODUCT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_RPT_PRODUCT));
            this.CR1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CR1
            // 
            this.CR1.ActiveViewIndex = -1;
            this.CR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CR1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CR1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CR1.Location = new System.Drawing.Point(0, 0);
            this.CR1.Name = "CR1";
            this.CR1.Size = new System.Drawing.Size(796, 497);
            this.CR1.TabIndex = 0;
            this.CR1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CR1.Load += new System.EventHandler(this.CR1_Load);
            // 
            // FRM_RPT_PRODUCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 497);
            this.Controls.Add(this.CR1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_RPT_PRODUCT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CR1;

    }
}