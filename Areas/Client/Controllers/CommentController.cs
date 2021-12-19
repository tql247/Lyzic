using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Repositories;
using Lyzic.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Dynamic;
using CAIT.SQLHelper;
using Lyzic.Const;
using System.Data;

namespace Lyzic.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly IWebHostEnvironment _environment;
        public CommentController(ILogger<CommentController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _environment = env;
        }


        public string InsertComment(int idMusic, string content)
        {
            object[] searchChar = { 
                // Edit account id (4)
                4,
                idMusic,
                content
            };

            var msg = "fail";

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Comment_Insert ", searchChar);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                msg = "success";

            return msg;
        }
    }
}