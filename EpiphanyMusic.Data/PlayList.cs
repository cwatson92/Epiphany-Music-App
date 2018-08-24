using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Data
{
    public class PlayList
    {
        [Key]
        public int PlayListId { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Song { get; set; }

        [Required]
        public string Genre { get; set; }

        public string Youtube { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

