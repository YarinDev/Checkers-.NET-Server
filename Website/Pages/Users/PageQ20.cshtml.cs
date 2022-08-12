using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Website.Model;

namespace Website
{
    public class Q20Model : PageModel
    {
        private readonly Website.Data.WebsiteContext _context;

        public Q20Model(Website.Data.WebsiteContext context)
        {
            _context = context;
        }


        public List<TblGames> TblGames { get; set; }


        public IList<GameCountModel> GameCountModel { get; set; }
        public async Task OnGetAsync()
        {
            TblGames = await _context.TblGames.ToListAsync();

            var query =
             from a in TblGames

             group a by new { a.UserId } into g
             select new TblGames
             {

                 UserId = g.Count(),
                 Winner = g.First().Winner

             };


            TblGames = query.ToList();






        }
    }
}