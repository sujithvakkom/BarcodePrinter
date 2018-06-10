using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using BarcodePrinter;
using Com.SharpZebra.Printing;

namespace BarCodePrinter
{
    class PrintingList : List<Barcode>, IDisposable
    {
        private int temp;
        private bool f;
        private String tempStr;
        private String printerName;
        public PrintingList(DataTable itemList,String printerName)
        {
            this.printerName = printerName;
            DataRow item = itemList.Rows[0];
            int i = 0;
            int count = 0;

            BarcodeLabel label;
            var printer = new ZebraPrinter(printerName);
            do
            {
                label = null;
                count = Int32.Parse(item[5].ToString());
                     label = new BarcodeLabel()
                    {
                        Barcode = item[4].ToString(),
                        Description = item[3].ToString(),
                        Currency = item[8].ToString(),
                        PriceWithTax = Decimal.Parse(item[9].ToString())
                    };
                for (i = 0; i < count; i++)
                {
                    if (label != null)
                        printer.Print(label.ELN);
                }
                itemList.Rows.Remove(item);
                item = itemList.Rows[0];
                //Int32.TryParse(item[5].ToString(), out temp);
                //((Barcode)item[7]).NumberOfPrint = temp;
                //tempStr = (item[0]).ToString();
                //Boolean.TryParse(tempStr , out f);
                //tempStr = (item[2]).ToString();
                //Boolean.TryParse(tempStr, out f);
                //this.Add((Barcode)item[7]);
            } while (itemList.Rows.Count>0);
            //this.print();
        }

        public void print()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = this.printerName;
            printDocument.PrintPage += new PrintPageEventHandler(this.OnPrintPage);
            printDocument.BeginPrint += new PrintEventHandler(this.OnBeginPrint);
            printDocument.EndPrint += new PrintEventHandler(printDocument_EndPrint);
            if (printDocument.PrinterSettings.IsValid)
            {
                printDocument.Print();
            }
            else
            {
                throw new Exception("Invalid Printer");
            }
        }

        void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            //MessageBox.Show("Printing Completed", "Printing completed", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle printArea = new Rectangle(
                0,
                0, 
                Convert.ToInt32(e.PageSettings.PrintableArea.Width),
                Convert.ToInt32(e.PageSettings.PrintableArea.Height*0.9));
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            /*
            int leftMargin = e.MarginBounds.Left;
            int rightMargin = e.MarginBounds.Right;
            int topMargin = e.MarginBounds.Top;
            int bottomMargin = e.MarginBounds.Bottom;
             */
            int xInc, yInc, i;
            xInc = 0;
            yInc = 0;
            Brush brush = new SolidBrush(System.Drawing.Color.Black);
            i = 0;
            do
            {
                for (; this[i].NumberOfPrint > 0;)
                {
                    e.Graphics.PageUnit = GraphicsUnit.Point;
                    this[i].Margins = (printArea.Height*10)/100;
                    this[i].DrawBarcode(e.Graphics,printArea);
                    /*
                    //e.Graphics.DrawImage((Image)this[i], (xInc + 10), (yInc + 30), 150, 100);
                    e.Graphics.DrawImage((Image)this[i], (xInc), (yInc), 150, 100);
                     * */
                    this[i].NumberOfPrint--;
                    if (xInc<(printArea.Width-300))
                    {
                        xInc += 150;
                    }
                    else if (yInc < (printArea.Height - 200))
                    {
                        yInc += 100;
                        xInc = 0;
                    }
                    else if(this.getnumberOfPrintsRemaining()>0)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
                this.Remove(this[i]);
                i = 0;
            }while(this.Count>0);
            e.HasMorePages = false;

        }
        private void OnBeginPrint(object sender, PrintEventArgs e)
        {
            
        }
        int getnumberOfPrintsRemaining()
        {
            int numberOfPrints = 0;
            foreach (Barcode x in this)
            {
                numberOfPrints += x.NumberOfPrint;
            }
            return numberOfPrints;
        }
        void IDisposable.Dispose()
        {

        }
    }
}