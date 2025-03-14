using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace FitnessManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly PostgresContext _context;

        public WorkoutsController(PostgresContext context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        // POST: api/Workouts
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
        {
            await using var tr = await _context.Database.BeginTransactionAsync();

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            await tr.CommitAsync();

            return CreatedAtAction("GetWorkout", new { id = workout.Id }, workout);
        }

        // PUT: api/Workouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, Workout workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            _context.Entry(workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Workouts.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}