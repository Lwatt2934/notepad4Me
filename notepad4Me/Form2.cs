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
    public partial class frmFind : Form
    {
        public frmFind()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmMain parent_form = (frmMain)Owner;
            parent_form.DoFind(txtFindWhat.Text, rdoDown.Checked, chkMatchCase.Checked);
        }
    }
}
