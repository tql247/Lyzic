using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Repositories;
using Lyzic.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using CAIT.SQLHelper;
using System.Data;
using Lyzic.Const;

namespace Lyzic.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IWebHostEnvironment _environment;
        public AccountController(ILogger<AccountController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _environment = env;
        }

        public string Index()
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData
            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            _logger.LogInformation("Index Action");


            return "I'm there";
        }

        // GET: AccountController/Details
        public ActionResult Profile(int id)
        {

            var JWToken = HttpContext.Session.GetString("JWToken");
            // Console.WriteLine(JWToken);

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (identity != null)
                {
                    Console.WriteLine("AccountID");
                    Console.WriteLine(identity.FindFirst("UserName").Value);
                    Console.WriteLine(identity.FindFirst("AccountID").Value);
                }
                var account = AccountRes.Profile(Int32.Parse(identity.FindFirst("AccountID").Value));
                return View(account);
            }
            catch (System.Exception)
            {
                return Redirect("/Account/SignIn");
            }
        }

        class JsonData
        {
            public string icon { get; set; }
            public string title { get; set; }
        }

        public JsonResult UpdateNameUser(int userID, string name)
        {
            object[] searchChar = {
                userID,
                name
            };

            var icon = "error";
            var title = "Thất bại, vui lòng thử lại!";

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Update_Name ", searchChar);
            if (connection.errorCode == 0 && connection.errorMessage == "")
            {
                icon = "success";
                title = "Đã thay đổi tên thành công!";
            }

            var jsonData = new JsonData()
            {
                icon = icon,
                title = title
            };

            return Json(jsonData);
        }

        public JsonResult UpdatePasswordUser(int userID, string newpass, string confirmpass, string oldpass)
        {
            object[] searchChar = {
                userID
            };

            var icon = "error";
            var title = "Đã có lỗi xảy ra, vui lòng thử lại!";

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_CheckPassword", searchChar);
            AccountManager AccountManager = new AccountManager();

            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                var dr = result.Rows[0];
                AccountManager.PassWord = dr["PassWord"].ToString();

                // If old password equal current password user
                if (AccountManager.PassWord == oldpass)
                {
                    if (newpass == confirmpass)
                    {
                        object[] value = {
                            userID,
                            newpass
                        };

                        connection = new SQLCommand(ConstValue.ConnectionString);
                        result = connection.Select("Account_Update_Password ", value);
                        if (connection.errorCode == 0 && connection.errorMessage == "")
                        {
                            icon = "success";
                            title = "Đã thay đổi mật khẩu thành công!";
                        }
                    }
                    else
                    {
                        icon = "error";
                        title = "Mật khẩu không trùng khớp, vui lòng thử lại!";
                    }
                }
                else
                {
                    icon = "error";
                    title = "Mật khẩu không đúng, vui lòng thử lại!";
                }
            }

            var jsonData = new JsonData()
            {
                icon = icon,
                title = title
            };

            return Json(jsonData);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

    }
}