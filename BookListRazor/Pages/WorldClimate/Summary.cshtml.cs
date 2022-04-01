using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class SummaryModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public SummaryModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Person> Persons { get; set; }

        public IEnumerable<SelectEwaste> SelectEwastes { get; set; }

        public async Task OnGet()
        {
            Persons = await _db.Person.ToListAsync();

            SelectEwastes = await _db.SelectEwaste.ToListAsync();
        }


        public async Task<IActionResult> OnPostDelete(int id)
        {
            var person = await _db.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _db.Person.Remove(person);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
