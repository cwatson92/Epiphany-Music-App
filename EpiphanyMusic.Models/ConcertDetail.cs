using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Models
{
    public class ConcertDetail
    {
        public int ConcertId { get; set; }
        public string Artist { get; set; }
        public string TourName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString() => $"[{ConcertId}] {Artist}";
    }
}