using System.ComponentModel.DataAnnotations;
using System;

namespace Restauranter.Models
{
	public class PastDate : ValidationAttribute
	{
		public override bool IsValid(object date) 
		{
			DateTime dateTime = (DateTime)date;
			return dateTime < DateTime.Now;
		}
	}
}