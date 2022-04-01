using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class TravelCategory
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //public double Co2Footprint { get; set; } //decimal value of calculated footprint saves here

        //[Required]
        //public string Categories { get; set; } // Values allowed : F/T. T for food, T for travel

        //public string CategoryId { get; set; }
        //public string SubCategoryId { get; set; }
        //public string ThirdCategoryId { get; set; }
        //public string CategoryId { get; set; }

    }
}
