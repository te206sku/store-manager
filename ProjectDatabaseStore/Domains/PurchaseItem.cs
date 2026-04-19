using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectDatabaseStore.Domains
{
    public class PurchaseItem
    {
        public long PurchaseItemId { get; set; }
        public long PurchaseId { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public PurchaseItem()
        {
            Price = 0;
            Quantity = 0;
        }

        public PurchaseItem(DataRow row)
        {
            PurchaseItemId = (long)row["PurchaseItemId"];

            long.TryParse(row["PurchaseId"].ToString(), out long purchaseId);
            PurchaseId = purchaseId;

            long.TryParse(row["ProductId"].ToString(), out long productId);
            ProductId = productId;

            int.TryParse(row["Price"].ToString(), out int price);
            Price = price;

            int.TryParse(row["Quantity"].ToString(), out int quantity);
            Quantity = quantity;
        }
    }
}
