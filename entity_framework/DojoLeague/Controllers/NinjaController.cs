using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Factories;

namespace DojoLeague.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaFactory ninjaFactory;

        public NinjaController()
        {
            ninjaFactory = new NinjaFactory();
        }

        [HttpGet]
        [Route("Ninja/{id}")]
                public IActionResult Ninja(int id)
        {
            return View();
        }

		[HttpGet]
		[Route("Ninjas")]
		public IActionResult Ninjas()
		{
            ViewBag.Ninjas = ninjaFactory.SelectAll();
			return View();
		}


        [HttpPost]
        [Route("AddNinja")]
        public IActionResult AddNinja(NinjaController ninja)
        {
            return RedirectToAction("Ninjas");
        }
    }
}
