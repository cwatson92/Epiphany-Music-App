using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Models
{
    public class ConcertCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Artist { get; set; }

        [MaxLength(8000)]
        public string TourName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public override string ToString() => Artist;
        
    }
}