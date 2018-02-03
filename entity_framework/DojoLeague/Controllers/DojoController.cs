using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using DojoLeague.Factories;

namespace DojoLeague.Controllers
{
    public class DojoController : Controller
    {
		private readonly DojoFactory dojoFactory;

		public DojoController()
		{
			dojoFactory = new DojoFactory();
		}


        [HttpGet]
        [Route("Dojos/{id}")]
        public IActionResult Dojo(int id)
        {
			ViewBag.Dojo = dojoFactory.FindById(id);
			ViewBag.DojoNinjas = dojoFactory.SelectNinjasByDojo(id);
			ViewBag.RogueNinjas = dojoFactory.SelectNinjasByDojo(0);
            return View();
        }

		[HttpGet]
		[Route("Dojos")]
		public IActionResult Dojos()
		{
			ViewBag.Dojos = dojoFactory.SelectAll();
			return View();
		}

		[HttpPost]
		[Route("Dojos/Add")]
		public IActionResult AddDojo(Dojo dojo)
		{
			if (ModelState.IsValid)
			{
				dojoFactory.Add(dojo);
				return RedirectToAction("Dojos");
			}
			return View("Dojos");
		}
    }
}
