using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        //refactor
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //refactor
        public MakesController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        //public MakesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Makes

        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        //{
        //  if (_context.Makes == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Makes.ToListAsync();
        //}
        //refractored
        public async Task<IActionResult> GetMakes()
        {
            var makes = await _unitOfWork.Makes.GetAll();
            return Ok(makes);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        //Refractored 
        //public async Task<ActionResult<Make>> GetMake(int id)
        //{
        //  if (_context.Makes == null)
        //  {
        //      return NotFound();
        //  }
        //    var make = await _context.Makes.FindAsync(id);

        //    if (make == null)
        //    {
        //        return NotFound();
        //    }

        //    return make;
        //}

        public async Task<IActionResult> GetMake(int id)
        {
            var make = await _unitOfWork.Makes.Get(q => q.id == id);
            if (make == null)
            {
                return NotFound();
            }
            return Ok(make);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Make make)
        {
            if (id != make.id)
            {
                return BadRequest();
            }
            //refractored
            //_context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Makes.Update(make);

            try
            {
                //refractored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MakeExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
                if (!await MakeExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
          //if (_context.Makes == null)
          //{
          //    return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
          //}
          //  _context.Makes.Add(make);
          //  await _context.SaveChangesAsync();
            await _unitOfWork.Makes.Insert(make);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMake", new { id = make.id }, make);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            var make = await _unitOfWork.Makes.Get(q => q.id==id);
            if (make == null)
            {
                return NotFound();
            }
            //    if (_context.Makes == null)
            //    {
            //        return NotFound();
            //    }
            //    var make = await _context.Makes.FindAsync(id);
            //    if (make == null)
            //    {
            //        return NotFound();
            //    }

            //    _context.Makes.Remove(make);
            //    await _context.SaveChangesAsync();
            await _unitOfWork.Makes.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
            //    return NoContent();
        }

        //private bool MakeExists(int id)
        //{
        //    return (_context.Makes?.Any(e => e.id == id)).GetValueOrDefault();
        //}
        private async Task<bool> MakeExists(int id)
        {
            var make = await _unitOfWork.Makes.Get(q => q.id == id);
            return make != null;
        }
    }
}
