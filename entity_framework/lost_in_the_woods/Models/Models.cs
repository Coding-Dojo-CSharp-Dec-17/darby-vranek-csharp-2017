using System.ComponentModel.DataAnnotations;
namespace lost_in_the_woods.Models
{
	public abstract class BaseEntity {}

	public class Trail : BaseEntity
	{
		[Key]
		public long Id { get; set; }
		
		[Required]
		[MinLength(2)]
		public string Name { get; set; }
		
		[Required]
		[MinLength(10)]
		public string Description { get; set; }
		
		[Required]
		public float Length { get; set; }
		
		[Required]
		public int Elevation { get; set; }
		
		[Required]
		[Range(-90, 90)]
		public float Latitude { get; set; }
		
		[Required]
		[Range(-180, 180)]
		public float Longitude { get; set; }
	}
}