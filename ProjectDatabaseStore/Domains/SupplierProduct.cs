using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace ProjectDatabaseStore.Domains
{
    public class SupplierProduct
    {
        public long SupplierProductId { get; set; }
        public long SupplierId { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public SupplierProduct()
        {
            Price = 0;
            Quantity = 0;
        }

        public SupplierProduct(DataRow row)
        {
            SupplierProductId = (long)row["SupplierProductId"];

            long.TryParse(row["SupplierId"].ToString(), out long supplierId);
            SupplierId = supplierId;

            long.TryParse(row["ProductId"].ToString(), out long productId);
            ProductId = productId;

            int.TryParse(row["Price"].ToString(), out int price);
            Price = price;

            int.TryParse(row["Quantity"].ToString(), out int quantity);
            Quantity = quantity;
        }
    }
}