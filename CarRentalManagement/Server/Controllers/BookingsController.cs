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
    public class BookingsController : ControllerBase
    {
        //refactor
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //refactor
        public BookingsController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        //public BookingsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Bookings

        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        //{
        //  if (_context.Bookings == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Bookings.ToListAsync();
        //}
        //refractored
        public async Task<IActionResult> GetBookings()
        {
            var Bookings = await _unitOfWork.Bookings.GetAll(includes: q => q.Include(x => x.Vehicle).Include(x => x.Customer));
            return Ok(Bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        //Refractored 
        //public async Task<ActionResult<Booking>> GetBooking(int id)
        //{
        //  if (_context.Bookings == null)
        //  {
        //      return NotFound();
        //  }
        //    var Booking = await _context.Bookings.FindAsync(id);

        //    if (Booking == null)
        //    {
        //        return NotFound();
        //    }

        //    return Booking;
        //}

        public async Task<IActionResult> GetBooking(int id)
        {
            var Booking = await _unitOfWork.Bookings.Get(q => q.id == id);
            if (Booking == null)
            {
                return NotFound();
            }
            return Ok(Booking);
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking Booking)
        {
            if (id != Booking.id)
            {
                return BadRequest();
            }
            //refractored
            //_context.Entry(Booking).State = EntityState.Modified;
            _unitOfWork.Bookings.Update(Booking);

            try
            {
                //refractored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BookingExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
                if (!await BookingExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking Booking)
        {
          //if (_context.Bookings == null)
          //{
          //    return Problem("Entity set 'ApplicationDbContext.Bookings'  is null.");
          //}
          //  _context.Bookings.Add(Booking);
          //  await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Insert(Booking);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBooking", new { id = Booking.id }, Booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var Booking = await _unitOfWork.Bookings.Get(q => q.id==id);
            if (Booking == null)
            {
                return NotFound();
            }
            //    if (_context.Bookings == null)
            //    {
            //        return NotFound();
            //    }
            //    var Booking = await _context.Bookings.FindAsync(id);
            //    if (Booking == null)
            //    {
            //        return NotFound();
            //    }

            //    _context.Bookings.Remove(Booking);
            //    await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
            //    return NoContent();
        }

        //private bool BookingExists(int id)
        //{
        //    return (_context.Bookings?.Any(e => e.id == id)).GetValueOrDefault();
        //}
        private async Task<bool> BookingExists(int id)
        {
            var Booking = await _unitOfWork.Bookings.Get(q => q.id == id);
            return Booking != null;
        }
    }
}
