using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabaseStore.Domains
{
    public class DepartmentProduct
    {
        public long DepartmentProductId { get; set; }
        public long DepartmentId { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public DepartmentProduct()
        {
            Price = 0;
            Quantity = 0;
        }

        public DepartmentProduct(DataRow row)
        {
            DepartmentProductId = (long)row["DepartmentProductId"];

            long.TryParse(row["DepartmentId"].ToString(), out long departmentId);
            DepartmentId = departmentId;

            long.TryParse(row["ProductId"].ToString(), out long productId);
            ProductId = productId;

            int.TryParse(row["Price"].ToString(), out int price);
            Price = price;

            int.TryParse(row["Quantity"].ToString(), out int quantity);
            Quantity = quantity;
        }
    }
}
