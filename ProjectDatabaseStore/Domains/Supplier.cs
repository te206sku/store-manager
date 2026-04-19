using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabaseStore.Domains
{
    /// <summary>
    /// люблю тебя 
    /// Класс Supplier описывает сущность "Поставщик" или "Торговая база".
    /// Он хранит основные сведения о поставщике: идентификатор, название и адрес.
    /// Класс используется для представления данных из таблицы Suppliers
    /// в виде объекта C#.
    /// </summary>
    public class Supplier
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Supplier()
        {
        }

        public Supplier(DataRow row)
        {
            SupplierId = (long)row["SupplierId"];
            Name = row["Name"].ToString();
            Address = row["Address"].ToString();
            Phone = row["Phone"].ToString();
        }
    }
}
