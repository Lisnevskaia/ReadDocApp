using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ReadDocApp
{
    class DBCollector : DbContext
    {
        public DBCollector() //Подключение к Базе данных
        {
        }
        public DbSet<Document> Documents { get; set; }

        public void AddDocument(Document valueDoc)
        {
            using (DBCollector DB = new DBCollector())
            {
                DB.Documents.Add(valueDoc);
                DB.SaveChanges();
            }
        }
    }
}
