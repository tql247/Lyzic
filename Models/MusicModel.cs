using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lyzic.Models
{
    public class MusicModel
    {
        [Key]
        [Required]
        public int ID {get; set; }

        public string Name {get; set; }

        public string Author {get; set; }

        public string Singers {get; set; }

        public string Lyric {get; set; }

        public string MediaContentURI {get; set; }

        public DateTime CreatedDate {get; set; }
    }
}