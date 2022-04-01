using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Controllers
{
    public class FoodCalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult FoodCalculator()
        {
            return View();
        }
    }
}
