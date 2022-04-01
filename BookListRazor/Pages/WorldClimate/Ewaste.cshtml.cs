using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookListRazor.Pages
{
    public class EwasteModel : PageModel
    {
        private readonly ILogger<EwasteModel> _logger;

        public EwasteModel(ILogger<EwasteModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
