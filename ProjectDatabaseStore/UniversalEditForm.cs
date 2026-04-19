using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabaseStore
{
    public partial class UniversalEditForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private DataRow _row;
        private int _top = 20;

        public DataRow EditRow
        {
            get { return _row; }
            set
            {
                _row = value;
                groupBox1.Controls.Clear();
                _top = 20;
                CreateControls();
            }
        }

        public UniversalEditForm(DatabaseManager databaseManager)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
        }

        private void CreateControls()
        {
            string idColumn = GetIdColumnName(_row.Table.TableName);

            var columns = _row.Table.Columns
                .Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .Where(c => c != idColumn)
                .ToList();

            var localization = TableLocalization.Load(_row.Table.TableName);

            foreach (string columnName in columns)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Text = localization == null
                    ? columnName
                    : localization.GetLocale(columnName);

                Control control = CreateControlForColumn(columnName);

                PlaceControl(label, control);
                FillControlValue(control, columnName);
            }
        }

        private string GetIdColumnName(string tableName)
        {
            if (tableName == Constants.Tables.Purchase) return "PurchaseId";
            if (tableName == Constants.Tables.PurchaseItem) return "PurchaseItemId";
            if (tableName == Constants.Tables.Sale) return "SaleId";
            if (tableName == Constants.Tables.SaleItem) return "SaleItemId";
            if (tableName == Constants.Tables.Store) return "StoreId";
            if (tableName == Constants.Tables.Department) return "DepartmentId";
            if (tableName == Constants.Tables.Supplier) return "SupplierId";
            if (tableName == Constants.Tables.ProductCategory) return "ProductCategoryId";
            if (tableName == Constants.Tables.Product) return "ProductId";
            if (tableName == Constants.Tables.DepartmentProduct) return "DepartmentProductId";
            if (tableName == Constants.Tables.SupplierProduct) return "SupplierProductId";

            throw new Exception("Неизвестная таблица");
        }

        private void PlaceControl(Label label, Control control)
        {
            int left = 10;

            label.Location = new Point(left, _top);
            groupBox1.Controls.Add(label);

            _top += label.Height + 5;

            control.Location = new Point(left, _top);
            control.Width = 220;
            groupBox1.Controls.Add(control);

            _top += control.Height + 15;
        }

        private Control CreateControlForColumn(string columnName)
        {
            DataColumn column = _row.Table.Columns[columnName];
            Control control;

            if (columnName.EndsWith("Id"))
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Tag = columnName;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                return comboBox;
            }

            if (column.DataType == typeof(string))
            {
                control = new TextBox();
            }
            else if (column.DataType == typeof(int))
            {
                NumericUpDown numeric = new NumericUpDown();
                numeric.Maximum = int.MaxValue;
                control = numeric;
            }
            else
            {
                throw new NotSupportedException("Тип не поддерживается: " + column.DataType.Name);
            }

            control.Tag = columnName;
            return control;
        }

        private void FillControlValue(Control control, string columnName)
        {
            if (control is TextBox textBox)
            {
                textBox.Text = _row[columnName].ToString();
            }
            else if (control is NumericUpDown numeric)
            {
                int.TryParse(_row[columnName].ToString(), out int value);
                numeric.Value = value;
            }
            else if (control is ComboBox comboBox)
            {
                string relatedTableName = GetRelatedTableName(columnName);
                var table = _databaseManager.GetTable(relatedTableName);

                comboBox.DataSource = table;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = columnName;

                long.TryParse(_row[columnName].ToString(), out long selectedId);
                if (selectedId > 0)
                    comboBox.SelectedValue = selectedId;
            }
        }

        private string GetRelatedTableName(string columnName)
        {
            if (columnName == "PurchaseId") return Constants.Tables.Purchase;
            if (columnName == "SaleId") return Constants.Tables.Sale;
            if (columnName == "StoreId") return Constants.Tables.Store;
            if (columnName == "DepartmentId") return Constants.Tables.Department;
            if (columnName == "SupplierId") return Constants.Tables.Supplier;
            if (columnName == "ProductCategoryId") return Constants.Tables.ProductCategory;
            if (columnName == "ProductId") return Constants.Tables.Product;

            throw new Exception("Неизвестная связь");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is Label) continue;

                string columnName = control.Tag.ToString();

                if (control is TextBox textBox)
                {
                    _row[columnName] = textBox.Text;
                }
                else if (control is NumericUpDown numeric)
                {
                    _row[columnName] = (int)numeric.Value;
                }
                else if (control is ComboBox comboBox)
                {
                    _row[columnName] = comboBox.SelectedValue;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
