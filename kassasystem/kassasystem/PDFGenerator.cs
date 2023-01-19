using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.ComponentModel;
using PdfSharp.Drawing.Layout;
using PdfSharp;
using PdfSharp.Pdf.Advanced;
using System.Data.SQLite;
using System.Drawing;
using System.Data.Entity.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace kassasystem
{
    internal class PDFGenerator
    {
        public void savePDF(Booking bookingData)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
            string path = string.Format(@"C:\Users\{0}\Documents\hotel_database\", userName);
            Database db = new Database(path, "database.db");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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

            XPen DividerColor = new XPen(XColors.LightSkyBlue, 3);
            XPen DividerColorProduct = new XPen(XColors.WhiteSmoke, 2);

            var data = db.GetReceiptData(bookingData.Id);
            var culture = new CultureInfo("en-US");

            //System.Diagnostics.Debug.WriteLine(data[0].date);

            gfx.DrawString("Hotel name", titleFont, XBrushes.Black, new XRect(15, 15, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Receipt", titleFont, XBrushes.Black, new XRect(-15, 15, page.Width, page.Height), XStringFormats.TopRight);

            // Divider
            gfx.DrawLine(DividerColor, 15, 60, page.Width - 15, 60);

            /* Info box (date of purchase, order number etc..)  */
            gfx.DrawRectangle(XPens.WhiteSmoke, XBrushes.WhiteSmoke, 10, 75, 160, 80);
            gfx.DrawString($"Address: some address", descriptionFont, XBrushes.Black, new XRect(15, 80, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Date: {data.Date}", descriptionFont, XBrushes.Black, new XRect(15, 95, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Time: {data.Time}", descriptionFont, XBrushes.Black, new XRect(15, 110, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Order number: {data.OrderNumber}", descriptionFont, XBrushes.Black, new XRect(15, 125, page.Width, page.Height), XStringFormats.TopLeft);

            // Divider
            gfx.DrawLine(DividerColor, 15, 200, page.Width - 15, 200);

            int offset = 220;

            gfx.DrawString($"{bookingData.GuestFirstName} {bookingData.GuestLastName}: {data.Total.ToString("0.00", culture)} SEK, Room: {bookingData.RoomNumber}", productFont, XBrushes.Black, new XRect(15, offset, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawLine(DividerColorProduct, 15, offset + 30 , page.Width - 15, offset + 30);
            offset += 45;

            // Tax and total amount
            gfx.DrawString($"Total without tax: {data.TotalNoTax.ToString("0.00", culture)} SEK", productFont, XBrushes.Black, new XRect(15, offset + 15, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Tax (12%): {data.Tax.ToString("0.00", culture)} SEK", productFont, XBrushes.Black, new XRect(15, offset + 45, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Total: {data.Total.ToString("0.00", culture)} SEK", productFont, XBrushes.Black, new XRect(15, offset+75, page.Width, page.Height), XStringFormats.TopLeft);


            //Specify file name of the PDF file
            string filename = string.Format(@"C:\Users\{0}\Documents\hotel-receipts\receipt_{1}.pdf", userName, data.OrderNumber);

            if (!Directory.Exists(string.Format(@"c:\Users\{0}\Documents\hotel-receipts\", userName)))
            {
                Directory.CreateDirectory(string.Format(@"c:\Users\{0}\Documents\hotel-receipts\", userName));
            }

            //Save PDF File
            document.Save(filename);
            ////Load PDF File for viewing
            //Process.Start(filename);

        }
    }
}
