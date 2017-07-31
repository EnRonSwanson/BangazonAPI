using System;
using System.Collections.Generic;
using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

//RYAN WROTE THIS CONTROLLER
//THE REST OF THE TEAM TESTED

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        //BEGIN GETTING THE MODLES FROM BANGAZONCONTEXT
        private BangazonContext _context;
        public OrderController(BangazonContext ctx)
        {
            _context = ctx;
        }
        //END

        // GET api/values
        // BEGIN THE SETUP FOR GET/GETS ALL ORDERS
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> order = _context.Order.Include("OrderProducts.Product");

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        //Get individual order, given order id
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Order order = _context.Order.Include("OrderProducts.Product").Single(m => m.OrderId == id);
                                
                if (order == null)
                {
                    return NotFound();
                }
                
                return Ok(order);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }
        //END SETUP FOR GET

        // POST api/values
        //BEGIN SETUP FOR POST/INSERT INTO A NEW TABLE
        [HttpPost]
        public IActionResult Post([FromBody] BuyerProduct buyerProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = new Order(){CustomerId=buyerProduct.BuyerId};
            _context.Order.Add(order);
            OrderProduct orderProduct = new OrderProduct(){OrderId=order.OrderId, ProductId = buyerProduct.ProductId};
            _context.OrderProduct.Add(orderProduct);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.OrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetOrder", new { id = order.OrderId }, order);
        }

        //Post a product to an existing order
        [HttpPost("/api/order/{id}/AddNewProduct")]
         public IActionResult Post([FromRoute]int id, [FromBody] BuyerProduct buyerProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OrderProduct orderProduct = new OrderProduct(){OrderId=id, ProductId = buyerProduct.ProductId};
            _context.OrderProduct.Add(orderProduct);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }
        //END SETUP FOR POST

    //CHECKS TO SEE IF AN EMPLOYEE HAS BEEN CREATED OR NOT
    private bool OrderExists(int orderId)
    {
      throw new NotImplementedException();
    }



    //BEGIN SETUP FOR PUT/EDIT THE ORDER BY ORDERID
    //Add a payment type to an order (add in the payment type Id)
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        //END SETUP FOR PUT


        //BEGIN SETUP FOR DELETE BY ORDERID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order order = _context.Order.Single(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }
        //END SETUP FOR DELETE


    }
}
