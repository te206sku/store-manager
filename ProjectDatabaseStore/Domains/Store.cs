using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabaseStore.Domains
{
    public class Store
    {
        public long StoreId { get; set; }
        public string Name { get; set; }
        public string StoreClass { get; set; }
        public int StoreNumber { get; set; }
        public string Address { get; set; }

        public Store()
        {
            StoreNumber = 0;
        }

        public Store(DataRow row)
        {
            StoreId = (long)row["StoreId"];
            Name = row["Name"].ToString();
            StoreClass = row["StoreClass"].ToString();

            int.TryParse(row["StoreNumber"].ToString(), out int storeNumber);
            StoreNumber = storeNumber;

            Address = row["Address"].ToString();
        }
    }
}