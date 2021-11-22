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
    public class Artist
    {
        public int ID {get; set; }

        [Required]
        public string Name {get; set; }
    
        public string Biography {get; set; }
        public string AvatarImageURI {get; set; }

        public IFormFile MediaImageCover {get; set; }

        public DateTime CreatedDate {get; set; }
    }
}