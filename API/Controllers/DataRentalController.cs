using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalMotorApp.Models;

namespace RentalMotorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataRentalController : ControllerBase
    {
        private readonly RentalDbContext _context;

        public DataRentalController(RentalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataRental>>> GetAll()
        {
            // Include data Motor-nya juga
            var data = await _context.datarental
                                     .Include(r => r.Motor)
                                     .ToListAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataRental>> GetById(int id)
        {
            var rental = await _context.datarental
                                       .Include(r => r.Motor)
                                       .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
                return NotFound();

            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult<DataRental>> Create([FromBody] DataRental rental)
        {
            _context.datarental.Add(rental);
            await _context.SaveChangesAsync();

            // Include Motor agar langsung bisa di-return lengkap
            await _context.Entry(rental).Reference(r => r.Motor).LoadAsync();

            return CreatedAtAction(nameof(GetById), new { id = rental.Id }, rental);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DataRental updatedRental)
        {
            var rental = await _context.datarental.FindAsync(id);
            if (rental == null)
                return NotFound();

            rental.IdMotor = updatedRental.IdMotor;
            rental.Nama = updatedRental.Nama;
            rental.NoTelpon = updatedRental.NoTelpon;
            rental.Email = updatedRental.Email;
            rental.StatusSewa = updatedRental.StatusSewa;
            rental.TanggalSewa = updatedRental.TanggalSewa;
            rental.LamaSewa = updatedRental.LamaSewa;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rental = await _context.datarental.FindAsync(id);
            if (rental == null)
                return NotFound();

            _context.datarental.Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
