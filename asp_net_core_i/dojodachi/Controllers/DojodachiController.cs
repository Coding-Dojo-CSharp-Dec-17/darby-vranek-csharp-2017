using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

namespace dojodachi.Controllers
{
	public class DojodachiController : Controller
	{
		Random random = new Random();

		[HttpGet]
		[Route("")]
		public IActionResult Index(string message="")
		{
			if (!HttpContext.Session.Keys.Contains("dojodachi"))
			{
				HttpContext.Session.SetObjectAsJson("dojodachi", new { happiness = 20, fullness = 20, energy = 50, meals = 3 });
			}
			Dictionary<string, int> dojodachi = HttpContext.Session.GetObjectFromJson<Dictionary<string, int>>("dojodachi");
			if (dojodachi["happiness"] <= 0 || dojodachi["fullness"] <= 0 || dojodachi["energy"] <= 0)
			{
				message = "Your Dojodachi has passed away...\n:(\nTry again?";
			}
			else if (dojodachi["energy"] >= 100 && dojodachi["fullness"] >= 100 && dojodachi["happiness"] >= 100)
			{
				message = "Congratulations! You Won!\nTry again?";
			}
			ViewBag.Dojodachi = dojodachi;
			ViewBag.Message = message;
			return View();
		}

		[HttpGet]
		[Route("reset")]
		public IActionResult Reset()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Route("feed")]
		public IActionResult Feed()
		{
			string message = "";
			Dictionary<string, int> dojodachi = HttpContext.Session.GetObjectFromJson<Dictionary<string, int>>("dojodachi");
			if (dojodachi["meals"] <= 0)
			{
				message = "You do not have enough food to feed your Dojodachi.";
			}
			else if (random.Next(0, 4) == 0)
			{
				dojodachi["meals"]--;
				message = "Your Dojodachi didn't like its food.\nMeals -1";
			}
			else if (dojodachi["happiness"] <= 0 || dojodachi["fullness"] <= 0 || dojodachi["energy"] <= 0)
			{
				message = "Your Dojodachi has passed away...\n:(\nTry again?";
			}
			else
			{
				int fullness = random.Next(5, 11);
				dojodachi["meals"]--;
				dojodachi["fullness"] += fullness;
				message = $"You fed your Dojodachi!\nMeals -1, Fullness +{fullness}";
			}
			if (dojodachi["energy"] >= 100 && dojodachi["fullness"] >= 100 && dojodachi["happiness"] >= 100)
			{
				message = "Congratulations! You Won!\nTry again?";
			}
			HttpContext.Session.SetObjectAsJson("dojodachi", dojodachi);
			return new JsonResult(new { dojodachi = dojodachi, message = message});
		}

		[HttpGet]
		[Route("play")]
		public IActionResult Play()
		{
			string message = "";
			Dictionary <string, int> dojodachi = HttpContext.Session.GetObjectFromJson<Dictionary<string, int>>("dojodachi");
			dojodachi["energy"] -= 5;
			if (random.Next(0, 4) == 0)
			{
				message = "Your Dojodachi didn't want to play.\nEnergy -5";
			}
			else
			{
				int happiness = random.Next(5, 11);
				dojodachi["happiness"] += happiness;
				message = $"You played with your Dojodachi!\nHappiness +{happiness}, Energy -5";
			}
			if (dojodachi["happiness"] <= 0 || dojodachi["fullness"] <= 0 || dojodachi["energy"] <= 0)
			{
				message = "Your Dojodachi has passed away...\n:(\nTry again?";
			}
			else if (dojodachi["energy"] >= 100 && dojodachi["fullness"] >= 100 && dojodachi["happiness"] >= 100)
			{
				message = "Congratulations! You Won!\nTry again?";
			}
			HttpContext.Session.SetObjectAsJson("dojodachi", dojodachi);
			return new JsonResult(new { dojodachi = dojodachi, message = message});
		}

		[HttpGet]
		[Route("work")]
		public IActionResult Work()
		{
			Dictionary<string, int> dojodachi = HttpContext.Session.GetObjectFromJson<Dictionary<string, int>>("dojodachi");
			dojodachi["energy"] -= 5;
			string message = "";
			if (dojodachi["happiness"] <= 0 || dojodachi["fullness"] <= 0 || dojodachi["energy"] <= 0)
			{
				message = "Your Dojodachi has passed away...\n:(\nTry again?";
			}
			else
			{
				int meals = random.Next(1, 4);
				dojodachi["meals"] += meals;
				message = $"You worked.\nMeals +{ meals }, Energy -5";
			}
			HttpContext.Session.SetObjectAsJson("dojodachi", dojodachi);
			return new JsonResult(new { dojodachi = dojodachi, message = message});
		}

		[HttpGet]
		[Route("sleep")]
		public IActionResult Sleep()
		{
			Dictionary<string, int> dojodachi = HttpContext.Session.GetObjectFromJson<Dictionary<string, int>>("dojodachi");
			dojodachi["energy"] += 15;
			dojodachi["fullness"] -= 5;
			dojodachi["happiness"] -= 5;
			string message = "Your Dojodachi slept.\nEnergy +15, Fullness -5, Happiness -5";
			if (dojodachi["happiness"] <= 0 || dojodachi["fullness"] <= 0 || dojodachi["energy"] <= 0)
			{
				message = "Your Dojodachi has passed away...\n:(\nTry again?";
			}
			else if (dojodachi["energy"] >= 100 && dojodachi["fullness"] >= 100 && dojodachi["happiness"] >= 100)
			{
				message = "Congratulations! You Won!\nTry again?";
			}
			HttpContext.Session.SetObjectAsJson("dojodachi", dojodachi);
			return new JsonResult(new { dojodachi = dojodachi, message = message});
		}
	}
}