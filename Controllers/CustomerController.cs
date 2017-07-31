using System;
using System.Collections.Generic;
using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

// team wrote this first controller together
// mitchell and ryan typed the classes and methods
// adam and madeline tested and commented

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowWhiteListOrigins")]
    public class CustomerController : Controller
    {

        private BangazonContext _context;
        public CustomerController(BangazonContext ctx)
        {
            _context = ctx;
        }

        // GET all Customers from customer table
        // GET ALL USERS WITH THE ACTIVE OF "0"
        [HttpGet]
        public IActionResult Get(string active)
        {
            IQueryable<object> customers = from customerX in _context.Customer select customerX;

            if (customers == null)
            {
                return NotFound();
            } 
            else if(active == "0")
            {
                IQueryable<object> customerY = from customerx in _context.Customer where customerx.Active==0 select customerx;
                return Ok(customerY);
            } 
          
                return Ok(customers);
            
        }

        //GET one customer from customer table
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Customer customer = _context.Customer.Single(m => m.CustomerId == id);

                if (customer == null)
                {
                    return NotFound();
                }
                
                return Ok(customer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }


        // POST customer values to the customer table
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customer.Add(customer);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.CustomerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetCustomer", new { id = customer.CustomerId }, customer);
        }

    //CHECKS TO SEE IF A CUSTOMER HAS BEEN CREATED OR NOT
    private bool CustomerExists(int customerId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing customer
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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
    }
}
