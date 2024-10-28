using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_project
{
    public partial class AcceptForm : Form
    {
        LoadForm loadForm = null;
        public AcceptForm()
        {
            InitializeComponent();
        }
        public AcceptForm(LoadForm loadForm)
        {
            InitializeComponent();
            this.loadForm = loadForm;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            this.loadForm.importAccepted = true;
            this.loadForm.acceptFormClosed = true;
            this.Close();
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            this.loadForm.acceptFormClosed = true;
            this.Close();
        }
    }
}
