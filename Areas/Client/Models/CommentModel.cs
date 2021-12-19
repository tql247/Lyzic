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
    public class Comment
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public int AccountID { get; set; }

        public int MusicID { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}