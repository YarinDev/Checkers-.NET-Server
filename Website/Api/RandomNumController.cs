using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website.Data;
using Website.Model;

namespace Website.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomNumController : ControllerBase
    {
        private readonly WebsiteContext _context;
        Random r = new Random();


        public RandomNumController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: api/RandomNum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RandomNum>>> GetRandomNum()
        {
            return await _context.RandomNum.ToListAsync();
        }

        // GET: api/RandomNum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RandomNum>> GetRandomNum(int id)
        {
            var randomNum = await _context.RandomNum.FindAsync(id);

            randomNum.Num = r.Next(0, randomNum.Num);
            if (randomNum == null)
            {
                return NotFound();
            }

            return randomNum;
        }

        // PUT: api/RandomNum/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRandomNum(int id, RandomNum randomNum)
        {
            if (id != randomNum.Id)
            {
                return BadRequest();
            }

            _context.Entry(randomNum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RandomNumExists(id))
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

        // POST: api/RandomNum
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RandomNum>> PostRandomNum(RandomNum randomNum)
        {
            _context.RandomNum.Add(randomNum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRandomNum", new { id = randomNum.Id }, randomNum);
        }

        // DELETE: api/RandomNum/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RandomNum>> DeleteRandomNum(int id)
        {
            var randomNum = await _context.RandomNum.FindAsync(id);
            if (randomNum == null)
            {
                return NotFound();
            }

            _context.RandomNum.Remove(randomNum);
            await _context.SaveChangesAsync();

            return randomNum;
        }

        private bool RandomNumExists(int id)
        {
            return _context.RandomNum.Any(e => e.Id == id);
        }
    }
}
