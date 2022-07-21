using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Model;
namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        //by using binding we connect between the server controllers and property we havwe set (person property)--> actually initalizinf object person
        [BindProperty]
        public Person Person { get; set; }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {

                Object[] a = { Person.FName, Person.ID, Person.Phone };

                //return the details and show them on screen
                this.Response.WriteAsync("<p>Thank you for register!</p>");
                this.Response.WriteAsync(string.Join("<br>", a));
            }
        }
    }
}
