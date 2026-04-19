using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabaseStore
{
    /// <summary>
    /// я тебя люьлю
    /// Класс DataVisualHelper содержит вспомогательные методы
    /// для настройки внешнего вида таблиц DataGridView.
    /// Он используется для перевода заголовков столбцов,
    /// скрытия служебных полей и настройки режима только для чтения.
    /// Это делает отображение данных более удобным и понятным.
    /// </summary>
    public static class DataVisualHelper
    {
        public static void LocalizeTable(string tableName, DataGridView gridView)
        {
            var localize = TableLocalization.Load(tableName);
            if (localize == null) return;

            for (int i = 0; i < localize.SourceColumns.Count; i++)
            {
                string sourceName = localize.SourceColumns[i];
                string localizeName = localize.LocalizeColumns[i];

                if (gridView.Columns.Contains(sourceName))
                    gridView.Columns[sourceName].HeaderText = localizeName;
            }

            foreach (string columnName in localize.HideColumns)
            {
                if (gridView.Columns.Contains(columnName))
                    gridView.Columns[columnName].Visible = false;
            }
        }

        public static void MakeGridReadOnly(DataGridView gridView)
        {
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.ReadOnly = true;
            gridView.AllowUserToResizeRows = false;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.MultiSelect = false;
        }
    }
}
