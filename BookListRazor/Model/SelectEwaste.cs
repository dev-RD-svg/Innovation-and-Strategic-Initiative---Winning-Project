using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    //public class SelectEwaste
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    [Required]
    //    public int UserId { get; set; }
    //    public int productId { get; set; }
    //    public int Quantity { get; set; }

    //}
    public class SelectEwaste
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public double Co2Footprint { get; set; }
        public string Quantity { get; set; }
    }

}

