using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BL
{
    class ZatcaQrCodeGenerator
    {
        public  string GenerateQrCodeBase64(string sellerName, string vatRegistrationNumber, DateTime invoiceTimestamp, decimal invoiceTotal, decimal vatAmount,string INVNumber)
        {
            // 1. Encode data in TLV format
            byte[] sellerBytes = EncodeTLV(1, sellerName);
            byte[] vatBytes = EncodeTLV(2, vatRegistrationNumber);
            byte[] INVBytes = EncodeTLV(2, INVNumber);
            byte[] timestampBytes = EncodeTLV(3, invoiceTimestamp.ToString("yyyy-MM-dd T-HH:mm:ss"));
            byte[] totalBytes = EncodeTLV(4, invoiceTotal.ToString("F3"));
            byte[] vatBytes2 = EncodeTLV(5, vatAmount.ToString("F2"));

            // 2. Concatenate TLV data
            byte[] tlvData = sellerBytes.Concat(vatBytes).Concat(timestampBytes).Concat(totalBytes).Concat(vatBytes2).Concat(INVBytes).ToArray();

            // 3. Convert to Base64
            string base64QrCode = Convert.ToBase64String(tlvData);
            return base64QrCode;
        }

        private static byte[] EncodeTLV(int tag, string value)
        {
            byte[] tagBytes = { (byte)tag };
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            byte[] lengthBytes = { (byte)valueBytes.Length };
            return tagBytes.Concat(lengthBytes).Concat(valueBytes).ToArray();
        }

        public  void Main(string[] args)
        {
            // Example Usage
            string sellerName = "My Awesome Company";
            string vatRegistrationNumber = "123456789012345";
            DateTime invoiceTimestamp = DateTime.Now;
            decimal invoiceTotal = Convert.ToDecimal(100.00);
            decimal vatAmount = Convert.ToDecimal(15.00);
            string inv = "2025000145";

            string qrCode = GenerateQrCodeBase64(sellerName, vatRegistrationNumber, invoiceTimestamp, invoiceTotal, vatAmount,inv);
            Console.WriteLine($"Base64 QR Code: {qrCode}");

            // You can now use this qrCode string in your application, e.g., display it as a QR code image.
        }
    }
}