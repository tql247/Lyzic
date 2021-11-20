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
    public class NotificationManager
    {
        public int ID {get; set; }

        [Required]
        public string Title {get; set; }
    
        [Required]
        public string Content {get; set; }

        public string CreatedBy {get; set; }
        
        public string NotificationImage {get; set; }
        
        public IFormFile MediaImageCover {get; set; }   

        public DateTime CreatedDate {get; set; }
    }
}