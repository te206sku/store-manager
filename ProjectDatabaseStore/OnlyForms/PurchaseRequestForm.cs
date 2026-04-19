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
    public partial class PurchaseRequestForm : Form
    {
        private string _connectionString = "";

        public PurchaseRequestForm()
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

        private void btnLoadRequest_Click(object sender, EventArgs e)
        {
            string query = @"
SELECT DISTINCT
    sup.Name AS [Поставщик],
    p.Name AS [Товар],
    p.Sort AS [Сорт],
    sp.Price AS [Цена закупки],
    sp.Quantity AS [Количество на базе]
FROM SupplierProduct sp
INNER JOIN Supplier sup ON sp.SupplierId = sup.SupplierId
INNER JOIN Product p ON sp.ProductId = p.ProductId
WHERE p.ProductId NOT IN (
    SELECT ProductId FROM DepartmentProduct
)
OR p.ProductId IN (
    SELECT ProductId
    FROM DepartmentProduct
    WHERE Quantity < 10
)
ORDER BY sup.Name, p.Name";

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
    }
}
