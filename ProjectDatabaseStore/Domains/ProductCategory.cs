using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabaseStore.Domains
{
    public class ProductCategory
    {
        public long ProductCategoryId { get; set; }
        public string Name { get; set; }

        public ProductCategory()
        {
        }

        public ProductCategory(DataRow row)
        {
            ProductCategoryId = (long)row["ProductCategoryId"];
            Name = row["Name"].ToString();
        }
    }
}
