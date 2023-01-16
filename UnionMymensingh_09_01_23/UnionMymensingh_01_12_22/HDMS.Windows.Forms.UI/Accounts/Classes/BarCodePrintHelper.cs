using HDMS.Model.Diagnostic.VM;
using HDMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Classes
{
    public class BarCodePrintHelper
    {
        #region Properties and Variables
        PrintDocument pdoc = null;
        private string testsLabel;
        private string regNo;
        VMFolderLabelParameter _lblParam;
        public BarCodePrintHelper(VMFolderLabelParameter lblParam)
        {
            this._lblParam = lblParam;
        }
        #endregion



        #region Print Page using Printer
        public void print(string _printerName)
        {
            try
            {
              
                PrintDialog pd = new PrintDialog();
                string strDefaultPrinter = pd.PrinterSettings.PrinterName;//Code to get default printer name  
                pdoc = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                Font font = new Font("IDAutomationHC39M", 15);//set default font for page
                PaperSize psize = new PaperSize("Custom", 300, 200);//set paper size sing code
                                                                    // pdoc.OriginAtMargins = true;
                pd.Document = pdoc;
                pd.Document.DefaultPageSettings.PaperSize = psize;

                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
                // pdoc.PrintPage += delegate (object s, EventArgs e1) { pdoc_PrintPage(s, e,""); };

                //*************************Code to set Default Printer*************************************

                //string defaultPrinterName = "TEC B-EV4 (203 dpi)"; // Code to get default printer

                string defaultPrinterName = _printerName; // Code to get default printer

                //if (defaultPrinterName == "TEC B-EV4 (203 dpi)")
                //{
                //    ps.PrinterName = "TEC B-EV4 (203 dpi)";//Code to set default printer name
                //    pd.PrinterSettings.PrinterName = "TEC B-EV4 (203 dpi)";//Code to set default printer name 
                //}
                //else
                //{
                ps.PrinterName = defaultPrinterName;//Code to set default printer name
                    pd.PrinterSettings.PrinterName = defaultPrinterName;//Code to set default printer name 
               // }


                //************************************End**************************************************


                //  DialogResult result = pd.ShowDialog();
                // if (result == DialogResult.OK)
                // {
                pdoc.Print();

                // }


                //***************************************************************End*****************************************************************//

            }
            catch (Exception ex)
            {


            }

        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {

            StringFormat sf = new StringFormat();
            //-------------------------------------End-----------------------------------------------------//


            Font font = new Font("Arial Narrow", 15);// set default font size
            float fontHeight = font.GetHeight();
            int startX = 2;// Position of x-axis
            int startY = 25;//starting position of y-axis
            int Offset = 0;
            


            e.Graphics.DrawString("Date   :", new Font("Arial Narrow", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset); // new Font("IDAutomationHC39M", 18) Set the Barcode height and Boldness
            e.Graphics.DrawString("            " + _lblParam.EntryDate, new Font("Arial Narrow", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("                               " + _lblParam.EntryTime, new Font("Arial Narrow", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 22;
            e.Graphics.DrawString("Bill No: ", new Font("Arial Narrow", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset); // new Font("IDAutomationHC39M", 18) Set the Barcode height and Boldness
            e.Graphics.DrawString("          " + _lblParam.IdNo, new Font("Arial Narrow", 13, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("                 "+"*" + _lblParam.IdNo + "*", new Font("IDAutomationHC39M", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 22;
            e.Graphics.DrawString("Name :  " , new Font("Arial Narrow", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("             " + _lblParam.Name, new Font("Arial Narrow", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 22;
            e.Graphics.DrawString("Age    : " , new Font("Arial Narrow", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("             " + _lblParam.Age , new Font("Arial Narrow", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("                                   " + "Gender:  " , new Font("Arial Narrow", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("                                                  " + _lblParam.Sex.Substring(0,1), new Font("Arial Narrow", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("                                                        "  + "Mob: ", new Font("Arial Narrow", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("                                                                  " +"0"+_lblParam.MobileNo, new Font("Arial Narrow", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 22;
          
            e.Graphics.DrawString("Refd. By: ", new Font("Arial Narrow", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("                " + _lblParam.RefdBy, new Font("Arial Narrow", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 22;
            e.Graphics.DrawString("Cabin No: ", new Font("Arial Narrow", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset); // new Font("IDAutomationHC39M", 18) Set the Barcode height and Boldness
            e.Graphics.DrawString("                " + _lblParam.CabinNo, new Font("Arial Narrow", 13, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);

            Offset = Offset + 22;
            e.Graphics.DrawString("Test/s: " , new Font("Arial Narrow", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("             " + _lblParam.Tests, new Font("Arial Narrow", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 22;
            //********************************************End********************************************

            //Offset = 0;
        }
        #endregion

        public Image generateBarcode(string id, string tests, string callNumber)
        {
            int w = id.Length * 30;
            Bitmap oBitmap = new Bitmap(w, 100);
            Graphics oGraphics = Graphics.FromImage(oBitmap);
            Font oFont = new Font("IDAutomationHC39M", 16);
            PointF oPoint = new PointF(2f, 2f);
            SolidBrush oBrushWrite = new SolidBrush(Color.Black);
            SolidBrush oBrush = new SolidBrush(Color.White);
            oGraphics.FillRectangle(oBrush, 0, 0, w, 100);
            oGraphics.DrawString("*" + id + "*", oFont, oBrushWrite, oPoint);
            oPoint = new PointF(2f, 80f);
            oGraphics.DrawString(tests, new Font("Arial Narrow", 8, FontStyle.Regular), oBrushWrite, oPoint);

            string _path = @"C:/barcodes/";

            using (FileStream fs = File.Open(_path + id + callNumber + ".jpg", FileMode.Create))
            {
                oBitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

            }

            oBitmap.Dispose();
            Image imgbarcode = Image.FromFile(_path + id + callNumber + ".jpg");

            return imgbarcode;
        }



    }
}
