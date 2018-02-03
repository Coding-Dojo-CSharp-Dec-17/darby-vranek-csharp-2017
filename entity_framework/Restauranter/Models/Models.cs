using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Restauranter.Models
{
	public abstract class BaseEntity {}

	public class Review : BaseEntity
	{
		[Key]
		public int id { get; set; }

		public string reviewer { get; set; }
		public string restaurant { get; set; }
		public string review { get; set; }
		public string stars { get; set; }
		public DateTime visit_date { get; set; }

		[Timestamp]
		public DateTime created_at { get; set; }
	}
}