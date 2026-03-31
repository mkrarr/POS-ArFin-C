namespace POS.PL
{
    partial class New_Patch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New_Patch));
            this.txtqte = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtref = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.txtspri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtppri = new System.Windows.Forms.TextBox();
            this.mdate = new System.Windows.Forms.DateTimePicker();
            this.edate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtqte
            // 
            this.txtqte.Cursor = System.Windows.Forms.Cursors.Cross;
            this.txtqte.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqte.Location = new System.Drawing.Point(12, 84);
            this.txtqte.Name = "txtqte";
            this.txtqte.Size = new System.Drawing.Size(346, 30);
            this.txtqte.TabIndex = 23;
            this.txtqte.Text = "0";
            this.txtqte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(364, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "رقم الباتش";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(364, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "الأسم";
            // 
            // txtdes
            // 
            this.txtdes.Cursor = System.Windows.Forms.Cursors.Cross;
            this.txtdes.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdes.Location = new System.Drawing.Point(12, 48);
            this.txtdes.Name = "txtdes";
            this.txtdes.ReadOnly = true;
            this.txtdes.Size = new System.Drawing.Size(346, 30);
            this.txtdes.TabIndex = 17;
            this.txtdes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(364, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "باركود";
            // 
            // txtref
            // 
            this.txtref.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtref.Location = new System.Drawing.Point(12, 12);
            this.txtref.Name = "txtref";
            this.txtref.ReadOnly = true;
            this.txtref.Size = new System.Drawing.Size(346, 30);
            this.txtref.TabIndex = 16;
            this.txtref.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::POS.Properties.Resources.no;
            this.button3.Location = new System.Drawing.Point(12, 192);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button3.Size = new System.Drawing.Size(75, 38);
            this.button3.TabIndex = 19;
            this.button3.Text = "خروج";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.Image = global::POS.Properties.Resources.ok1;
            this.btnok.Location = new System.Drawing.Point(93, 192);
            this.btnok.Name = "btnok";
            this.btnok.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnok.Size = new System.Drawing.Size(75, 38);
            this.btnok.TabIndex = 18;
            this.btnok.Text = "حفظ";
            this.btnok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // txtspri
            // 
            this.txtspri.Cursor = System.Windows.Forms.Cursors.Cross;
            this.txtspri.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtspri.Location = new System.Drawing.Point(12, 120);
            this.txtspri.Name = "txtspri";
            this.txtspri.Size = new System.Drawing.Size(130, 30);
            this.txtspri.TabIndex = 24;
            this.txtspri.Text = "0";
            this.txtspri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "سعر البيع";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(364, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "سعر الشراء";
            // 
            // txtppri
            // 
            this.txtppri.Cursor = System.Windows.Forms.Cursors.Cross;
            this.txtppri.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtppri.Location = new System.Drawing.Point(228, 120);
            this.txtppri.Name = "txtppri";
            this.txtppri.Size = new System.Drawing.Size(130, 30);
            this.txtppri.TabIndex = 26;
            this.txtppri.Text = "0";
            this.txtppri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mdate
            // 
            this.mdate.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold);
            this.mdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mdate.Location = new System.Drawing.Point(228, 156);
            this.mdate.Name = "mdate";
            this.mdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mdate.Size = new System.Drawing.Size(130, 30);
            this.mdate.TabIndex = 28;
            // 
            // edate
            // 
            this.edate.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold);
            this.edate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.edate.Location = new System.Drawing.Point(12, 156);
            this.edate.Name = "edate";
            this.edate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edate.Size = new System.Drawing.Size(130, 30);
            this.edate.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(363, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 31;
            this.label6.Text = "تاريخ الانتاج";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(147, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 23);
            this.label7.TabIndex = 30;
            this.label7.Text = "تاريخ الانتهاء";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(353, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 32;
            this.label8.Text = "تاريخ الانتاج";
            this.label8.Visible = false;
            // 
            // New_Patch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 239);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edate);
            this.Controls.Add(this.mdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtppri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtspri);
            this.Controls.Add(this.txtqte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtref);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "New_Patch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "باتش جديد";
            this.Load += new System.EventHandler(this.New_Patch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtqte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtdes;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtref;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button btnok;
        public System.Windows.Forms.TextBox txtspri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtppri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker mdate;
        public System.Windows.Forms.DateTimePicker edate;
        private System.Windows.Forms.Label label8;
    }
}