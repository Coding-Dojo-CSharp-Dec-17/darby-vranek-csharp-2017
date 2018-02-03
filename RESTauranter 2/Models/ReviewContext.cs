using Microsoft.EntityFrameworkCore;
using System;

 
namespace RESTauranter.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options) { }

		public DbSet<Review> reviews { get; set; }
    }
}