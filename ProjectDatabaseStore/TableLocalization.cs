using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabaseStore
{
    /// <summary>
    /// Оказывается писать пояснение ещё та морока 
    /// Класс TableLocalization отвечает за локализацию названий столбцов таблиц.
    /// Он загружает данные из JSON-файла и позволяет заменить технические
    /// названия полей базы данных на понятные русские заголовки для пользователя.
    /// Также этот класс хранит список скрываемых столбцов.
    /// </summary>
    public class TableLocalization
    {
        public List<string> SourceColumns { get; set; }
        public List<string> LocalizeColumns { get; set; }
        public List<string> HideColumns { get; set; }

        public static TableLocalization Load(string tableName)
        {
            string filename = Path.Combine("LocalizeTables", $"Table{tableName}.json");

            if (!File.Exists(filename))
                return null;

            string jsonString = File.ReadAllText(filename);

            return JsonConvert.DeserializeObject<TableLocalization>(jsonString);
        }

        public string GetLocale(string columnName)
        {
            string result = columnName;

            int index = SourceColumns.IndexOf(columnName);
            if (index > -1)
                result = LocalizeColumns[index];

            return result;
        }
    }
}
