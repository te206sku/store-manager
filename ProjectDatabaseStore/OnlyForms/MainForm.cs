using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace ProjectDatabaseStore
{
    /// <summary>
    /// Класс MainForm представляет главную форму программы.
    /// На этой форме расположены кнопки для открытия основных справочников проекта.
    /// Также здесь выполняется чтение строки подключения к базе данных
    /// и создаётся объект DatabaseManager.
    /// </summary>
    public partial class MainForm : Form
    {
        private string _connectionString = "";
        private DatabaseManager _databaseManager;

        private void ReadConnectionString()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["StoreDbConnection"]
                .ConnectionString;
        }

        public MainForm()
        {
            InitializeComponent();
            ReadConnectionString();
            _databaseManager = new DatabaseManager(_connectionString);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            var form = new DictionaryForm(
                _databaseManager,
                Constants.Tables.Store);

            form.ShowDialog();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            var form = new DictionaryForm(
                _databaseManager,
                Constants.Tables.Department);

            form.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            var form = new DictionaryForm(
                _databaseManager,
                Constants.Tables.Supplier);

            form.ShowDialog();
        }

        private void btnProductCategory_Click(object sender, EventArgs e)
        {
            var form = new DictionaryForm(
                _databaseManager,
                Constants.Tables.ProductCategory);

            form.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            var form = new DictionaryForm(
                _databaseManager,
                Constants.Tables.Product);

            form.ShowDialog();
        }

        private void btnDepartmentProduct_Click(object sender, EventArgs e)
        {
            var form = new DictionaryForm(
                _databaseManager,
                Constants.Tables.DepartmentProduct);

            form.ShowDialog();
        }

        private void btnSupplierProduct_Click(object sender, EventArgs e)
        {
            var form = new DictionaryForm(
                _databaseManager,
                Constants.Tables.SupplierProduct);

            form.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var form = new ReportsForm();
            form.ShowDialog();
        }

        private void btnPurchaseRequest_Click(object sender, EventArgs e)
        {
            var form = new PurchaseRequestForm();
            form.ShowDialog();
        }

        private void btnMonthlyReport_Click(object sender, EventArgs e)
        {
            var form = new MonthlyReportForm();
            form.ShowDialog();
        }
    }
}
