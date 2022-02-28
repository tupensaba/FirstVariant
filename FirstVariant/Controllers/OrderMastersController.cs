using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstVariant.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace FirstVariant.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrderMastersController : ControllerBase
    {
        private readonly GoodsAndOrdersDbContext _context;

        public OrderMastersController(GoodsAndOrdersDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderMasters

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetOrderMaster()
        {
            var orderMaster = await (from OrderMaster in _context.Set<OrderMaster>()
                                     join OrderDetails in _context.Set<OrderDetails>()
                                     on OrderMaster.OrderMasterId equals OrderDetails.OrderMasterId
                                      select new
                                      {
                                          OrderMaster.OrderMasterId,
                                          OrderMaster.Customer,
                                          OrderMaster.OrderDetails,
                                          OrderDetails.GoodItem,
                                          OrderDetails.Quantity
                                          
                                      }
                                      ).ToListAsync();

            return await _context.OrderMaster.ToListAsync();
        }

        [Route("GoodsList")]
        [HttpGet]       
        public async Task<ActionResult<IEnumerable<GoodsModel>>> GetGoodsList()
        {
            return await _context.Goods.ToListAsync();
        }


        [Route("CustomersList")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomersModel>>> GetCustomersList()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/OrderMasters/5
        [HttpGet("{orderMasterId}")]
        public async Task<ActionResult<OrderDetails>> GetOrderMaster(long orderMasterId)
        {
            var orderDetails = await (from OrderDetails in _context.Set<OrderDetails>()
                                      where OrderDetails.OrderMasterId == orderMasterId
                                      select new
                                      {
                                          OrderDetails.OrderMasterId,
                                          OrderDetails.GoodItem,
                                          OrderDetails.Quantity
                                      }
                                      ).ToListAsync();

            if (orderDetails == null)
            {
                return NotFound();
            }

            return Ok(orderDetails);
        }
        [ActionName("ChangeQuantity")]
        [HttpPatch("{orderMasterId},{itemId}")]
        public async Task<IActionResult> Patch(long orderMasterId, int itemId, [FromBody] JsonPatchDocument<OrderDetails> patch)
        {

            var fromDb = _context.OrderDetails.Include(p => p.GoodItem).Where(p => p.OrderMasterId == orderMasterId).Where(p => p.GoodItemId == itemId);

            patch.ApplyTo(fromDb.First(), ModelState);

            _context.Update(fromDb.First());
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/OrderMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("add")]
        [HttpPost]
        public async Task<ActionResult<OrderMaster>> PostOrderMaster(OrderMaster orderMaster)
        {
            _context.OrderMaster.Add(orderMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderMaster", new { id = orderMaster.OrderMasterId }, orderMaster);
        }

        [Route("AddGoodInOrder")]
        [HttpPost]
        public async Task<ActionResult<OrderDetails>> PostOrderMaster(OrderDetails orderDetails)
        {
            _context.OrderDetails.Add(orderDetails);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete("{id},{itemId}")]
        public async Task<IActionResult> DeleteOrderDetail(long id, int itemId)
        {
            IQueryable<OrderDetails> detailsIQuer = _context.OrderDetails;
            detailsIQuer = detailsIQuer.Where(p => p.OrderMasterId == id);
            detailsIQuer = detailsIQuer.Where(p => p.GoodItemId == itemId);
            
            if (detailsIQuer == null)
            {
                return NotFound();
            }

            _context.OrderDetails.RemoveRange(detailsIQuer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/OrderMasters/5
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderMaster(long id)
        {
            var orderMaster = await _context.OrderMaster.FindAsync(id);

            if (orderMaster == null)
            {
                return NotFound();
            }

            _context.OrderMaster.Remove(orderMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderMasterExists(long id)
        {
            return _context.OrderMaster.Any(e => e.OrderMasterId == id);
        }
    }
}
