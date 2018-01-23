using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lost_in_the_woods.Models;
using lost_in_the_woods.Factory;

namespace lost_in_the_woods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
        private readonly string googleKey = "AIzaSyCVEK86EdwxjtQQj7BdCD-jwc3ElD_EHMM";
        public TrailController()
        {
            trailFactory = new TrailFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.SelectAll();
            return View();
        }

        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult Trail(int id)
        {
            Trail trail = trailFactory.FindById(id);
            ViewBag.Trail = trail;
            ViewBag.Src = $"https://www.google.com/maps/embed/v1/search?key={googleKey}&q=({trail.Latitude},do{trail.Longitude})";
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
                trailFactory.Add(trail);
                return RedirectToAction("Index");
            }
            return View("NewTrail");
        }
    }
}
