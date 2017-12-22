using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace random_password_generator.Controllers
{
	public class RandomController : Controller
	{
		string randomChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		Random random = new Random();

		[HttpGet]
		[Route("")]
		public IActionResult Index()
		{
			if (!HttpContext.Session.Keys.Contains("Count"))
			{
				HttpContext.Session.SetInt32("Count", 1);
			}
			else
			{
				HttpContext.Session.SetInt32("Count", (int)HttpContext.Session.GetInt32("Count") + 1);
			}
			ViewBag.RandomString = GetRandomString();
			ViewBag.Count = HttpContext.Session.GetInt32("Count");
			return View();
		}

		string GetRandomString()
		{
			string output = "";
			for (int i = 0; i < 14; i++)
			{
				output += randomChars[random.Next(0, randomChars.Length)];
			}
			return output;
		}
	}
}