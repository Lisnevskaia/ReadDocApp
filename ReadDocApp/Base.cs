using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDocApp
{
    public interface IFile
    {
        string FilePath { get; set; }
        List<string> Content { get; }
        string Type { get; }
    }
    class Base : IFile
    {
        public string FilePath { get; set; }
        public List<string> Content { get; set; }
        public string Type { get; set; }

        public Base(string Path)
        {
            FilePath = Path;
            SetFileType();
            Content = new List<string>();
        }

        private void SetFileType()
        {
            Type = Path.GetExtension(FilePath.ToString()).ToLower();
        }
    }
}
