using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodePrinter
{
    public class BarcodeLabel
    {
        static string ELNFormat = "\nN\nOD\nq344\nQ192,24\nD15\nS1\nA30,20,0,2,1,1,N,\"{0}\"\nB50,50,0,E30,2,5,80,B,\"{1}\"\nA30,150,0,4,1,1,N,\"{2}.\"\nA90,150,0,4,1,1,N,\"{3}\"\nA140,175,0,1,1,1,N,\nP{4}\n";
        static string ELNFormatEAN13 = "\nN\nOD\nq344\nQ192,24\nD15\nS1\nA30,20,0,2,1,1,N,\"{0}\"\nB50,50,0,E30,2,5,80,B,\"{1}\"\nA30,150,0,4,1,1,N,\"{2}.\"\nA90,150,0,4,1,1,N,\"{3}\"\nA140,175,0,1,1,1,N,\nP{4}\n";

        static string ELNFormatCode128 = "\nN\nOD\nq344\nQ192,24\nD15\nS1\nA30,20,0,2,1,1,N,\"{0}\"\nB50,50,0,1,2,2,70,B,\"{1}\"\nA30,150,0,4,1,1,N,\"{2}.\"\nA90,150,0,4,1,1,N,\"{3}\"\nA140,175,0,1,1,1,N,\nP{4}\n";

        public BarcodeLabel()
        {
            ELNFormatEAN13 = String.IsNullOrEmpty(
                Properties.Settings.Default.ELNFormatEAN13) ? ELNFormatEAN13 : Properties.Settings.Default.ELNFormatEAN13;
            ELNFormatCode128 = String.IsNullOrEmpty(
                Properties.Settings.Default.ELNFormatCode128) ? ELNFormatCode128 : Properties.Settings.Default.ELNFormatCode128;
        }

        public string _Barcode { get; set; }
        public string Barcode { get { return _Barcode; } set
            {
                _Barcode = value;
                if (Properties.Settings.Default.BarcodeMode == Properties.Resources.AutoEAN13Code128)
                { ELNFormat = Barcode.Length == 13 ? ELNFormatEAN13 : ELNFormatCode128; }
                else
                if (Properties.Settings.Default.BarcodeMode == Properties.Resources.EAN13)
                { ELNFormat = ELNFormatEAN13; }
                else
                if (Properties.Settings.Default.BarcodeMode == Properties.Resources.Code128)
                { ELNFormat = ELNFormatCode128; }
            }
        }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal PriceWithTax { get; set; }
        private string PriceWithTaxText { get { return PriceWithTax.ToString("F"); } }
        public string NumLabels { get; set; }
        public string[] Formate
        {
            get
            {
                return new string[] { Description, Barcode, Currency, PriceWithTaxText, "1" };
            }
        }
        public string ELN { get {

                return string.Format(ELNFormat,
                    Formate);
            } }
    }
}
