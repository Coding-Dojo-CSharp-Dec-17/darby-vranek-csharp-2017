using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoLeague.Models
{
	public abstract class BaseEntity {}

	public class Ninja : BaseEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Range(1, 10)]
		public int Level { get; set; }


		public string Description { get; set; }


		public Dojo Dojo { get; set; }

	}

	public class Dojo : BaseEntity
	{
		public ICollection<Ninja> Ninjas{ get; set; }

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }


		[Required]
		[MaxLength(255)]
		public string Location { get; set; }


		public string AdditionalInfo { get; set; }
	}
}