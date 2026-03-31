namespace POS.PL
{
    partial class FRM_ADD_PRODECT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ADD_PRODECT));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pro_ty = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtmname = new System.Windows.Forms.ComboBox();
            this.txtqte = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbprice = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtref = new System.Windows.Forms.TextBox();
            this.cmdcategories = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.pro_ty);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtmname);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.pbox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtdes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtref);
            this.groupBox1.Controls.Add(this.cmdcategories);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(676, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تفاصيل المنتج";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pro_ty
            // 
            this.pro_ty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pro_ty.FormattingEnabled = true;
            this.pro_ty.Location = new System.Drawing.Point(131, 171);
            this.pro_ty.Name = "pro_ty";
            this.pro_ty.Size = new System.Drawing.Size(432, 32);
            this.pro_ty.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(569, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "طبيعة الصنف";
            // 
            // txtmname
            // 
            this.txtmname.FormattingEnabled = true;
            this.txtmname.Location = new System.Drawing.Point(131, 133);
            this.txtmname.Name = "txtmname";
            this.txtmname.Size = new System.Drawing.Size(432, 32);
            this.txtmname.TabIndex = 16;
            // 
            // txtqte
            // 
            this.txtqte.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtqte.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqte.Location = new System.Drawing.Point(581, 232);
            this.txtqte.Name = "txtqte";
            this.txtqte.Size = new System.Drawing.Size(84, 30);
            this.txtqte.TabIndex = 15;
            this.txtqte.Text = "0";
            this.txtqte.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(588, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "سعر الشراء";
            this.label7.Visible = false;
            // 
            // txtbprice
            // 
            this.txtbprice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbprice.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbprice.Location = new System.Drawing.Point(591, 232);
            this.txtbprice.Name = "txtbprice";
            this.txtbprice.Size = new System.Drawing.Size(65, 30);
            this.txtbprice.TabIndex = 4;
            this.txtbprice.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(8, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(592, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "سعر البيع";
            this.label5.Visible = false;
            // 
            // pbox
            // 
            this.pbox.Image = global::POS.Properties.Resources.BO_Order_32x32;
            this.pbox.Location = new System.Drawing.Point(8, 20);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(117, 108);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox.TabIndex = 12;
            this.pbox.TabStop = false;
            // 
            // txtprice
            // 
            this.txtprice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtprice.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprice.Location = new System.Drawing.Point(591, 232);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(65, 30);
            this.txtprice.TabIndex = 3;
            this.txtprice.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(569, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "المخزون الافتتاحي";
            this.label4.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(569, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "الأسم العلمي";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(569, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "الاسم التجاري";
            // 
            // txtdes
            // 
            this.txtdes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdes.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdes.Location = new System.Drawing.Point(131, 98);
            this.txtdes.Name = "txtdes";
            this.txtdes.Size = new System.Drawing.Size(432, 30);
            this.txtdes.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(569, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "باركود";
            // 
            // txtref
            // 
            this.txtref.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtref.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtref.Location = new System.Drawing.Point(131, 62);
            this.txtref.Name = "txtref";
            this.txtref.Size = new System.Drawing.Size(432, 30);
            this.txtref.TabIndex = 0;
            this.txtref.TextChanged += new System.EventHandler(this.txtref_TextChanged);
            this.txtref.Validated += new System.EventHandler(this.txtref_Validated);
            // 
            // cmdcategories
            // 
            this.cmdcategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdcategories.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdcategories.FormattingEnabled = true;
            this.cmdcategories.Location = new System.Drawing.Point(131, 22);
            this.cmdcategories.Name = "cmdcategories";
            this.cmdcategories.Size = new System.Drawing.Size(432, 31);
            this.cmdcategories.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(569, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "التصنيف";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::POS.Properties.Resources.no;
            this.button3.Location = new System.Drawing.Point(4, 239);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button3.Size = new System.Drawing.Size(75, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "خروج";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.Image = global::POS.Properties.Resources.ok1;
            this.btnok.Location = new System.Drawing.Point(85, 239);
            this.btnok.Name = "btnok";
            this.btnok.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnok.Size = new System.Drawing.Size(75, 36);
            this.btnok.TabIndex = 1;
            this.btnok.Text = "حفظ";
            this.btnok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 175);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 28);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "خدمات";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FRM_ADD_PRODECT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 281);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtqte);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.txtbprice);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FRM_ADD_PRODECT";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة صنف جديد";
            this.Load += new System.EventHandler(this.FRM_ADD_PRODECT_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.PictureBox pbox;
        public System.Windows.Forms.TextBox txtprice;
        public System.Windows.Forms.TextBox txtdes;
        public System.Windows.Forms.TextBox txtref;
        public System.Windows.Forms.ComboBox cmdcategories;
        public System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtbprice;
        public System.Windows.Forms.TextBox txtqte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox txtmname;
        public System.Windows.Forms.ComboBox pro_ty;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}