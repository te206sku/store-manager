using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabaseStore.Domains
{
    public class SaleItem
    {
        public long SaleItemId { get; set; }
        public long SaleId { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public SaleItem()
        {
            Price = 0;
            Quantity = 0;
        }

        public SaleItem(DataRow row)
        {
            SaleItemId = (long)row["SaleItemId"];

            long.TryParse(row["SaleId"].ToString(), out long saleId);
            SaleId = saleId;

            long.TryParse(row["ProductId"].ToString(), out long productId);
            ProductId = productId;

            int.TryParse(row["Price"].ToString(), out int price);
            Price = price;

            int.TryParse(row["Quantity"].ToString(), out int quantity);
            Quantity = quantity;
        }
    }
}
