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
    public class ProductTypeController : Controller
    {

        private BangazonContext _context;
        public ProductTypeController (BangazonContext ctx)
        {
            _context = ctx;
        }

        //GET all ProductType from productType table
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> productTypes = from productType in _context.ProductType select productType;

            if (productTypes == null)
            {
                return NotFound();
            }

            return Ok(productTypes);
        }

        //GET one productType from productType table
        [HttpGet("{id}", Name = "GetProductType")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProductType productType = _context.ProductType.Single(m => m.ProductTypeId == id);

                if (productType == null)
                {
                    return NotFound();
                }
                
                return Ok(productType);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        //POST productTypes to the productType table
        [HttpPost]
        public IActionResult Post([FromBody] ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductType.Add(productType);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductTypeExists(productType.ProductTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("PostProductType", new { id = productType.ProductTypeId }, productType);
        }

    private bool ProductTypeExists(int productTypeId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing productType
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productType.ProductTypeId)
            {
                return BadRequest();
            }

            _context.Entry(productType).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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

        // DELETE api/producttype/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductType productType = _context.ProductType.Single(m => m.ProductTypeId == id);
            if (productType == null)
            {
                return NotFound();
            }

            _context.ProductType.Remove(productType);
            _context.SaveChanges();

            return Ok(productType);
        }
    }
}
