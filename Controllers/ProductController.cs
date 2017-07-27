using System;
using System.Collections.Generic;
using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private BangazonContext _context;
        public ProductController(BangazonContext ctx)
        {
            _context = ctx;
        }

        // GET all products from product table
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> products = _context.Product.Include("OrderProducts.Order");

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        //GET one product on product table
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Product product = _context.Product.Single(m => m.ProductId == id);

                if (product == null)
                {
                    return NotFound();
                }
                
                return Ok(product);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST new Product on product table
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Product.Add(product);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ProductId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetProduct", new { id = product.ProductId }, product);
        }

    private bool ProductExists(int productId)
    {
      throw new NotImplementedException();
    }

    // PUT edit values on a product
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }


        // DELETE product from product table
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = _context.Product.Single(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}