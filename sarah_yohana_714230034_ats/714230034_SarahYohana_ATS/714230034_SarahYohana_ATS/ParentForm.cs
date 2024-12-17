using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _714230034_SarahYohana_ATS
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
        }
        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm child = new ChildForm
            {
                MdiParent = this 
            };
            child.Show();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FileMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
