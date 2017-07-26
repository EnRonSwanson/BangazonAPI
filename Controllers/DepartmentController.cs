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
    public class DepartmentController : Controller
    {

        private BangazonContext _context;
        public DepartmentController(BangazonContext ctx)
        {
            _context = ctx;
        }

        // GET all Deparments from department table
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> departments = from department in _context.Department select department;

            if (departments == null)
            {
                return NotFound();
            }

            return Ok(departments);
        }

        //GET one department from department table
        [HttpGet("{id}", Name = "GetDepartment")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Department department = _context.Department.Single(m => m.DepartmentId == id);

                if (department == null)
                {
                    return NotFound();
                }
                
                return Ok(department);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST department values to the department table
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Department.Add(department);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(department.DepartmentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("PostDepartment", new { id = department.DepartmentId }, department);
        }

    private bool DepartmentExists(int departmentId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing department
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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