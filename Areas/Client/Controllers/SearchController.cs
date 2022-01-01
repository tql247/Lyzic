using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lyzic.Repositories;
using Lyzic.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using CAIT.SQLHelper;
using System.Data;
using Lyzic.Const;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lyzic.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IWebHostEnvironment _environment;
        public SearchController(ILogger<SearchController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _environment = env;
        }

        // Tìm kiếm nghệ sĩ
        public string SearchArtist(string term)
        {
            object[] searchChar = { term };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Singer_Find", searchChar);
            DataColumn dc = new DataColumn("Link", typeof(String));
            result.Columns.Add(dc);
            result.Columns.Remove("Biography");
            result.Columns.Remove("AvatarImageURI");
            result.Columns.Remove("CreatedDate");

            string JSONString = string.Empty;
            // List<string> lstResult = new List<Artist>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    row["Link"] = "/Artist/Details/" + row["ID"];
                }
                JSONString = JsonConvert.SerializeObject(result);
            }

            // return JSONString;

            return JSONString;
        }

        // Tìm kiếm ca nhạc
        public string SearchMusic(string term)
        {
            object[] searchChar = { term };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Music_Find", searchChar);
            DataColumn dc = new DataColumn("Link", typeof(String));
            result.Columns.Add(dc);
            // result.Columns.Remove("Biography");
            // result.Columns.Remove("AvatarImageURI");
            // result.Columns.Remove("CreatedDate");

            string JSONString = string.Empty;
            // List<string> lstResult = new List<Artist>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    row["Link"] = "/Music/Details/" + row["ID"];
                }
                JSONString = JsonConvert.SerializeObject(result);
            }

            return JSONString;
        }
    }
}