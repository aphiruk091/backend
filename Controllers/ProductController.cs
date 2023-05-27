using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
namespace backend.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductController:Controller
    {
        private readonly OraDbContext _context;

        public ProductController(OraDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> Get()
        {
             var result = await (from product in _context.Products
                    join stock in _context.Stocks on product.Product_id equals stock.Product_id into joinedTable 
                    from data in joinedTable.DefaultIfEmpty()
                    select new ProductStock
                    {
                        Id = product.Id,
                        Product_id = product.Product_id,
                        Product_Name = product.Product_Name,
                        Price = product.Price,
                        Stock = data
                        
                    }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("AddProducts")]
        public async Task<Product> AddProduct(Product ObjProducts)
        {
            _context.Products.Add(ObjProducts);
            await _context.SaveChangesAsync();
            return ObjProducts;
        }

    }
}