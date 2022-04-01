using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class ImageRepository
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Photos_Path { get; set; } //Photo file location in location ~\BookListRazor\BookListRazor\Photos\

        [Required]
        public string Alternate_Text { get; set; } // Alternate to image, show this text

        public string Comments { get; set; }
    }
}
