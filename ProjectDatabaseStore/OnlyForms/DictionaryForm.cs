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
    public partial class DictionaryForm : Form
    {
        private readonly DatabaseManager _databaseManager;
        private readonly string _tableName;

        public DictionaryForm(DatabaseManager databaseManager, string tableName)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
            _tableName = tableName;
            Text = "Справочник: " + tableName;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _databaseManager.LoadTable(_tableName);
            dataGridView1.DataSource = _databaseManager.GetTable(_tableName);

            DataVisualHelper.MakeGridReadOnly(dataGridView1);
            DataVisualHelper.LocalizeTable(_tableName, dataGridView1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UniversalEditForm form = new UniversalEditForm(_databaseManager);

            DataRow row = _databaseManager.CreateNewRow(_tableName);
            form.EditRow = row;

            if (form.ShowDialog() == DialogResult.OK)
            {
                _databaseManager.AddNewRow(_tableName, form.EditRow);
            }
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var gridRow = dataGridView1.SelectedRows
                .Cast<DataGridViewRow>()
                .FirstOrDefault();

            if (gridRow == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }

            var result = MessageBox.Show(
                "Удалить выбранную запись?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return;

            DataRow row = ((DataRowView)gridRow.DataBoundItem).Row;
            _databaseManager.DeleteRow(row);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_databaseManager.SaveChanges(_tableName))
            {
                MessageBox.Show("Изменения сохранены.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var gridRow = dataGridView1.SelectedRows
               .Cast<DataGridViewRow>()
               .FirstOrDefault();

            if (gridRow == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }

            DataRow row = ((DataRowView)gridRow.DataBoundItem).Row;

            UniversalEditForm form = new UniversalEditForm(_databaseManager);
            form.EditRow = row;
            form.ShowDialog();
        }
    }
}
