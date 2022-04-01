using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class ThirdCategory
    {
        public int ThirdCategoryId { get; set; }

        public string ThirdCategoryName { get; set; }

        public int SubCategoryId { get; set; }

    }
}
