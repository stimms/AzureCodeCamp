using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PancakeProwler.Data.Common.Repositories;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PancakeProwler.BookCreator
{
    class PdfCreator
    {
        public Uri GetCookBook(string name)
        {
            var document = new PdfDocument();
            document.Info.Title = name + "'s personalized cookbook";
            document.Info.Author = "Pancake Prowler";

            var page = document.AddPage();

            var graphics = XGraphics.FromPdfPage(page);

            var font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            graphics.DrawString(name + "'s personalized cookbook",
                font,
                XBrushes.Red,
                new System.Drawing.PointF((float)page.Width / 2, (float)page.Height / 2),
                XStringFormat.Center);

            var saveStream = new MemoryStream();
            document.Save(saveStream);

            var memoryStream = new MemoryStream(saveStream.ToArray());
            memoryStream.Seek(0, SeekOrigin.Begin);

            var imageStore = new BlobImageRepository();
            return imageStore.Save("application/pdf", memoryStream, "cookbooks");
        }
    }
}
