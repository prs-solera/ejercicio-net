using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCars.Data;
using MvcCars.Models;

namespace MvcCars.Controllers
{
    [Route("api/claim")]
    [ApiController]
    public class ClaimsRESTController : ControllerBase
    {
        private readonly MvcCarsContext _context;

        public ClaimsRESTController(MvcCarsContext context)
        {
            _context = context;
        }

        // GET: api/ClaimsREST
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Claim>>> GetClaim()
        {
            return await _context.Claim.ToListAsync();
        }

        // GET: api/ClaimsREST/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Claim>> GetClaim(int id)
        {
            var claim = await _context.Claim.FindAsync(id);

            if (claim == null)
            {
                return NotFound();
            }

            return claim;
        }

        // PUT: api/ClaimsREST/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaim(int id, Claim claim)
        {
            if (id != claim.Id)
            {
                return BadRequest();
            }

            _context.Entry(claim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimExists(id))
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

        // POST: api/ClaimsREST
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Claim>> PostClaim(Claim claim)
        {
            claim.Vehicle = _context.Vehicle.Find(claim.Vehicle.Id);
            _context.Claim.Add(claim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaim", new { id = claim.Id }, claim);
        }

        // DELETE: api/ClaimsREST/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaim(int id)
        {
            var claim = await _context.Claim.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }

            _context.Claim.Remove(claim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClaimExists(int id)
        {
            return _context.Claim.Any(e => e.Id == id);
        }
    }
}
