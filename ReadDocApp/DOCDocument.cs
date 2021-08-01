using System;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDocApp
{
    class DOCDocument : Base
    {
        public DOCDocument(string Path) : base(Path)
        {
            SetContent();
        }
        private void SetContent()
        {
            Word.Application MSWordApp = new Word.Application();
            Word.Document doc;
            string CodeToOpen;
            object nullobj = System.Reflection.Missing.Value;
            object ofalse = false;
            object otrue = true;
            try
            {
                doc = MSWordApp.Documents.Open(FilePath,
                                                    ref ofalse, ref otrue,
                                                    ref nullobj, ref nullobj, ref nullobj,
                                                    ref nullobj, ref nullobj, ref nullobj,
                                                    ref nullobj, ref nullobj, ref nullobj,
                                                    ref ofalse, ref nullobj, ref otrue,
                                                    ref nullobj);
                CodeToOpen = (doc.OpenEncoding.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (CodeToOpen != "msoEncodingCyrillic")
            {
                Content.Add(doc.Content.Text);
            }
            doc.Close(false);
            MSWordApp.Quit();
        }
    }
}
