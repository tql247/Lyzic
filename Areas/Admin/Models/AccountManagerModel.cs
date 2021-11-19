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
    public class AccountManager
    {
        public int ID {get; set; }

        [Required]
        public string FullName {get; set; }
    
        public string UserName {get; set; }

        public string PassWord {get; set; }

        public string RoleName {get; set; }

        public DateTime CreatedDate {get; set; }
    }
}