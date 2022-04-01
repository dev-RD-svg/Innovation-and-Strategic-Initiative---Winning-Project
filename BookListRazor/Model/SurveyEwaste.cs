using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    

    public class SurveyEwaste
    {
        [Key]
        public int Id { get; set; }
        // public int UserId { get; set; }
        public int question { get; set; }
        public String option { get; set; }
        public int UserId { get; set; }

    }

}
