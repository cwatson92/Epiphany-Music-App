using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Models
{
    public class PlayListItem
    {

        public int PlayListId { get; set; }
        public string Artist { get; set; }
        public string Song  { get; set; }
        public string Genre { get; set; }

        [Display(Name = "Playlist")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => Artist;
    }
}
