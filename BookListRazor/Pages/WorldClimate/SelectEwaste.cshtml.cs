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
    public class SelectEwasteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SelectEwasteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        //[BindProperty]
        //public List<SelectEwaste> SelectEwaste { get; set; }
        public IEnumerable<Person> Persons { get; set; }

        #region Constant
        private const double Laptop = 69.0;
        private const double Mobile = 27.0;
        private const double xyz = 0.612;
        private const double abc = 0.8325;


        public async Task OnGet()
        {
            Persons = await _db.Person.ToListAsync();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var userid = await _db.Person.FindAsync(id);
            if (ModelState.IsValid)
            {
                double sum = 0;
                List<double> sumTotal = new List<double>();

                string item1 = Request.Form["Laptop"];
                if (!string.IsNullOrEmpty(item1))
                {
                    //sum = sum + (Convert.ToDouble(item1) * cheeseSandwich);
                    sumTotal.Add(Convert.ToDouble(item1) * Laptop);
                }

                string item2 = Request.Form["Mobile"];
                if (!string.IsNullOrEmpty(item2))
                {
                    sumTotal.Add(Convert.ToDouble(item2) * Mobile);
                }

                string item3 = Request.Form["xyz"];
                if (!string.IsNullOrEmpty(item3))
                {
                    sumTotal.Add(Convert.ToDouble(item3) * xyz);
                }

                string item4 = Request.Form["abc"];
                if (!string.IsNullOrEmpty(item4))
                {
                    sumTotal.Add(Convert.ToDouble(item4) * abc);
                }

                IEnumerable<double> returnCollection = sumTotal.Select(m => m);
                double bindTotal = Math.Round((returnCollection.Sum(m => Convert.ToDouble(m))), 4);
                if (bindTotal > 0)
                {
                    TempData["SumResult"] = bindTotal.ToString();
                }


                SelectEwaste SelectEwasteObj = new SelectEwaste();
                SelectEwasteObj.Co2Footprint = bindTotal;
                SelectEwasteObj.UserId = id;
                //foodTravelCalculatorCO.Co2Footprint = Convert.ToDecimal(bindTotal);
                //foodTravelCalculatorCO.FoodIndicator = "F";
                _db.SelectEwaste.Add(SelectEwasteObj);
                _db.SaveChanges();


                return RedirectToPage("Summary");
            }
            else
            {
                return Page();
            }
        }

    }
}
#endregion
