using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Website.Data;
using Website.Model;

namespace Website.Model.Users
{
    public class IndexModel : PageModel
    {
        private readonly Website.Data.WebsiteContext _context;

        public IndexModel(Website.Data.WebsiteContext context)
        {
            _context = context;
        }

        public IList<TblUsers> TblUsers { get; set; }

        public IList<MyA> MyA { get; set; }
        public async Task OnGetAsync()
        {
            TblUsers = await _context.TblUsers.ToListAsync();
        }
        public async Task OnGetQ15Async()
        {
            TblUsers = await _context.TblUsers.OrderBy(u => u.Name.ToLower()).ToListAsync();
        }

        public async Task OnGetQ16Async()
        {
            var x =
                 from u in _context.TblUsers
                 join g in _context.TblGames on u.Id equals g.UserId
                 select new MyA{ Name = u.Name, Date = g.Date };

            MyA = await x.ToListAsync();
           /* var test = (from a in DataContext.User
                   join b in DataContext.UserTable on a.UserId equals b.UserId
                   select new
                   {
                   UserId = a.UserId,
                   FirstName = b.FirstName
                   LastName = b.LastName
                   }).ToList();*/
        }
     
        public async Task OnGetQ18Async()
        {
            var x =
              from u in _context.TblUsers
              join g in _context.TblGames on u.Id equals g.UserId
              select new MyA { Name = u.Name, Date = g.Date };

            MyA = await x.ToListAsync();
           // TblUsers = await _context.TblUsers.ToListAsync();
        }
        public async Task OnGetQ19Async()
        {
            TblUsers = await _context.TblUsers.ToListAsync();
        }
        public async Task OnGetQ20Async()
        {
            TblUsers = await _context.TblUsers.ToListAsync();
        }

        public async Task OnGetQ21Async()
        {
            TblUsers = await _context.TblUsers.ToListAsync();
        }
    }
}
