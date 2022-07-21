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

        public IList<TblUsers> TblUsers { get;set; }

        public async Task OnGetAsync()
        {
            TblUsers = await _context.TblUsers.ToListAsync();
        }
    }
}
