using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lost_in_the_woods.Models;

namespace lost_in_the_woods.Controllers
{
    public class TrailController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult Trail(int id)
        {
            ViewBag.TrailId = id;
            return View();
        }

        [HttpGet]
        [Route("NewTrail")]
        public IActionResult NewTrail()
        {
            return View();
        }

        [HttpPost]
        [Route("AddTrail")]
        public IActionResult AddTrail(Trail trail)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View("NewTrail");
        }
    }
}
