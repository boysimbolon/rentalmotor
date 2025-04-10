using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalMotorApp.Models;

namespace RentalMotorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotorController : ControllerBase
    {
        private readonly RentalDbContext _context;

        public MotorController(RentalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motor>>> GetAll()
        {
            return await _context.motor.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Motor>> GetById(int id)
        {
            var motor = await _context.motor.FindAsync(id);
            if (motor == null) return NotFound();
            return Ok(motor);
        }

        [HttpPost]
        public async Task<ActionResult<Motor>> Create([FromBody] Motor motor)
        {
            _context.motor.Add(motor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = motor.Id }, motor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Motor updatedMotor)
        {
            var motor = await _context.motor.FindAsync(id);
            if (motor == null) return NotFound();

            motor.NamaMotor = updatedMotor.NamaMotor;
            motor.PlatMotor = updatedMotor.PlatMotor;
            motor.HargaSewa = updatedMotor.HargaSewa;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var motor = await _context.motor.FindAsync(id);
            if (motor == null) return NotFound();

            _context.motor.Remove(motor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
