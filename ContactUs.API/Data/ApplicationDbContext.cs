using ContactUs.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactUs.API.data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ContactInfo> ContactUs { get; set; }
    }
}
