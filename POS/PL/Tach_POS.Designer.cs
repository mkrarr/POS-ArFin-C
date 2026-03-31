namespace POS.PL
{
    partial class Tach_POS
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.geCat = new DevExpress.XtraVerticalGrid.VGridControl();
            this.vrPRo = new DevExpress.XtraVerticalGrid.VGridControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.geCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vrPRo)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(990, 472);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vrPRo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.geCat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 469);
            this.panel1.TabIndex = 0;
            // 
            // geCat
            // 
            this.geCat.Dock = System.Windows.Forms.DockStyle.Top;
            this.geCat.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.geCat.Location = new System.Drawing.Point(0, 41);
            this.geCat.Name = "geCat";
            this.geCat.Size = new System.Drawing.Size(200, 193);
            this.geCat.TabIndex = 0;
            // 
            // vrPRo
            // 
            this.vrPRo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vrPRo.Location = new System.Drawing.Point(0, 275);
            this.vrPRo.Name = "vrPRo";
            this.vrPRo.Size = new System.Drawing.Size(200, 194);
            this.vrPRo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "التصنيف";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "الصنف";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tach_POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 472);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Tach_POS";
            this.Text = "Tach_POS";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.geCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vrPRo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraVerticalGrid.VGridControl geCat;
        private DevExpress.XtraVerticalGrid.VGridControl vrPRo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}