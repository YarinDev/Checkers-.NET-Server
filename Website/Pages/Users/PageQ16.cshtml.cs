using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Website.Model;

namespace Website.Pages.Users
{
    public class PageQ16Model : PageModel
    {
        private readonly Website.Data.WebsiteContext _context;

        public PageQ16Model(Website.Data.WebsiteContext context)
        {
            _context = context;
        }
        public IList<MyA> MyA { get; set; }

        public async Task OnGetAsync()
        {
            var x =
                 from u in _context.TblUsers
                 join g in _context.TblGames on u.Id equals g.UserId
                 select new MyA { Name = u.Name, Date = g.Date };

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
    
    }
}
