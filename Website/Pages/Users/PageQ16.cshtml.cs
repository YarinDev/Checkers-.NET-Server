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
            var ids = _context.TblUsers.Select(row => row.Id).Distinct();


            var games =
                from user in _context.TblUsers
                from id in ids
                from game in _context.TblGames
                       .Where(row => row.UserId == id && row.UserId == user.Id)
                        .OrderByDescending(row => row.Date)
                        .Take(1)
                select new MyA { Name = user.Name, Date = game.Date };

            MyA = await games.ToArrayAsync();


        }

    }
}
