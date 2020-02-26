using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System;
using System.Text;

namespace Pdf2Text.Support
{
    public class PdfUtils
    {
        static public string Pdf2Text(string path)
        {
            using (var pdfReader = new PdfReader(path))
            using (var pdfDocument = new PdfDocument(pdfReader))
            {
                var stringBuilder = new StringBuilder();

                for (var i = 1; i<=pdfDocument.GetNumberOfPages(); i++)
                    stringBuilder.Append(PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(i)));

                return stringBuilder.ToString().Replace("\n", "\r\n");
            }
        }
    }
}
