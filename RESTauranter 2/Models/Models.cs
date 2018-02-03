using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
	public abstract class BaseEntity {}

	public class Review : BaseEntity
	{
		[Key]
		public int id { get; set; }

		[Required]
		[MaxLength(30)]
		public string reviewer { get; set; }

		[Required]
		[MaxLength(30)]
		public string restaurant { get; set; }

		[Required]
		public string review { get; set; }

		[Required]
		public DateTime visit_date { get; set; }

		[Required]
		public int stars { get; set; }

		public DateTime created_at { get; set; }
	}
}