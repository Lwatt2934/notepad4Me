using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad4Me
{
    public partial class frmMain : Form
    {
        string OutFilename;

        string LastFindWord;
        bool LastFindDown;
        bool LastFindMatchCase;

        public frmMain()
        {
            InitializeComponent();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFind find = new frmFind();
            find.Show(this);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain parent_form = (frmMain) Owner;
//            parent_form.DoFind(txtFindWhat.Text, rboDown.Checked, chkMatchCase.Checked);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OutFilename))
            {
                DoSaveAs();
            }
            else
            {
                DoSave(OutFilename);
            }
        }

        bool CheckChanges()
        {
            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "*.rtf";
            openFileDialog1.Filter = "Text Files|*.rtf; *txt";
            if (CheckChanges())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        void DoSave(string filename)
        {
            OutFilename = filename;
            textBox.SaveFile(filename);
        }

        void DoSaveAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DoSave(saveFileDialog1.FileName);
            }

        }
        public void DoFind(string search, bool down, bool match_case)
        {
            LastFindWord = search;
            LastFindDown = down;
            LastFindMatchCase = match_case;

            if (down)
            {
                if (match_case)
                {
                    textBox.Find(search, textBox.SelectionStart, RichTextBoxFinds.MatchCase);
                }
                else
                {
                    textBox.Find(search, textBox.SelectionStart, RichTextBoxFinds.None);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
