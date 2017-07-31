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
    public class EmployeeController : Controller
    {

        //BEGIN GETTING THE MODLES FROM BANGAZONCONTEXT
        private BangazonContext _context;
        public EmployeeController(BangazonContext ctx)
        {
            _context = ctx;
        }
        //END

        // GET api/values
        // BEGIN THE SETUP FOR GET/GETS ALL EMPLOYEES
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> employee = from Employee in _context.Employee select Employee;

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        //END

        //BEGIN GET FOR INDIVIDUAL EMPLOYEE
        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Employee employee = _context.Employee.Single(m => m.EmployeeId == id);

                if (employee == null)
                {
                    return NotFound();
                }
                
                return Ok(employee);
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
        public IActionResult Post([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employee.Add(employee);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(employee.EmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetEmployee", new { id = employee.EmployeeId }, employee);
        }
        //END SETUP FOR POST

    //CHECKS TO SEE IF AN EMPLOYEE HAS BEEN CREATED OR NOT
    private bool OrderExists(int orderId)
    {
      throw new NotImplementedException();
    }


    // PUT api/values/5
    //BEGIN SETUP FOR PUT/EDIT AN EMPLOYEE BY ITS ID
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

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


        //NO DELETE METHOD FOR EMPLOYEE
    }
}
