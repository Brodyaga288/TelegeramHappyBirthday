using Microsoft.EntityFrameworkCore;
using TelegeramHappyBirthday.Models;

namespace TelegeramHappyBirthday
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5433;database=User;username=postgres;password=11111");
        }
    }
}
