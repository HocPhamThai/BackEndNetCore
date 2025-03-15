using DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BackEndNetCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await productService.GetProducts();
                return Ok(products);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
