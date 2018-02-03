using System.ComponentModel.DataAnnotations;
using System;

namespace Restauranter.Models
{
	public class ReviewViewModel : BaseEntity
	{
		[Required(ErrorMessage="Reviewer Name is required")]
		[Display(Name="Reviewer Name")]
		[MaxLength(30, ErrorMessage="Reviewer Name must be 30 characters or less")]
		[DataType(DataType.Text)]
		public string reviewer { get; set; }

		[Required(ErrorMessage="Restaurant Name is required")]
		[Display(Name="Restaurant Name")]
		[MaxLength(30, ErrorMessage="Restaurant Name must be 30 characters or less")]
		[DataType(DataType.Text)]
		public string restaurant { get; set; }

		[Required(ErrorMessage="Review cannot be left blank")]
		[Display(Name="Review")]
		[DataType(DataType.MultilineText)]
		public string review { get; set; }

		[Display(Name="Stars")]
		public string stars { get; set; }

		[Required(ErrorMessage="Date of Visit is required")]
		[Display(Name="Date of Visit")]
		[PastDate(ErrorMessage="Date cannot be in the future")]
		[DataType(DataType.Date)]
		public DateTime visit_date { get; set; }


	}
}