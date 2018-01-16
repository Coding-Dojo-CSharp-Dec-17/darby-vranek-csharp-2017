using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace quoting_dojo.Controllers
{
    public class QuotesController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            ViewBag.Quotes = DbConnector.Query("SELECT * FROM `quotes` ORDER BY created_at DESC");
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult Submit(string name, string quote)
        {
            if (name == null || quote == null)
            {
                ViewBag.Messages = new List<string>();
                if (name == null)
                {
                    ViewBag.Messages.Add("Name cannot be left blank!");
                }
                if (quote == null)
                {
                    ViewBag.Messages.Add("Quote cannot be left blank!");
                }
                return View("index");
            }
            DbConnector.Execute($"INSERT INTO quotes (name, quote) VALUES ('{name}', '{quote}');");
            return RedirectToAction("Quotes");
        }
    }
}
