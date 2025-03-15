using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class ProductService : IProductService
    {
        public async Task<List<ProductDTO>> GetProducts()
        {
            var products = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id = 1,
                    ProductName = "Product 1",
                    Price = "100",
                    Image = "Image 1"
                },
                new ProductDTO
                {
                    Id = 2,
                    ProductName = "Product 2",
                    Price = "200",
                    Image = "Image 2"
                },
                new ProductDTO
                {
                    Id = 3,
                    ProductName = "Product 3",
                    Price = "300",
                    Image = "Image 3"
                }
            };
            try
            {
                if (products != null)
                {
                    return products;
                }
                else
                {
                    return [];
                }
            }
            catch (Exception ex0)
            {
                throw;
            }
        }
    }
}
