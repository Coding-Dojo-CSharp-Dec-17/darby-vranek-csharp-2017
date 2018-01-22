using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class SubmissionController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit(string firstName, string lastName, int age, string email, string password)
        {
            Submission submission = new Submission
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Email = email,
                Password = password
            };
            if (TryValidateModel(submission))
            {
                return View("Success");
            }
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }
    }
}
