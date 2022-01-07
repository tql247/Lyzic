using System;
using System.Collections.Generic; 
using System.ComponentModel;  
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Lyzic.Models
{
    public class Music
    {
        [Key]
        [Required]
        public int ID {get; set; }

        [Required]
        public string Name {get; set; }
    
        public string Author {get; set; }

        public string Singers {get; set; }
        public int SingersID {get; set; }

        public string Lyric {get; set; }

        public string MediaImageCoverURI {get; set; }

        public IFormFile MediaImageCover {get; set; }

        public string MediaContentURI {get; set; }
        
        public IFormFile MediaContent {get; set; }

        public DateTime CreatedDate {get; set; }
    }
}