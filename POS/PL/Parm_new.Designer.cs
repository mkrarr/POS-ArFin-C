namespace POS.PL
{
    partial class Parm_new
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("printer");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Sql");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("File", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("New");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Olds");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Sales", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.a1 = new DevExpress.XtraEditors.RadioGroup();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.a1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode7.Name = "Node1";
            treeNode7.Text = "printer";
            treeNode8.Name = "Node3";
            treeNode8.Text = "Sql";
            treeNode9.Name = "Node0";
            treeNode9.Text = "File";
            treeNode10.Name = "Node5";
            treeNode10.Text = "New";
            treeNode11.Name = "Node6";
            treeNode11.Text = "Olds";
            treeNode12.Name = "Node4";
            treeNode12.Text = "Sales";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode12});
            this.treeView1.Size = new System.Drawing.Size(223, 437);
            this.treeView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(383, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 32;
            this.label1.Text = " الأعدادات";
            // 
            // a1
            // 
            this.a1.Location = new System.Drawing.Point(277, 46);
            this.a1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.a1.Name = "a1";
            this.a1.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a1.Properties.Appearance.Options.UseFont = true;
            this.a1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "OFF"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "ON")});
            this.a1.Size = new System.Drawing.Size(95, 45);
            this.a1.TabIndex = 31;
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(277, 96);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "Off";
            this.toggleSwitch1.Properties.OnText = "On";
            this.toggleSwitch1.Size = new System.Drawing.Size(95, 23);
            this.toggleSwitch1.TabIndex = 33;
            // 
            // Parm_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.a1);
            this.Controls.Add(this.treeView1);
            this.Name = "Parm_new";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(496, 437);
            ((System.ComponentModel.ISupportInitialize)(this.a1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.RadioGroup a1;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;

    }
}
