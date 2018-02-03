using Microsoft.EntityFrameworkCore;
namespace Restauranter.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions options) : base(options) {}
		
		public DbSet<Review> reviews { get; set; }
    }
}