using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
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
        [Route("Ninjas/{id}")]
                public IActionResult Ninja(int id)
        {
            ViewBag.Ninja = ninjaFactory.FindById(id);
            return View();
        }

		[HttpGet]
		[Route("Ninjas")]
		public IActionResult Ninjas()
		{
            ViewBag.Ninjas = ninjaFactory.SelectAll();
            ViewBag.Dojos = ninjaFactory.SelectAllDojos();
			return View();
		}


        [HttpPost]
        [Route("Ninjas/Add")]
        public IActionResult AddNinja(Ninja ninja, int Dojo_Id)
        {
            if (ModelState.IsValid)
            {
                ninja.Dojo = ninjaFactory.FindDojoById(Dojo_Id);
                ninjaFactory.Add(ninja);
                return RedirectToAction("Ninjas");
            }
            return View("Ninjas");
        }

        [HttpGet]
		[Route("Dojos/{dojoId}/Recruit/{ninjaId}")]
		public IActionResult Recruit(int dojoId, int ninjaId)
		{
            ninjaFactory.UpdateDojoId(dojoId, ninjaId);
			return RedirectToAction("Dojo", new { id = dojoId });
		}

        [HttpGet]
        [Route("Dojos/{dojoId}/Banish/{ninjaId}")]
        public IActionResult Banish(int dojoId, int ninjaId)
        {
            ninjaFactory.UpdateDojoId(0, ninjaId);
            return RedirectToAction("Dojo", new { id = dojoId });
        }
    }
}
