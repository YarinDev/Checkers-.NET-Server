﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Website.Data;
using Website.Model;

namespace Website.Model.Users
{
    public class CreateModel : PageModel
    {
        private readonly Website.Data.WebsiteContext _context;

        public CreateModel(Website.Data.WebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblUsers TblUsers { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblUsers.Add(TblUsers);
            try {
            
             await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
           //     MessageBox.Show(this, "blablablablabla");
            }

            return RedirectToPage("./IdTaken");
        }
    }
}
