using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabaseStore
{
    public partial class MonthlyReportForm : Form
    {
        private string _connectionString = "";

        public MonthlyReportForm()
        {
            InitializeComponent();
            ReadConnectionString();
        }

        private void ReadConnectionString()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["StoreDbConnection"]
                .ConnectionString;
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            string query = @"
SELECT 
    d.Name AS [Отдел],
    p.Name AS [Товар],
    p.Sort AS [Сорт],
    SUM(ISNULL(pi.Quantity, 0)) AS [Закуплено за месяц],
    SUM(ISNULL(si.Quantity, 0)) AS [Продано за месяц],
    SUM(ISNULL(si.Price * si.Quantity, 0)) - SUM(ISNULL(pi.Price * pi.Quantity, 0)) AS [Прибыль]
FROM Department d
LEFT JOIN Sale s ON d.DepartmentId = s.DepartmentId
LEFT JOIN SaleItem si ON s.SaleId = si.SaleId
LEFT JOIN Product p ON si.ProductId = p.ProductId
LEFT JOIN PurchaseItem pi ON p.ProductId = pi.ProductId
GROUP BY d.Name, p.Name, p.Sort
ORDER BY d.Name, p.Name";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                    DataVisualHelper.MakeGridReadOnly(dataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
