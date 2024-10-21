using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_project
{
    public partial class SelectionForm : Form
    {
        SqlConnection sqlConnection = null;
        public SelectionForm()
        {
            InitializeComponent();
        }
        public SelectionForm(ConnectionForm connectionForm)
        {
            InitializeComponent();
        }
        public SelectionForm(ConnectionForm connectionForm, 
            SqlConnection sqlConnection)
        {
            InitializeComponent();
            this.sqlConnection = sqlConnection;
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadForm loadForm = new LoadForm(this, sqlConnection);
            loadForm.Show();
        }
    }
}
