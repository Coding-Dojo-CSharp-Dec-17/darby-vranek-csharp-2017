using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Restauranter.Models;
using System.Linq;

namespace Restauranter.Controllers
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

        [HttpPost("Submit")]
        public IActionResult SubmitReview(ReviewViewModel reviewModel)
        {
            Console.WriteLine($"\n\nreviewer: {reviewModel.reviewer}\nrestaurant: {reviewModel.restaurant}\reviewModel: {reviewModel.review}\nvisit_date: {reviewModel.visit_date}\nstars: {reviewModel.stars}\n\n");
            if (ModelState.IsValid)
            {
                Review review = new Review
                {
                    reviewer = reviewModel.reviewer,
                    restaurant = reviewModel.restaurant,
                    review = reviewModel.review,
                    stars = reviewModel.stars,
                    visit_date = reviewModel.visit_date
                };
                _context.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            var errorList = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
            foreach(KeyValuePair<string, string[]> error in errorList)
            {
                foreach(string err in error.Value)
                {
                    Console.WriteLine(err);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
            ViewBag.Reviews = _context.reviews.ToList();
            return View();
        }
    }
}