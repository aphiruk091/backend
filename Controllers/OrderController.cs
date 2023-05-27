using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
namespace backend.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class OrderController : Controller
    {
        private readonly OraDbContext _context;

        public OrderController(OraDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetOrder")]
        public async Task<IActionResult> GetOrder()
        {
            var result = await (from Order in _context.Orders
                                join product in _context.Products on Order.Product_id equals product.Product_id 
                                into joinedTable
                                from data in joinedTable.DefaultIfEmpty()
                                select new OrderProduct
                                {
                                    Id = Order.Id,
                                    Order_id = Order.Order_id,
                                    Product_id = Order.Product_id,
                                    QTY = Order.QTY,
                                    Status = Order.Status,
                                    Product = data
                                   
                                    
                                }).Where(e => e.Status.Contains("N")).ToListAsync();
            return Ok(result);
        }
        
        [HttpPost]
        [Route("AddOrder")]
        public async Task<Order> AddOrder(Order ObjOrder)
        {
            _context.Orders.Add(ObjOrder);
            await _context.SaveChangesAsync();
            return ObjOrder;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order objOrder)
        {
            if (objOrder.Id != id)
            {
                return NotFound();
            }
            _context.Entry(objOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var updatedOrder = _context.Orders.FindAsync(id);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelOrder(int id)
        {
            var entity = await _context.Orders.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}