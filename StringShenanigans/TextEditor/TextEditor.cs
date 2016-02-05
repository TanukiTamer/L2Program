using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class TextEditor : Form
    {
        private TextFile currentFile;
        private bool isChanged = false;
        public TextEditor()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                if(MessageBox.Show("Do you want to save your file?","Save?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveDialog();
                }
            }
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDlg.ShowDialog();
            currentFile = new TextFile(openFileDlg.FileName);
            textBox.Text = currentFile.Content;
            saveAsToolStripMenuItem.Enabled = true;
            isChanged = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            textBox.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            currentFile = new TextFile();
            isChanged = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDialog();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            currentFile.Content = textBox.Text;
            isChanged = true;
        }

        private void saveDialog()
        {
            if (!currentFile.Filename.Equals("")) saveFileDlg.FileName = currentFile.Filename;
            saveFileDlg.ShowDialog();
            currentFile.Filename = saveFileDlg.FileName;
            currentFile.Save();
        }
    }
}
