using Lyzic.Models;
using Lyzic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lyzic.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    public class TokenController : Controller
    {
        public IConfiguration _configuration;

        public TokenController(IConfiguration config)
        {
            _configuration = config;

        }


        [HttpPost]
        public IActionResult Login(Account account)
        {
            AccountManager dbAccount = AccountManagerRes.CheckAccount(account.UserName, account.PassWord);
            string role = "";
            if (dbAccount != null)
            {
                Console.WriteLine("dbAccount.RoleName");
                Console.WriteLine(dbAccount.RoleName);
                role = dbAccount.RoleName;
            }

            if (account.RoleName != "admin")
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("RoleName", role),
                    new Claim("AccountID", dbAccount.ID.ToString()),
                    new Claim("UserName", dbAccount.UserName),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                    expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);


                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                // Session["loggedUserId"] = account.ID.ToString();

                HttpContext.Session.SetString("JWToken", tokenString);

                return Redirect("/");
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

    }


}

