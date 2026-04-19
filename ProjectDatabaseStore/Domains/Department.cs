using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabaseStore.Domains
{
    /// <summary>
    /// Надеюсь тебе это поможет мой любимый котик 
    /// Класс Department описывает сущность "Отдел магазина".
    /// В этом классе хранятся данные об отделе: идентификатор, название отдела
    /// и имя заведующего отделом.
    /// Также класс позволяет создать объект отдела из строки таблицы DataRow,
    /// полученной из базы данных.
    /// </summary>
    public class Department
    {
        public long DepartmentId { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public long StoreId { get; set; }

        public Department()
        {
        }

        public Department(DataRow row)
        {
            DepartmentId = (long)row["DepartmentId"];
            Name = row["Name"].ToString();
            ManagerName = row["ManagerName"].ToString();

            long.TryParse(row["StoreId"].ToString(), out long storeId);
            StoreId = storeId;
        }

    }
}
