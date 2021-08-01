using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReadDocApp
{
    public class Document
    {
        [Key]
        public Guid ID { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
        public Document(string valueUrl, string valueText)
        {
            ID = Guid.NewGuid();
            Url = valueUrl;
            Text = valueText;
        }
    }
}
