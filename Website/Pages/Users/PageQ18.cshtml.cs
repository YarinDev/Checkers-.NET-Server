using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Website.Model;


namespace Website.Pages.Users
{
    public class PageQ18Model : PageModel
    {
        private readonly Website.Data.WebsiteContext _context;

        public PageQ18Model(Website.Data.WebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<TblUsers> TblUsers { get; set; }
        public string Name { get; set; }
       // public IList<Q19Model> Q19Model { get; set; } = new List<Q19Model>();
        public IList<TblGames> TblGames { get; set; }
        /*
        public async Task OnGetAsync()
        {
            TblUsers = await _context.TblUsers.ToListAsync();
            Name = _context.TblUsers.Select(user=>user.Name).FirstOrDefault();
        }
        */
        public async Task OnGetAsync()
        {

            TblGames = await _context.TblGames.ToListAsync();
            TblGames = TblGames.Distinct(new GameEqualityComparer()).ToList();

        }
    }
}





class GameEqualityComparer : IEqualityComparer<TblGames>
{
    public bool Equals([AllowNull] TblGames x, [AllowNull] TblGames y)
    {
        return x.UserId == y.UserId;

    }


    public int GetHashCode([DisallowNull] TblGames obj)
    {

        return obj.UserId.GetHashCode();
    }
}






/*
 public async Task<IActionResult> OnPostQ19Async()
 {

     var u =  _context.TblUsers.Where(user => user.Name == Name).Select(async user => await user.Id).FirstOrDefault();

      var games  = await
         (from user in  _context.TblUsers
         from game in _context.TblGames
                .Where(row => row.UserId == u)

         select new Q19Model { UserId = game.UserId, GameId = game.GameId }).ToArrayAsync();

     Q19Model = games;


     return Page();


 }
*/