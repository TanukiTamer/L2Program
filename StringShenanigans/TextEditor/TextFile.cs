using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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
        public TextFile()
        {
            this.Filename = "";
            this.Content = "";
        }
        private void readFileContents()
        {
            try
            {
                Content = File.ReadAllText(Filename);
            }
            catch (Exception e)
            {
                
                MessageBox.Show(e.Message, "Problem opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Save()
        {
            File.WriteAllText(Filename, Content);
        }
    }
}
