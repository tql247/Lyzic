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
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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

        // Thêm bình luận
        public string InsertComment(int idMusic, string content)
        {
            // Lấy thông tin user từ bình luận
            var userID = 6;
            var JWToken = HttpContext.Session.GetString("JWToken");
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                try
                {
                    userID = Int32.Parse(identity.FindFirst("AccountID").Value);
                }
                catch (System.Exception)
                {

                }
            }

            object[] searchChar = {
                userID,
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