using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Website.Data;
using Website.Model;

namespace Website.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly Website.Data.WebsiteContext _context;

        public DetailsModel(Website.Data.WebsiteContext context)
        {
            _context = context;
        }

        public TblGames TblGames { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblGames = await _context.TblGames.FirstOrDefaultAsync(m => m.GameId == id);

            if (TblGames == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
