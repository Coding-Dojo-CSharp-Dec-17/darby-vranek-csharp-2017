using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojo_survey.Controllers
{
	public class SurveyController : Controller
	{
		[HttpGet]
		[Route("")]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[Route("result")]
		public IActionResult Result(string name, string location, string favoriteLanguage, string comment)
		{
			ViewBag.Name = name;
			ViewBag.Location = location;
			ViewBag.Favoritelanguage = favoriteLanguage;
			ViewBag.Comment = comment;
			return View();
		}
	}
}