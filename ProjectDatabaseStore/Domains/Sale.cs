using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjectDatabaseStore.Domains
{
    public class Sale
    {
        public long SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public long StoreId { get; set; }
        public long DepartmentId { get; set; }

        public Sale()
        {
            SaleDate = DateTime.Today;
        }

        public Sale(DataRow row)
        {
            SaleId = (long)row["SaleId"];

            DateTime.TryParse(row["SaleDate"].ToString(), out DateTime saleDate);
            SaleDate = saleDate;

            long.TryParse(row["StoreId"].ToString(), out long storeId);
            StoreId = storeId;

            long.TryParse(row["DepartmentId"].ToString(), out long departmentId);
            DepartmentId = departmentId;
        }
    }
}
