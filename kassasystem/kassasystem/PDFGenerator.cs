using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using PdfSharp.Drawing.Layout;

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
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            //Finally use XGraphics & font object to draw text in PDF Page
            int offset = 30;
            string outString = "";
            System.Diagnostics.Debug.WriteLine(inputData.Items.Count);

            gfx.DrawString($"Hotell kassasystem", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopCenter);
            for (int i = 0; i < inputData.Items.Count; i++)
            {
                gfx.DrawString($"{inputData.Items[i].ToString()}", font, XBrushes.Black, new XRect(0, offset, page.Width, page.Height), XStringFormats.TopLeft);
                //outString += inputData.Items[i].ToString();
                offset += 20;
                    
                System.Diagnostics.Debug.WriteLine(inputData.Items[i].ToString());
                System.Diagnostics.Debug.WriteLine(outString);

            }
            gfx.DrawString($"Total: {totalPrice} kr", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.BottomLeft);
            gfx.DrawString($"Adress: 123", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.BottomRight);
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
