using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class DonateEwasteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DonateEwasteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Person person { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Person.AddAsync(person);
                await _db.SaveChangesAsync();
                return RedirectToPage("SurveyEwaste");
            }
            else
            {
                return Page();
            }
        }
            
    }
}
