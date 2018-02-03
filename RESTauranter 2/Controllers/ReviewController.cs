using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RESTauranter.Models;
using System.Linq;

namespace RESTauranter.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewContext _context;

        public ReviewController(ReviewContext context)
        {
            _context = context;
        }


        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
            ViewBag.Reviews = _context.reviews.ToList();
            return View();
        }

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit(Review review)
        {
            if (ModelState.IsValid)
            {
                // add record to database
                return RedirectToAction("Reviews");
            }
            return View("Index");
        }
    }
}
