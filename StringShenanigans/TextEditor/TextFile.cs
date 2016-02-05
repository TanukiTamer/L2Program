using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TextEditor
{
    class TextFile
    {
        private String filename;
        private String content;

        public string Filename
        {
            get
            {
                return filename;
            }

            set
            {
                filename = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public TextFile(String filename)
        {
            this.Filename = filename;
            readFileContents();
        }

        private void readFileContents()
        { 
            Content = File.ReadAllText(Filename);
        }
    }
}
