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
    public class TblUsersController : ControllerBase
    {
        private readonly WebsiteContext _context;

        public TblUsersController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: api/TblUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUsers>>> GetTblUsers()
        {
            return await _context.TblUsers.ToListAsync();
        }

        // GET: api/TblUsers/pname/yarin
        [Route(("pname/{name}"))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUsers>>> GetTblUsers(String name)
        {
            return await _context.TblUsers.Where(p => p.Name == name).ToListAsync();
        }

        // GET: api/TblUsers/pname/yarin/1/0542036608
        [Route(("pname/{name}/{id}/{phone}"))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUsers>>> GetTblUsers(String name, int id, String phone)
        {
            return await _context.TblUsers.Where(p => p.Name == name && p.Id == id && p.Phone == phone).ToListAsync();
        }
        // GET: api/TblUsers/pname/1/2
        [Route(("pname/{id}/{num}"))]
        [HttpGet]
        public async Task<ActionResult<TblUsers>> GetTblUsers(int id, int num)
        {
            var tblUsers = await _context.TblUsers.FindAsync(id);
            Random rand = new Random();
            tblUsers.Num = rand.Next(0, num);
            return tblUsers;
        }

        // GET: api/TblUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUsers>> GetTblUsers(int id)
        {
            var tblUsers = await _context.TblUsers.FindAsync(id);


            if (tblUsers == null)
            {
                return NotFound();
            }

            return tblUsers;
        }

       /* // GET: api/TblUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUsers>> GetUserRand(int id)
        {
            var tblUsers = await _context.TblUsers.FindAsync(id);
            int num = tblUsers.Num;
            Random rand = new Random();

            if (tblUsers == null)
            {
                return NotFound();
            }
            tblUsers.Num = rand.Next(0, num);
            return tblUsers;
        }*/

        // PUT: api/TblUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUsers(int id, TblUsers tblUsers)
        {
            if (id != tblUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUsersExists(id))
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

        // POST: api/TblUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblUsers>> PostTblUsers(TblUsers tblUsers)
        {
            _context.TblUsers.Add(tblUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUsers", new { id = tblUsers.Id }, tblUsers);
        }

        // DELETE: api/TblUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblUsers>> DeleteTblUsers(int id)
        {
            var tblUsers = await _context.TblUsers.FindAsync(id);
            if (tblUsers == null)
            {
                return NotFound();
            }


            _context.TblUsers.Remove(tblUsers);
            await _context.SaveChangesAsync();

            return tblUsers;
        }

        private bool TblUsersExists(int id)
        {
            return _context.TblUsers.Any(e => e.Id == id);
        }
    }
}
