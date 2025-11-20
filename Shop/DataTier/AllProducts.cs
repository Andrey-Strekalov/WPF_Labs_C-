using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class AllProducts
    {

        public static List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();

            list.Add(
                new Product()
                {
                    Code = "001",
                    Name = "OC Windows 11",
                    Count = 10,
                    Price = 40.99f,
                    Description = "Современная операционная система. Версия 11"
                });

            list.Add(
                new Product()
                {
                    Code = "002",
                    Name = "3D Max",
                    Count = 2,
                    Price = 500.99f,
                    Description = "Система визуализации и рендеринга от Autodesk Corp."
                });

            list.Add(
                new Product()
                {
                    Code = "003",
                    Name = "Total Commander 1.00",
                    Count = 100,
                    Price = 0.5f,
                    Description = " - "
                });

            list.Add(
              new Product()
              {
                  Code = "004",
                  Name = "MS SQL Server",
                  Count = 5,
                  Price = 150.00f,
                  Description = " СУБД от Microsoft Corp. "
              });

            return list;
        }

        public static void SaveAllProducts(List<Product> products)
        {

        }
    }
}
