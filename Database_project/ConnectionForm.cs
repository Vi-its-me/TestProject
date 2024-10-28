using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
 

namespace Database_project
{
    public partial class ConnectionForm : Form
    {
        // Подключение к БД в .NET 5
        private SqlConnection sqlConnection = null;
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.
                ConnectionStrings["cs"].ConnectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            { 
                MessageBox.Show("Соединение с базой данных установлено");
                SelectionForm selectionForm 
                    = new SelectionForm(this, sqlConnection);
                selectionForm.Show();
                
            }
            else MessageBox.Show
                    ("Не получилось открыть базу данных,\nпопробуйте снова");
        }
    }
}
