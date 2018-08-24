using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Models
{
    public class PlayListEdit
    {
        public int PlayListId { get; set; }
        public string Artist { get; set; }
        public string Song { get; set; }
        public string Genre { get; set; }
        public string Youtube { get; set; }
    }   
}
