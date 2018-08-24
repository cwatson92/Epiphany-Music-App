using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Models
{
   public class PlayListDetail
    {
        public int PlayListId { get; set; }
        public string Artist { get; set; }
        public string Song { get; set; }
        public string Genre { get; set; }
        public string Youtube { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{PlayListId}] {Artist}";
    }
}
