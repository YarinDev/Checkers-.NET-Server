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
    public class Q21Model : PageModel
    {

        private readonly Website.Data.WebsiteContext _context;

        public Q21Model(Website.Data.WebsiteContext context)
        {
            _context = context;
        }

        public IList<TblUsers> TblUsers { get; set; }
        public IList<TblGames> TblGames { get; set; }
        public async Task OnGetAsync()
        {

            TblUsers = await _context.TblUsers.ToListAsync();
            TblGames = await _context.TblGames.ToListAsync();

            List<TblGames> GameListOrder = GetListOrderAccordingAmountGame();

            TblUsers = GetUsersListOrderingAccordingAmountPlaying(GameListOrder);



        }

        private List<TblUsers> GetUsersListOrderingAccordingAmountPlaying(List<TblGames> GameListOrder)
        {
            var newUserList = TblUsers.OrderBy(i =>
            {
                TblGames game = new TblGames();
             //   game.user = i.Name;
                game.UserId = (int)i.Id;
                int x = GameListOrder.FindIndex(a => a.UserId == game.UserId);

                if (x == -1)
                {
                    return int.MaxValue;

                }
                return x;
            });
            return newUserList.ToList();
        }


        private List<TblGames> GetListOrderAccordingAmountGame()
        {
            var query =
        (from a in TblGames
         group a by new { a.UserId } into g
         select new TblGames
         {

             GameId = g.Count(),
          //   Name = g.First().Name,
             UserId = g.First().UserId

         }).ToList().OrderByDescending(o => o.GameId).ToList();
            return query;
        }
    }
}