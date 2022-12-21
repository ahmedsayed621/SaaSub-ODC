using PricingPlans.API.Data.Base;
using PricingPlans.API.model;
using System;

namespace PricingPlans.API.Data.Services
{
    public class PlanService:EntityBaseRepo<plan>,IEntityBaseRepo<plan>
    {
        public PlanService(ApplicationDbContext context) : base(context) { }
    }
}
