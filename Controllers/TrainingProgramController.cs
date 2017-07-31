using System;
using System.Collections.Generic;
using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// mitchell wrote and commented training program controller
// team also tested before merging

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class TrainingProgramController : Controller
    {

        private BangazonContext _context;
        public TrainingProgramController(BangazonContext ctx)
        {
            _context = ctx;
        }

        // GET all training programs from the training program table
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> trainingPrograms = from trainingProgram in _context.TrainingProgram select trainingProgram;

            if (trainingPrograms == null)
            {
                return NotFound();
            }

            return Ok(trainingPrograms);
        }

        // GET one training program from the training program table by its id
        [HttpGet("{id}", Name = "GetTrainingProgram")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                TrainingProgram trainingProgram = _context.TrainingProgram.Single(m => m.TrainingProgramId == id);

                if (trainingProgram == null)
                {
                    return NotFound();
                }
                
                return Ok(trainingProgram);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST a new training program to the db. Id is auto generated.
        [HttpPost]
        public IActionResult Post([FromBody] TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrainingProgram.Add(trainingProgram);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingProgramExists(trainingProgram.TrainingProgramId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTrainingProgram", new { id = trainingProgram.TrainingProgramId }, trainingProgram);
        }

    private bool TrainingProgramExists(int trainingProgramId)
    {
      throw new NotImplementedException();
    }

    // PUT any edits to the training program by id
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingProgram.TrainingProgramId)
            {
                return BadRequest();
            }

            _context.Entry(trainingProgram).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingProgramExists(id))
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

        // DELETE a training program at that id from the db ONLY if the program's date is in the future
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrainingProgram trainingProgram = _context.TrainingProgram.Single(m => m.TrainingProgramId == id);
            if (trainingProgram == null)
            {
                return NotFound();
            }

            int dateDifference = DateTime.Compare(trainingProgram.StartDate, DateTime.Today);
            if (dateDifference > 0)
            {
                _context.TrainingProgram.Remove(trainingProgram);
            }
            else
            {
                return BadRequest(ModelState);
            }

            _context.SaveChanges();

            return Ok(trainingProgram);
        }
    }
}