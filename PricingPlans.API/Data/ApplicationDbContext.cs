using Microsoft.EntityFrameworkCore;
using PricingPlans.API.model;

namespace PricingPlans.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<plan> plans { get; set; }
        public DbSet<feature> features { get; set; }
        public DbSet<plansFeatures> plansFeatures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<plansFeatures>().HasKey(am => new
            {
                am.featureId,
                am.PlanId
            });

            modelBuilder.Entity<plansFeatures>().HasOne(m => m.Plan).WithMany(am => am.plansFeatures).
                HasForeignKey(m => m.PlanId);
            modelBuilder.Entity<plansFeatures>().HasOne(a => a.feature).WithMany(am => am.plansFeatures).
                HasForeignKey(a => a.featureId);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<feature>().HasData(new feature
            {
                Id = 1,
                featuresName = "Unlimited members"

            });
            modelBuilder.Entity<feature>().HasData(new feature
            {
                Id = 2,
                featuresName = "Unlimited feedback"

            }); modelBuilder.Entity<feature>().HasData(new feature
            {
                Id = 3,
                featuresName = "Weekly team Feedback Friday"

            }); modelBuilder.Entity<feature>().HasData(new feature
            {
                Id = 4,
                featuresName = "Custom Kudos +9 illustration"

            });


            modelBuilder.Entity<plan>().HasData(new plan
            {
                Id = 1,
                Name = "Basic",
                PriceMonth= 7,
                PriceYear=96,
                Descraption= "Lorem ipsum dolor sit amet consectetur adipiscing elit interdum ullamcorper sed pharetra sene."

            });

            modelBuilder.Entity<plan>().HasData(new plan
            {
                Id = 2,
                Name = "Advanced",
                PriceMonth = 7,
                PriceYear = 96,
                Descraption = "Lorem ipsum dolor sit amet consectetur adipiscing elit interdum ullamcorper sed pharetra sene."

            });

            modelBuilder.Entity<plan>().HasData(new plan
            {
                Id = 3,
                Name = "Pro",
                PriceMonth = 7,
                PriceYear = 96,
                Descraption = "Lorem ipsum dolor sit amet consectetur adipiscing elit \r\ninterdum ullamcorper sed pharetra sene."

            });

            modelBuilder.Entity<plansFeatures>().HasData(new plansFeatures
            {
                featureId = 1,
                PlanId = 1,
            });

            modelBuilder.Entity<plansFeatures>().HasData(new plansFeatures
            {
                featureId = 2,
                PlanId = 1,
            });

            modelBuilder.Entity<plansFeatures>().HasData(new plansFeatures
            {
                featureId = 3,
                PlanId = 1,
            });

            modelBuilder.Entity<plansFeatures>().HasData(new plansFeatures
            {
                featureId = 4,
                PlanId = 1,
            });


            modelBuilder.Entity<plansFeatures>().HasData(new plansFeatures
            {
                featureId = 1,
                PlanId = 2,
            });

            modelBuilder.Entity<plansFeatures>().HasData(new plansFeatures
            {
                featureId = 2,
                PlanId = 2,
            });

            modelBuilder.Entity<plansFeatures>().HasData(new plansFeatures
            {
                featureId = 3,
                PlanId = 2,
            });
        }
    }
}
