using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabaseStore.Domains
{
    /// <summary>
    /// принцесса моя уже 2 а я теперь пишу пояснение для тебя хз когда закончу но очень тебя люблю не обижайся если завтра буду немножко злой 
    /// Класс Product описывает сущность "Товар".
    /// В нём хранятся основные характеристики товара: идентификатор, название,
    /// сорт, цена, количество, а также ссылки на отдел и поставщика.
    /// Этот класс нужен для представления записи из таблицы Products
    /// как объекта программы.
    /// </summary>
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Sort { get; set; }
        public long ProductCategoryId { get; set; }

        public Product()
        {
        }

        public Product(DataRow row)
        {
            ProductId = (long)row["ProductId"];
            Name = row["Name"].ToString();
            Sort = row["Sort"].ToString();

            long.TryParse(row["ProductCategoryId"].ToString(), out long productCategoryId);
            ProductCategoryId = productCategoryId;
        }
    }
}
