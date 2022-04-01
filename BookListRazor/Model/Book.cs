using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required]
        public string Emailid { get; set; }

        //[MaxLength(10, ErrorMessage = "Contact number cannot be longer than 10 characters.")]
        public string ContactNo { get; set; }

        public string line1 { get; set; }

        public string line2 { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }

        
        //[MaxLength(6, ErrorMessage = "Pincode cannot be longer than 6 characters.")]
        public string Pincode { get; set; }
    }
}
