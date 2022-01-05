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
    public class CommentMusicManager
    {
        public int ID { get; set; }

        public string UserName { get; set; }
        public string Singers { get; set; }
        public string MusicName { get; set; }

        public int AccountID { get; set; }

        public int MusicID { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}