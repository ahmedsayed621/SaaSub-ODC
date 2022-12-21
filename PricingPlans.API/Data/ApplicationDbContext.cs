using Microsoft.EntityFrameworkCore;
using PricingPlans.API.model;

namespace PricingPlans.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<plan> plans { get; set; }
        public DbSet<feature> features { get; set; }
        public DbSet<plansFeatures> plansFeatures { get; set; }


    }
}
