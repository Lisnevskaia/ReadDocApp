using System;
using System.IO;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace ReadDocApp
{
    class PDFDocument : Base
    {
        public PDFDocument(string Path) : base(Path)
        {
            SetContent();
        }

        private void SetContent()
        {
            FileStream filestream;
            try
            {
                filestream = File.OpenRead(FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            PdfDocument document = PdfDocument.Open(filestream);
            int pageCount = document.NumberOfPages;
            for (int i = 1; i <= pageCount; i++)
            {
                Page page = document.GetPage(i);
                Content.Add(page.Text);
            }
            filestream.Close();
        }

    }
}
