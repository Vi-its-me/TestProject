using OfficeOpenXml;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_project
{
    public partial class LoadForm : Form
    {
        public bool importAccepted = false;
        public bool acceptFormClosed = false;
        SqlConnection sqlConnection = null;
        public LoadForm()
        {
            InitializeComponent();

        }
        public LoadForm(SelectionForm selectionForm)
        {
            InitializeComponent();
            selectionForm.Close();
        }
        public LoadForm(SelectionForm selectionForm, 
            SqlConnection sqlConnection)
        {
            InitializeComponent();
            this.sqlConnection = sqlConnection;
            selectionForm.Close();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            // Подтверждение импорта
            //AcceptForm acceptForm = new AcceptForm(this);
            //acceptForm.Show();

            string filePath = PathTextBox.Text;
            FileInfo excelFile = new FileInfo(filePath);
            using (ExcelPackage spreadSheet = new ExcelPackage(excelFile))
            {
                int pageNumber = Convert.ToInt32(PageNumberTextBox.Text) - 1;
                ExcelWorksheet workSheet = spreadSheet.Workbook
                    .Worksheets[pageNumber];
                // "Ручной" подсчет кол-ва строк и столбцов в таблице
                int rowsCount = 0; int columnsCount = 0;
                while (workSheet.Cells[rowsCount + 1, 1].Value != null)
                    rowsCount++;
                while (workSheet.Cells[1, columnsCount + 1].Value != null)
                    columnsCount++;


                // Выгрузка таблицы из Excel в базу данных
                SqlCommand query = new SqlCommand();
                query.Connection = sqlConnection;
                query.CommandText = $"USE [{sqlConnection.Database}] ";
                //MessageBox.Show($"Myself method:\tcolumnsCount = {columnsCount};\trowsCount = {rowsCount};\n{query.CommandText}");
                for (int currentRow = 1; currentRow <= rowsCount;
                    currentRow++)
                {
                    if (currentRow == 1) // если строка с заголовками столбцов
                        query.CommandText += $"CREATE TABLE [{workSheet.Name}] ( ";
                    // если строка с данными
                    else query.CommandText += $"INSERT INTO [{workSheet.Name}] VALUES ( ";

                    for (int currentColumn = 1; currentColumn <= columnsCount;
                        currentColumn++)
                    {
                        if (currentRow == 1) // если строка с заголовками столбцов
                        {
                            query.CommandText += $"[{workSheet.Cells[currentRow, currentColumn].Value}] ";
                            // Назначает тип, исходя из определенного в следующей строке(с данными столбца)
                            // типа данных
                            switch (workSheet.Cells[currentRow + 1, currentColumn].Value/*.GetType().ToString()*/)
                            {
                                case double doubleVariable://"System.Double":
                                    query.CommandText += "INT, ";
                                    break;
                                case string stringVariable://"System.String":
                                    query.CommandText += "NVARCHAR(MAX), ";
                                    break;
                            }
                            if (workSheet.Cells[currentRow, currentColumn].Value == "id")
                            {   // если столбец id - это PK
                                query.CommandText = query.CommandText.TrimEnd(' ', ',');
                                query.CommandText += " PRIMARY KEY, "; // удалить ", "
                            }
                        }
                        else // 
                        {
                            switch (workSheet.Cells[currentRow, currentColumn].Value)
                            {
                                case double doubleVariable:
                                    query.CommandText += $"{workSheet.Cells[currentRow, currentColumn].Value}, ";
                                    break;
                                case string stringVariable:
                                    query.CommandText += $"N\'{workSheet.Cells[currentRow, currentColumn].Value}\', ";
                                    break;
                            }
                        }
                    }
                    query.CommandText = query.CommandText.TrimEnd(' ', ',');
                    query.CommandText += $" ) "; // удалить ", "
                }
                // Результат импорта
                MessageBox.Show("Записей добавлено: " +
                    query.ExecuteNonQuery().ToString());
            }
            
        }
    }
}
