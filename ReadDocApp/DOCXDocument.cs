using DocumentFormat.OpenXml.Packaging;
using System;
using System.IO;

namespace ReadDocApp
{
    class DOCXDocument : Base
    {
        public DOCXDocument(string Path) : base(Path)
        {
            SetContent();
        }
        private void SetContent()
        {
            FileStream filestream = null;
            try
            {
                using (filestream = File.OpenRead(FilePath))
                {
                    WordprocessingDocument doc = WordprocessingDocument.Open(filestream, false);
                    Content.Add(doc.MainDocumentPart.Document.Body.InnerText);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DOCXDocument " + ex.Message);
            }
            finally
            {
                filestream.Close();
            }

        }
    }
}
