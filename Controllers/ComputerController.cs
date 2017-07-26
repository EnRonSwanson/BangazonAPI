using System;
using System.Collections.Generic;
using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// mitchell wrote and commented this file
// team also tested before merging

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class ComputerController : Controller
    {

        private BangazonContext _context;
        public ComputerController(BangazonContext ctx)
        {
            _context = ctx;
        }

        // GET all computers from the computer table
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> computers = from computer in _context.Computer select computer;

            if (computers == null)
            {
                return NotFound();
            }

            return Ok(computers);
        }

        // GET one computer from the computer table by its id
        [HttpGet("{id}", Name = "GetComputer")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Computer computer = _context.Computer.Single(m => m.ComputerId == id);

                if (computer == null)
                {
                    return NotFound();
                }
                
                return Ok(computer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Computer.Add(computer);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComputerExists(computer.ComputerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetComputer", new { id = computer.ComputerId }, computer);
        }

    private bool ComputerExists(int computerId)
    {
      throw new NotImplementedException();
    }

    // PUT
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computer.ComputerId)
            {
                return BadRequest();
            }

            _context.Entry(computer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(id))
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

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Computer computer = _context.Computer.Single(m => m.ComputerId == id);
            if (computer == null)
            {
                return NotFound();
            }

            _context.Computer.Remove(computer);
            _context.SaveChanges();

            return Ok(computer);
        }
    }
}