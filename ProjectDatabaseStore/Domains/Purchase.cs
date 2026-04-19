using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectDatabaseStore.Domains
{
    public class Purchase
    {
        public long PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public long StoreId { get; set; }
        public long SupplierId { get; set; }

        public Purchase()
        {
            PurchaseDate = DateTime.Today;
        }

        public Purchase(DataRow row)
        {
            PurchaseId = (long)row["PurchaseId"];

            DateTime.TryParse(row["PurchaseDate"].ToString(), out DateTime purchaseDate);
            PurchaseDate = purchaseDate;

            long.TryParse(row["StoreId"].ToString(), out long storeId);
            StoreId = storeId;

            long.TryParse(row["SupplierId"].ToString(), out long supplierId);
            SupplierId = supplierId;
        }
    }
}
