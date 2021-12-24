using Evaluasi.Models;
using Microsoft.EntityFrameworkCore;

namespace Evaluasi.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}