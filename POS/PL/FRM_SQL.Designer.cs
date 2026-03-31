namespace POS.PL
{
    partial class FRM_SQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SQL));
            this.label1 = new System.Windows.Forms.Label();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.txtdatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbwin = new System.Windows.Forms.RadioButton();
            this.rbsql = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "الخادم";
            // 
            // txtserver
            // 
            this.txtserver.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserver.Location = new System.Drawing.Point(95, 138);
            this.txtserver.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(219, 30);
            this.txtserver.TabIndex = 0;
            // 
            // txtdatabase
            // 
            this.txtdatabase.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdatabase.Location = new System.Drawing.Point(95, 178);
            this.txtdatabase.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtdatabase.Name = "txtdatabase";
            this.txtdatabase.Size = new System.Drawing.Size(219, 30);
            this.txtdatabase.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "قاعدة البيانات";
            // 
            // txtPWD
            // 
            this.txtPWD.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPWD.Location = new System.Drawing.Point(95, 314);
            this.txtPWD.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '•';
            this.txtPWD.ReadOnly = true;
            this.txtPWD.Size = new System.Drawing.Size(219, 30);
            this.txtPWD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "كلمة المرور";
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(95, 277);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(219, 30);
            this.txtid.TabIndex = 4;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "اسم المستخدم";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "صلاحية الأتصال";
            // 
            // rbwin
            // 
            this.rbwin.AutoSize = true;
            this.rbwin.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbwin.Location = new System.Drawing.Point(95, 214);
            this.rbwin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rbwin.Name = "rbwin";
            this.rbwin.Size = new System.Drawing.Size(128, 27);
            this.rbwin.TabIndex = 2;
            this.rbwin.Text = "Win Authentication";
            this.rbwin.UseVisualStyleBackColor = true;
            this.rbwin.CheckedChanged += new System.EventHandler(this.rbwin_CheckedChanged);
            // 
            // rbsql
            // 
            this.rbsql.AutoSize = true;
            this.rbsql.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbsql.Location = new System.Drawing.Point(95, 249);
            this.rbsql.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rbsql.Name = "rbsql";
            this.rbsql.Size = new System.Drawing.Size(128, 27);
            this.rbsql.TabIndex = 3;
            this.rbsql.Text = "SQL Authentication";
            this.rbsql.UseVisualStyleBackColor = true;
            this.rbsql.CheckedChanged += new System.EventHandler(this.rbsql_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::POS.Properties.Resources.no;
            this.button1.Location = new System.Drawing.Point(223, 354);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "الغاء";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Image = global::POS.Properties.Resources.edit;
            this.button11.Location = new System.Drawing.Point(132, 354);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(91, 33);
            this.button11.TabIndex = 6;
            this.button11.Text = "حفظ";
            this.button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // FRM_SQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 397);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rbsql);
            this.Controls.Add(this.rbwin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtdatabase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtserver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button11);
            this.Font = new System.Drawing.Font("Cairo", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximumSize = new System.Drawing.Size(342, 436);
            this.MinimumSize = new System.Drawing.Size(342, 436);
            this.Name = "FRM_SQL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "أتصال قاعدة البيانات";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Restore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.TextBox txtdatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbwin;
        private System.Windows.Forms.RadioButton rbsql;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}