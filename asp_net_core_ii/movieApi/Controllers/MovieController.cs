using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace movieApi.Controllers
{
    public class MovieController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Movies = DbConnector.Query("SELECT * FROM `movies` ORDER BY `created_at` DESC;");
            return View();
        }

        [HttpPost]
        [Route("Search")]
        public void Search(string title, string rating, string release_date)
        {
            string query = $"INSERT INTO movies (title, rating, release_date) VALUES ('{title}', '{rating}', '{release_date}');";
            DbConnector.Execute(query);
        }
    }
}
