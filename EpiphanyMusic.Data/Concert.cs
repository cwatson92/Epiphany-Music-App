using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Data
{
    public class Concert
    {
        [Key]
        public int ConcertId { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
