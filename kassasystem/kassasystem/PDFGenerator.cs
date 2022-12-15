using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.ComponentModel;
using PdfSharp.Drawing.Layout;
using PdfSharp;
using PdfSharp.Pdf.Advanced;
using System.Drawing;

namespace kassasystem
{
    internal class PDFGenerator
    {
        float taxAmount = 0.12f;
        public PDFGenerator()
        {
            
        }

        public void savePDF(ListBox inputData, Decimal totalPrice)
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1); // Time in seconds since january 1 1970
            string currentTimePeriod = ((int)t.TotalSeconds).ToString();

            //try
            //{
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
            //Create PDF Document
            PdfDocument document = new PdfDocument();
            //You will have to add Page in PDF Document
            PdfPage page = document.AddPage();
            //For drawing in PDF Page you will nedd XGraphics Object
            XGraphics gfx = XGraphics.FromPdfPage(page);
            //For Test you will have to define font to be used
            XFont titleFont = new XFont("Verdana", 20, XFontStyle.Bold);
            XFont descriptionFont = new XFont("Verdana", 10);
            XFont productFont = new XFont("Verdana", 15);
            //Finally use XGraphics & font object to draw text in PDF Page

            string outString = "";
            System.Diagnostics.Debug.WriteLine(inputData.Items.Count);
            string currentDate = DateTime.Now.ToString().Split(" ")[0];
            string currentTime = DateTime.Now.ToString().Split(" ")[1];

            XPen DividerColor = new XPen(XColors.LightSkyBlue, 3);
            XPen DividerColorProduct = new XPen(XColors.WhiteSmoke, 2);


            gfx.DrawString("Hotel name", titleFont, XBrushes.Black, new XRect(15, 15, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Receipt", titleFont, XBrushes.Black, new XRect(-15, 15, page.Width, page.Height), XStringFormats.TopRight);

            // Divider
            gfx.DrawLine(DividerColor, 15, 60, page.Width - 15, 60);

            /* Info box (date of purchase, order number etc..)  */
            gfx.DrawRectangle(XPens.WhiteSmoke, XBrushes.WhiteSmoke, 10, 75, 160, 80);
            gfx.DrawString($"Address: some address", descriptionFont, XBrushes.Black, new XRect(15, 80, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Date: {currentDate}", descriptionFont, XBrushes.Black, new XRect(15, 95, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Time: {currentTime}", descriptionFont, XBrushes.Black, new XRect(15, 110, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Order number: {currentTimePeriod}", descriptionFont, XBrushes.Black, new XRect(15, 125, page.Width, page.Height), XStringFormats.TopLeft);

            // Divider
            gfx.DrawLine(DividerColor, 15, 200, page.Width - 15, 200);


            int offset = 220;
            for (int i = 0; i < inputData.Items.Count; i++)
            {
                gfx.DrawString($"{inputData.Items[i].ToString()}", productFont, XBrushes.Black, new XRect(15, offset, page.Width, page.Height), XStringFormats.TopLeft);
                //outString += inputData.Items[i].ToString();
                gfx.DrawLine(DividerColorProduct, 15, offset + 30 , page.Width - 15, offset + 30);
                offset += 45;

                System.Diagnostics.Debug.WriteLine(inputData.Items[i].ToString());
                System.Diagnostics.Debug.WriteLine(outString);
            }

            // Tax and total amount
            gfx.DrawString($"Total without tax: {Math.Round((totalPrice / ((Decimal)taxAmount + 1)), 2)} SEK", productFont, XBrushes.Black, new XRect(15, offset + 15, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Tax ({taxAmount * 100}%): {Math.Round(totalPrice - (totalPrice / ((Decimal)taxAmount + 1)), 2)} SEK", productFont, XBrushes.Black, new XRect(15, offset + 45, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Total: {Math.Round(totalPrice * 1.00M, 2)} SEK", productFont, XBrushes.Black, new XRect(15, offset+75, page.Width, page.Height), XStringFormats.TopLeft);



            //Specify file name of the PDF file
            string filename = String.Format(@"C:\Users\{0}\Documents\hotel-receipts\receipt_{1}.pdf", userName, currentTimePeriod);

            if (!Directory.Exists(String.Format(@"c:\Users\{0}\Documents\hotel-receipts\", userName)))
            {
                Directory.CreateDirectory(String.Format(@"c:\Users\{0}\Documents\hotel-receipts\", userName));
            }

            //Save PDF File
            document.Save(filename);
            ////Load PDF File for viewing
            //Process.Start(filename);
            //}
            //catch
            //{
            //    System.Diagnostics.Debug.WriteLine("Could not save PDF!");

            //}
        }
    }
}
