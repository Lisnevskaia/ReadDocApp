using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDocApp
{
    class Program
    {
        static List<string> GetContext(Base document)
        {
            string extension = document.Type;
            if (extension == ".pdf")
            {
                PDFDocument pdfdocument = new PDFDocument(document.FilePath);
                return pdfdocument.Content;
            }
            else if (extension == ".doc")
            {
                DOCDocument DOCdocument = new DOCDocument(document.FilePath);
                return DOCdocument.Content;
            }
            else if (extension == ".docx")
            {
                DOCXDocument DOCXdocument = new DOCXDocument(document.FilePath);
                return DOCXdocument.Content;
            }
            else if (extension == ".txt")
            {
                TXTDocument TXTdocument = new TXTDocument(document.FilePath);
                return TXTdocument.Content;
            }
            else
                return new List<string>();
        }

        static void Main(string[] args)
        {
            string[] file_list = Directory.GetFiles("НЕобходимо указать путь к папке"); //необхожтио указать путь к папке
            foreach (string file in file_list)
            {
                Base doc = new Base(file);
                List<string> Content = GetContext(doc);
                if (Content.Count == 0)
                {
                    Console.WriteLine("Необходим метод для чтения документа с расширением " + doc.Type);
                }
                else
                {
                    StringBuilder tmpContent = new StringBuilder();
                    foreach (string con in Content)
                    {
                        tmpContent.Append(con);
                    }
                    Document document = new Document(file, tmpContent.ToString());
                    DBCollector db = new DBCollector();
                    db.AddDocument(document);
                }
            }
            Console.ReadLine();
        }
    }
}
