using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectDatabaseStore
{
    public partial class ReportsForm : Form
    {
        private string _connectionString = "";

        public ReportsForm()
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

        private void LoadQuery(string query)
        {
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

        private void btnGoodsStoreBase_Click(object sender, EventArgs e)
        {
            string query = @"
SELECT 
    s.Name AS [Магазин],
    d.Name AS [Отдел],
    p.Name AS [Товар],
    p.Sort AS [Сорт],
    dp.Price AS [Цена в магазине],
    dp.Quantity AS [Количество в магазине],
    sp.Price AS [Цена на базе],
    sp.Quantity AS [Количество на базе],
    sup.Name AS [Поставщик]
FROM DepartmentProduct dp
INNER JOIN Department d ON dp.DepartmentId = d.DepartmentId
INNER JOIN Store s ON d.StoreId = s.StoreId
INNER JOIN Product p ON dp.ProductId = p.ProductId
LEFT JOIN SupplierProduct sp ON p.ProductId = sp.ProductId
LEFT JOIN Supplier sup ON sp.SupplierId = sup.SupplierId";

            LoadQuery(query);
        }

        private void btnMissingGoods_Click(object sender, EventArgs e)
        {
            string query = @"
SELECT DISTINCT
    sup.Name AS [Поставщик],
    p.Name AS [Товар],
    p.Sort AS [Сорт],
    sp.Quantity AS [Количество на базе],
    sp.Price AS [Цена закупки]
FROM SupplierProduct sp
INNER JOIN Supplier sup ON sp.SupplierId = sup.SupplierId
INNER JOIN Product p ON sp.ProductId = p.ProductId
WHERE p.ProductId NOT IN (
    SELECT ProductId FROM DepartmentProduct
)";

            LoadQuery(query);
        }

        private void btnGoodsByDepartment_Click(object sender, EventArgs e)
        {
            string query = @"
SELECT
    d.Name AS [Отдел],
    p.Name AS [Товар],
    p.Sort AS [Сорт],
    dp.Quantity AS [Количество],
    dp.Price AS [Цена]
FROM DepartmentProduct dp
INNER JOIN Department d ON dp.DepartmentId = d.DepartmentId
INNER JOIN Product p ON dp.ProductId = p.ProductId
ORDER BY d.Name, p.Name";

            LoadQuery(query);
        }

        private void btnManagers_Click(object sender, EventArgs e)
        {
            string query = @"
SELECT
    s.Name AS [Магазин],
    d.Name AS [Отдел],
    d.ManagerName AS [Заведующий]
FROM Department d
INNER JOIN Store s ON d.StoreId = s.StoreId
ORDER BY s.Name, d.Name";

            LoadQuery(query);
        }

        private void btnDepartmentCost_Click(object sender, EventArgs e)
        {
            string query = @"
SELECT
    d.Name AS [Отдел],
    SUM(dp.Price * dp.Quantity) AS [Суммарная стоимость товара]
FROM DepartmentProduct dp
INNER JOIN Department d ON dp.DepartmentId = d.DepartmentId
GROUP BY d.Name
ORDER BY d.Name";

            LoadQuery(query);
        }

        private void btnSuppliersByProduct_Click(object sender, EventArgs e)
        {
            string query = @"
SELECT
    p.Name AS [Товар],
    p.Sort AS [Сорт],
    sup.Name AS [Поставщик],
    sp.Quantity AS [Количество на базе],
    sp.Price AS [Цена закупки]
FROM SupplierProduct sp
INNER JOIN Supplier sup ON sp.SupplierId = sup.SupplierId
INNER JOIN Product p ON sp.ProductId = p.ProductId
ORDER BY p.Name, sup.Name";

            LoadQuery(query);
        }
    }
}