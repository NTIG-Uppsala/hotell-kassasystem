using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using PdfSharp.Drawing.Layout;
using PdfSharp;
using PdfSharp.Pdf.Advanced;
using System.Drawing;

namespace kassasystem
{
    internal class PDFGenerator
    {
        public PDFGenerator()
        {
            
        }

        public void savePDF(ListBox inputData, Double totalPrice)
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
            //Finally use XGraphics & font object to draw text in PDF Page
            int offset = 80;
            string outString = "";
            System.Diagnostics.Debug.WriteLine(inputData.Items.Count);
            string currentDate = DateTime.Now.ToString().Split(" ")[0];
            string currentTime = DateTime.Now.ToString().Split(" ")[1];

            gfx.DrawRectangle(XPens.Gray, XBrushes.Gray, 10, 75, 100, 80);
            gfx.DrawString($"Hotell kassasystem", titleFont, XBrushes.Black, new XRect(15, 15, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Adress: 123", descriptionFont, XBrushes.Black, new XRect(15, 80, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Date: {currentDate}", descriptionFont, XBrushes.Black, new XRect(15, 95, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Time: {currentTime}", descriptionFont, XBrushes.Black, new XRect(15, 110, page.Width, page.Height), XStringFormats.TopLeft);

            XPen lineRed = new XPen(XColors.Blue, 3);
            gfx.DrawLine(lineRed, 0, 60, page.Width, 60);

            //for (int i = 0; i < inputData.Items.Count; i++)
            //{
            //    gfx.DrawString($"{inputData.Items[i].ToString()}", font, XBrushes.Black, new XRect(0, offset, page.Width, page.Height), XStringFormats.TopLeft);
            //    //outString += inputData.Items[i].ToString();
            //    offset += 20;
                    
            //    System.Diagnostics.Debug.WriteLine(inputData.Items[i].ToString());
            //    System.Diagnostics.Debug.WriteLine(outString);
            //}
            gfx.DrawString($"Total: {totalPrice} kr (12% tax)", descriptionFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.BottomLeft);
            //Specify file name of the PDF file
            string filename = String.Format(@"C:\Users\{0}\Documents\hotell-kvitton\kvitto_{1}.pdf", userName, currentTimePeriod);
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
