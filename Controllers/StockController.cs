using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
namespace backend.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class StockController:Controller
    {
        private readonly OraDbContext _context;

        public StockController(OraDbContext context)
        {
            _context = context;
        }
        [HttpGet("{Product_id}")]
        public async Task<IActionResult> GetStock(string Product_id)
        {
           var result = await _context.Stocks.Where(e => e.Product_id.Contains(Product_id)).ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("AddStocks")]
        public async Task<Stock> AddStock(Stock ObjStocks)
        {
            _context.Stocks.Add(ObjStocks);
            await _context.SaveChangesAsync();
            return ObjStocks;
        }
         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(int id, Stock objstock)
        {
            if (objstock.Id != id)
            {
                return NotFound();
            }
            _context.Entry(objstock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var updatedStocks = _context.Stocks.FindAsync(id);
            return NoContent();
        }
    }
}