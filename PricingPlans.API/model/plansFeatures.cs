namespace PricingPlans.API.model
{
    public class plansFeatures
    {
        
        public int PlanId { get; set; }
        public plan Plan { get; set; }
        public int featureId { get; set; }
        public feature feature { get; set; }

    }
}
