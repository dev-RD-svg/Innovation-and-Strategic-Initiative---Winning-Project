using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace BookListRazor.Pages.BookList
{
    public class CascadingDropdownsModelModel : PageModel
    {
        #region private
        private readonly ApplicationDbContext _db;

        //private ICategoryService categoryService;

        private const double auto = 0.8347;
        private const double uberPremier = 1.5419;
        private const double uberGo = 1.1126;
        private const double bus = 0.1713;
        private const double train = 0.0214;

        #endregion

        public CascadingDropdownsModelModel(ApplicationDbContext db)
        {
            _db = db;
        }



        //[BindProperty]
        //public FoodTravelCalculatorCO FoodTravelCalculatorCO { get; set; }


        //[ActivatorUtilitiesConstructor]
        //public CascadingDropdownsModelModel(ICategoryService categoryService) => this.categoryService = categoryService;

        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public int ThirdCategoryId { get; set; }
        public SelectList Categories { get; set; }

        public SelectList Arrival { get; set; }

        public SelectList Departure { get; set; }

        public void OnGet()
        {
            List<Category> categories = new List<Category> 
            {
                new Category { CategoryId = 1, CategoryName="Auto" },
                new Category { CategoryId = 2, CategoryName="Uber Premium" },
                new Category { CategoryId = 3, CategoryName="Uber Go" },
                new Category { CategoryId = 4, CategoryName="Bus" },
                new Category { CategoryId = 5, CategoryName="Train" }
            };

            List<Arrival> arrivals = new List<Arrival>
            {
                new Arrival { CategoryId = 1, CategoryName="Hiranandani Fairmont (USI Mumbai office)" },
                new Arrival { CategoryId = 2, CategoryName="Kharghar, Navi mumbai (USI-Mumbai Home)" }
            };

            List<Departure> departures = new List<Departure>
            {
                new Departure { CategoryId = 1, CategoryName="Hiranandani Fairmont (USI Mumbai office)" },
                new Departure { CategoryId = 2, CategoryName="Kharghar, Navi mumbai (USI-Mumbai Home)" }
            };



            Categories = new SelectList(categories, nameof(Category.CategoryId), nameof(Category.CategoryName));
            Arrival = new SelectList(arrivals, nameof(Category.CategoryId), nameof(Category.CategoryName));
            Departure = new SelectList(departures, nameof(Category.CategoryId), nameof(Category.CategoryName));
            //Categories = new SelectList(categoryService.GetCategories(), nameof(Category.CategoryId), nameof(Category.CategoryName));
            //Arrival = new SelectList(categoryService.GetArrival(), nameof(Category.CategoryId), nameof(Category.CategoryName));
            //Departure = new SelectList(categoryService.GetDeparture(), nameof(Category.CategoryId), nameof(Category.CategoryName));
        }

        public IEnumerable<SubCategory> GetSubCategories(int categoryId)
        {
            var subCategories = new List<SubCategory> {
            new SubCategory { SubCategoryId = 1, CategoryId = 1, SubCategoryName="Hiranandani Fairmont (USI Mumbai office)" },
            new SubCategory { SubCategoryId = 2, CategoryId = 1, SubCategoryName="Kharghar, Navi mumbai (USI-Mumbai Home)" },
            new SubCategory { SubCategoryId = 1, CategoryId = 2, SubCategoryName="Hiranandani Fairmont (USI Mumbai office)" },
            new SubCategory { SubCategoryId = 2, CategoryId = 2, SubCategoryName="Kharghar, Navi mumbai (USI-Mumbai Home)" },
            new SubCategory { SubCategoryId = 1, CategoryId = 3, SubCategoryName="Hiranandani Fairmont (USI Mumbai office)" },
            new SubCategory { SubCategoryId = 2, CategoryId = 3, SubCategoryName="Kharghar, Navi mumbai (USI-Mumbai Home)" },
            new SubCategory { SubCategoryId = 1, CategoryId = 4, SubCategoryName="Hiranandani Fairmont (USI Mumbai office)" },
            new SubCategory { SubCategoryId = 2, CategoryId = 4, SubCategoryName="Kharghar, Navi mumbai (USI-Mumbai Home)" },
            new SubCategory { SubCategoryId = 1, CategoryId = 5, SubCategoryName="Hiranandani Fairmont (USI Mumbai office)" },
            new SubCategory { SubCategoryId = 2, CategoryId = 5, SubCategoryName="Hiranandani Fairmont (USI Mumbai office)" }

        };
            return subCategories.Where(s => s.CategoryId == categoryId);
        }

        public IEnumerable<ThirdCategory> GetThirdCategories(int subCategoryId)
        {
            var thirdCategories = new List<ThirdCategory> {
            new ThirdCategory { ThirdCategoryId = 2, SubCategoryId = 1, ThirdCategoryName="Kharghar, Navi mumbai (USI-Mumbai Home)" },
            new ThirdCategory { ThirdCategoryId = 1, SubCategoryId = 2, ThirdCategoryName="Hiranandani Fairmont (USI Mumbai office)" }
        };
            return thirdCategories.Where(s => s.SubCategoryId == subCategoryId);
        }


        public JsonResult OnGetSubCategories()
        {
            return new JsonResult(GetSubCategories(CategoryId));
        }

        public JsonResult OnGetThirdCategories()
        {
            return new JsonResult(GetThirdCategories(CategoryId));
        }

        //public IActionResult GetMessage()
        //{
        //    string message = "Welcome";
        //    return new ActionResult(message);// { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        public IActionResult OnPostSellProduct1()
        {
            if (ModelState.IsValid)
            {
                double sum = 0;
                List<double> sumTotal = new List<double>();

                //int?  min = int.Parse(Request.Form["Categories"]);
                int i = 0;
                int.TryParse(Convert.ToString(Request.Form["Categories"]), out i); // Convert textfield value
                int? travelId = (i > 0 ? (int?)i : null);

                switch (travelId)
                {
                    case 1:
                        sum = auto;
                        break;
                    case 2:
                        sum = uberPremier;
                        break;
                    case 3:
                        sum = uberGo;
                        break;
                    case 4:
                        sum = bus;
                        break;
                    case 5:
                        sum = train;
                        break;
                }

                sum = Math.Round(sum, 2);
                if (sum > 0)
                {
                    TempData["SumResult"] = sum.ToString();
                }


                FoodTravelCalculatorCO foodTravelCalculatorCO = new FoodTravelCalculatorCO();
                foodTravelCalculatorCO.Co2Footprint = sum;
                //foodTravelCalculatorCO.Co2Footprint = Convert.ToDecimal(sum);
                foodTravelCalculatorCO.FoodIndicator = "T";
                foodTravelCalculatorCO.ColumnFour = DateTime.Now.ToString();
                _db.FoodTravelCalculatorCO.Add(foodTravelCalculatorCO);
                _db.SaveChanges();

                //FoodTravelCalculatorCO foodTravelCalculatorCO = new FoodTravelCalculatorCO();
                ////foodTravelCalculatorCO.Id = _db.FoodTravelCalculatorCO.Max(x => x.Id) + 1;
                //foodTravelCalculatorCO.Co2Footprint = Convert.ToDecimal(sum);
                //foodTravelCalculatorCO.FoodIndicator = "T";
                //foodTravelCalculatorCO.ColumnFour = DateTime.Now.ToString();
                //_db.FoodTravelCalculatorCO.Add(foodTravelCalculatorCO);
                //_db.SaveChanges();
                OnGet();
            }
            return Page();

        }
    }
}
