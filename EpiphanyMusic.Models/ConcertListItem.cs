using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Models
{
    public class ConcertListItem
    {
        

            public int ConcertId { get; set; }

            [Display(Name = "Artist")]
            public string Artist { get; set; }

            [Display(Name = "Tour Name")]
            public string TourName { get; set; }

            [Display(Name = "Concert Location")]
            public string City { get; set; }
            public string State { get; set; }

            [Display(Name = "Concert Price")]
            public decimal Price { get; set; }

            [Display(Name = "Concert Date & Time")]
            public DateTime Date { get; set; }

            
            public DateTimeOffset CreatedUtc { get; set; }

            public override string ToString() => Artist;
        }
    }
