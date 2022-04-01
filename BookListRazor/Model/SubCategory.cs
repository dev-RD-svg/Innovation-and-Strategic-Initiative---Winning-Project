using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }

    }
}
