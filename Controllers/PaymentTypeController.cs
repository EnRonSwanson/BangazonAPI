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
    public class PaymentTypeController : Controller
    {

        private BangazonContext _context;
        public PaymentTypeController(BangazonContext ctx)
        {
            _context = ctx;
        }

        // GET all payment types from the payment type table
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> paymentTypes = from paymentType in _context.PaymentType select paymentType;

            if (paymentTypes == null)
            {
                return NotFound();
            }

            return Ok(paymentTypes);
        }

        // GET one training program from the training program table by its id
        [HttpGet("{id}", Name = "GetPaymentType")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                PaymentType paymentType = _context.PaymentType.Single(m => m.PaymentTypeId == id);

                if (paymentType == null)
                {
                    return NotFound();
                }
                
                return Ok(paymentType);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST a new training program to the db. Id is auto generated.
        [HttpPost]
        public IActionResult Post([FromBody] PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentType.Add(paymentType);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentTypeExists(paymentType.PaymentTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetPaymentType", new { id = paymentType.PaymentTypeId }, paymentType);
        }

    private bool PaymentTypeExists(int paymentTypeId)
    {
      throw new NotImplementedException();
    }

    // PUT any edits to the training program by id
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentType.PaymentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(paymentType).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
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

        // DELETE a training program at that id from the db
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PaymentType paymentType = _context.PaymentType.Single(m => m.PaymentTypeId == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            _context.PaymentType.Remove(paymentType);
            _context.SaveChanges();

            return Ok(paymentType);
        }
    }
}