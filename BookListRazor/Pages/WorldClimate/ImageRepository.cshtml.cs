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
    public class ImageRepositoryModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ImageRepositoryModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ImageRepository> imageRepositories { get; set; }

        public async Task OnGet()
        {
            imageRepositories = await _db.ImageRepository.ToListAsync();
        }

        //public async Task<IActionResult> OnPostDelete(int id)
        //{
        //    var book = await _db.Book.FindAsync(id);
        //    if(book == null)
        //    {
        //        return NotFound();
        //    }
        //     _db.Book.Remove(book);
        //     await _db.SaveChangesAsync();
        //    return RedirectToPage("Index");
        //}
    }
}