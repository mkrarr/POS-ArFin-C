namespace POS.PL
{
    partial class Employees
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employees));
            this.panel1 = new System.Windows.Forms.Panel();
            this.key = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.btcon = new System.Windows.Forms.Button();
            this.btac = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.btcnc = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sMS_NEWDataSet1 = new POS.SMS_NEWDataSet1();
            this.sMSNEWDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMS_NEWDataSet4 = new POS.SMS_NEWDataSet4();
            this.employeeSPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employee_SPTableAdapter = new POS.SMS_NEWDataSet4TableAdapters.employee_SPTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMS_NEWDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSNEWDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMS_NEWDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.key);
            this.panel1.Controls.Add(this.label47);
            this.panel1.Controls.Add(this.btcon);
            this.panel1.Controls.Add(this.btac);
            this.panel1.Controls.Add(this.print);
            this.panel1.Controls.Add(this.btcnc);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 37);
            this.panel1.TabIndex = 0;
            // 
            // key
            // 
            this.key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.key.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.key.Dock = System.Windows.Forms.DockStyle.Right;
            this.key.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key.Location = new System.Drawing.Point(486, 0);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(338, 32);
            this.key.TabIndex = 19;
            this.key.TextChanged += new System.EventHandler(this.key_TextChanged);
            // 
            // label47
            // 
            this.label47.Dock = System.Windows.Forms.DockStyle.Right;
            this.label47.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(824, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(46, 37);
            this.label47.TabIndex = 18;
            this.label47.Text = "بحث:";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btcon
            // 
            this.btcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.btcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcon.Font = new System.Drawing.Font("Cairo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcon.Image = global::POS.Properties.Resources.Add;
            this.btcon.Location = new System.Drawing.Point(348, 0);
            this.btcon.Name = "btcon";
            this.btcon.Size = new System.Drawing.Size(87, 37);
            this.btcon.TabIndex = 15;
            this.btcon.Text = "جديد";
            this.btcon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btcon.UseVisualStyleBackColor = true;
            this.btcon.Click += new System.EventHandler(this.btcon_Click);
            // 
            // btac
            // 
            this.btac.Dock = System.Windows.Forms.DockStyle.Left;
            this.btac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btac.Font = new System.Drawing.Font("Cairo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btac.Image = global::POS.Properties.Resources.edit;
            this.btac.Location = new System.Drawing.Point(261, 0);
            this.btac.Name = "btac";
            this.btac.Size = new System.Drawing.Size(87, 37);
            this.btac.TabIndex = 14;
            this.btac.Text = "نعديل";
            this.btac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btac.UseVisualStyleBackColor = true;
            this.btac.Click += new System.EventHandler(this.btac_Click);
            // 
            // print
            // 
            this.print.Dock = System.Windows.Forms.DockStyle.Left;
            this.print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print.Font = new System.Drawing.Font("Cairo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print.Image = global::POS.Properties.Resources.Action_Paste_16x16;
            this.print.Location = new System.Drawing.Point(174, 0);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(87, 37);
            this.print.TabIndex = 20;
            this.print.Text = "طباعة";
            this.print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // btcnc
            // 
            this.btcnc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btcnc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcnc.Font = new System.Drawing.Font("Cairo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcnc.Image = global::POS.Properties.Resources.pass1;
            this.btcnc.Location = new System.Drawing.Point(87, 0);
            this.btcnc.Name = "btcnc";
            this.btcnc.Size = new System.Drawing.Size(87, 37);
            this.btcnc.TabIndex = 17;
            this.btcnc.Text = "ايقاف ";
            this.btcnc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btcnc.UseVisualStyleBackColor = true;
            this.btcnc.Click += new System.EventHandler(this.btcnc_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Cairo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::POS.Properties.Resources.no;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 37);
            this.button5.TabIndex = 16;
            this.button5.Text = " خروج";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 487);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(870, 487);
            this.dataGridView1.TabIndex = 9;
            // 
            // sMS_NEWDataSet1
            // 
            this.sMS_NEWDataSet1.DataSetName = "SMS_NEWDataSet1";
            this.sMS_NEWDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sMSNEWDataSet1BindingSource
            // 
            this.sMSNEWDataSet1BindingSource.DataSource = this.sMS_NEWDataSet1;
            this.sMSNEWDataSet1BindingSource.Position = 0;
            // 
            // sMS_NEWDataSet4
            // 
            this.sMS_NEWDataSet4.DataSetName = "SMS_NEWDataSet4";
            this.sMS_NEWDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeSPBindingSource
            // 
            this.employeeSPBindingSource.DataMember = "employee_SP";
            this.employeeSPBindingSource.DataSource = this.sMS_NEWDataSet4;
            // 
            // employee_SPTableAdapter
            // 
            this.employee_SPTableAdapter.ClearBeforeFill = true;
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 524);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Employees";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "الموظفين";
            this.Load += new System.EventHandler(this.Employees_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMS_NEWDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSNEWDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMS_NEWDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btcon;
        private System.Windows.Forms.Button btac;
        private System.Windows.Forms.Button btcnc;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.TextBox key;
        private System.Windows.Forms.Label label47;
        private SMS_NEWDataSet1 sMS_NEWDataSet1;
        private System.Windows.Forms.BindingSource sMSNEWDataSet1BindingSource;
        private SMS_NEWDataSet4 sMS_NEWDataSet4;
        private System.Windows.Forms.BindingSource employeeSPBindingSource;
        private SMS_NEWDataSet4TableAdapters.employee_SPTableAdapter employee_SPTableAdapter;
        private System.Windows.Forms.Button print;
    }
}