using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Deloitte Email ID is required")]
        [EmailAddress]
        public string Emailid { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        [Phone]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Address Line 1 is required")]
        public string line1 { get; set; }
        [Required(ErrorMessage = "Address Line 2 is required")]
        public string line2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string state { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        public string Pincode { get; set; }
    }
}
