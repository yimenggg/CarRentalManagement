﻿using System;
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
    public class ColoursController : ControllerBase
    {
        //refactor
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //refactor
        public ColoursController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        //public ColoursController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Colours

        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Colour>>> GetColours()
        //{
        //  if (_context.Colours == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Colours.ToListAsync();
        //}
        //refractored
        public async Task<IActionResult> GetColours()
        {
            var Colours = await _unitOfWork.Colours.GetAll();
            return Ok(Colours);
        }

        // GET: api/Colours/5
        [HttpGet("{id}")]
        //Refractored 
        //public async Task<ActionResult<Colour>> GetColour(int id)
        //{
        //  if (_context.Colours == null)
        //  {
        //      return NotFound();
        //  }
        //    var Colour = await _context.Colours.FindAsync(id);

        //    if (Colour == null)
        //    {
        //        return NotFound();
        //    }

        //    return Colour;
        //}

        public async Task<IActionResult> GetColour(int id)
        {
            var Colour = await _unitOfWork.Colours.Get(q => q.id == id);
            if (Colour == null)
            {
                return NotFound();
            }
            return Ok(Colour);
        }

        // PUT: api/Colours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColour(int id, Colour Colour)
        {
            if (id != Colour.id)
            {
                return BadRequest();
            }
            //refractored
            //_context.Entry(Colour).State = EntityState.Modified;
            _unitOfWork.Colours.Update(Colour);

            try
            {
                //refractored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ColourExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
                if (!await ColourExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Colours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colour>> PostColour(Colour Colour)
        {
          //if (_context.Colours == null)
          //{
          //    return Problem("Entity set 'ApplicationDbContext.Colours'  is null.");
          //}
          //  _context.Colours.Add(Colour);
          //  await _context.SaveChangesAsync();
            await _unitOfWork.Colours.Insert(Colour);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetColour", new { id = Colour.id }, Colour);
        }

        // DELETE: api/Colours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColour(int id)
        {
            var Colour = await _unitOfWork.Colours.Get(q => q.id==id);
            if (Colour == null)
            {
                return NotFound();
            }
            //    if (_context.Colours == null)
            //    {
            //        return NotFound();
            //    }
            //    var Colour = await _context.Colours.FindAsync(id);
            //    if (Colour == null)
            //    {
            //        return NotFound();
            //    }

            //    _context.Colours.Remove(Colour);
            //    await _context.SaveChangesAsync();
            await _unitOfWork.Colours.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
            //    return NoContent();
        }

        //private bool ColourExists(int id)
        //{
        //    return (_context.Colours?.Any(e => e.id == id)).GetValueOrDefault();
        //}
        private async Task<bool> ColourExists(int id)
        {
            var Colour = await _unitOfWork.Colours.Get(q => q.id == id);
            return Colour != null;
        }
    }
}
