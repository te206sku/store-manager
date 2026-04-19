using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabaseStore
{
    /// <summary>
    /// Класс Constants хранит постоянные значения, которые используются во всём проекте.
    /// В данном проекте внутри него находятся названия таблиц базы данных.
    /// Это нужно для того, чтобы не писать названия таблиц вручную в разных местах программы
    /// и не допускать ошибок в строках.
    /// </summary>
    public static class Constants
    {
        public static class Tables
        {
            public const string Purchase = "Purchase";
            public const string PurchaseItem = "PurchaseItem";
            public const string Sale = "Sale";
            public const string SaleItem = "SaleItem";
            public const string Store = "Store";
            public const string Department = "Department";
            public const string Supplier = "Supplier";
            public const string ProductCategory = "ProductCategory";
            public const string Product = "Product";
            public const string DepartmentProduct = "DepartmentProduct";
            public const string SupplierProduct = "SupplierProduct";
        }
    }
}
