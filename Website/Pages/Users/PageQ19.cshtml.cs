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
    public class PageQ19Model : PageModel
    {
        private readonly Website.Data.WebsiteContext _context;

        public PageQ19Model(Website.Data.WebsiteContext context)
        {
            _context = context;
        }


        public IList<TblGames> TblGames { get; set; }
        public IList<TblUsers> TblUsers { get; set; }

        [BindProperty]
        public string Name_Id { get; set; }

        public async Task OnGetAsync()
        {

            TblUsers = await _context.TblUsers.ToListAsync();
            TblGames = await _context.TblGames.ToListAsync();
        }


        public async Task OnPostAsync()
        {

            String spearator = " Id: " ;

            // split name and id 
            String[] strlist = Name_Id.Split(spearator,
                               2, StringSplitOptions.None);

            int Id = Int32.Parse(strlist[1]);
            // show only the games that belong user id
            TblGames = await _context.TblGames.Where(i => i.UserId == Id).ToListAsync();
            TblUsers = await _context.TblUsers.ToListAsync();


        }
    }
}