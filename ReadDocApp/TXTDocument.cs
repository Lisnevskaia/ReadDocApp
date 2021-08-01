using System;
using System.IO;
using System.Text;

namespace ReadDocApp
{
    class TXTDocument : Base
    {
        public TXTDocument(string Path) : base(Path)
        {
            SetContent();
        }


        private void SetContent()
        {
            StreamReader txtreader;
            try
            {
                txtreader = new StreamReader(FilePath, Encoding.Default, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            using (txtreader)
            {
                string txtLine = string.Empty;
                while ((txtLine = txtreader.ReadLine()) != null)
                {
                    Content.Add(txtLine);
                }
            }
        }
    }
}
