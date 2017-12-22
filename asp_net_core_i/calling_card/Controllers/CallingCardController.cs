using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace calling_card.Controllers
{
	public class CallingCardController : Controller
	{
		[HttpGetAttribute]
		[Route("{firstName}/{lastName}/{age}/{favColor}")]
		public JsonResult CallingCard(string firstName, string lastName, string age, string favColor)
		{
			var callingCard = new {
				FirstName = firstName,
				LastName = lastName,
				Age = age,
				FaveColor = favColor
			};
			return Json(callingCard);
		}
	}
}