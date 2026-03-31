using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace POS.PL
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    label1.Text = "Price: 100 ﷼";

            //    // Or, format a numeric value with the Riyal sign
            //    decimal price = 150.75m;
            //    label2.Text = string.Format("Total: {0:N2} ﷼", price);

            //    byte[] data = Encoding.ASCII.GetBytes("This is the data to be signed.");

            //    using RSA rsa = RSA.Create();
            //    RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
            //    rsaFormatter.SetHashAlgorithm(nameof(SHA256));
            //    byte[] signedHash = rsaFormatter.CreateSignature(hash);


            //    using SHA256 sha256 = SHA256.Create();
            //    byte[] hash = sha256.ComputeHash(data);
            //
            var w = new Form();
            var t = new TreeView();
            w.Controls.Add(t);
            t.Dock = DockStyle.Fill;
            var star = "\uFDFC";
            var sar = "\uE900";
            var sar2 = "\u20C0";
            t.Nodes.Add("good: " + star);
            t.Nodes.Add("great: " + star + star + star);
            t.Font = new System.Drawing.Font("Claudion", 13f);
          //  w.Show();
            label1.Text = "100 " + star +" "+ sar + " " + sar2;
            label1.Font=new System.Drawing.Font("Claudion", 22f);
        }

        private void test_Load(object sender, EventArgs e)
        {
//label1.Text = "100 " + star + " " + sar + " " + sar2;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BL.ZatcaQrCodeGenerator qwes = new BL.ZatcaQrCodeGenerator();
            //QRL.Text=qwes.
        }
    }
}
