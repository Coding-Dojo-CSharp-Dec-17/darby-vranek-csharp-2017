using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
	public class Submission
	{
		[Display(Name = "First Name")]
		[Required(ErrorMessage="First name is required.")]
		[MinLength(2, ErrorMessage="First Name must be at least 2 letters long.")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[Required(ErrorMessage="Last name is required.")]
		[MinLength(2, ErrorMessage="Last Name must be at least 2 letters long")]
		public string LastName { get; set; }

		[Required(ErrorMessage="Age is required.")]
		[Range(0, 150, ErrorMessage="Age must be a positive number.")]
		public int Age { get; set; }

		[Required(ErrorMessage="Email is required.")]
		[EmailAddress(ErrorMessage="Email must be a valid address.")]
		public string Email { get; set; }

		[Required(ErrorMessage="Password is required.")]
		[MinLength(8, ErrorMessage="Password must be at least 8 characters long.")]
		public string Password { get; set; }
	}
}