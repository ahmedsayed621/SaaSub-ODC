namespace PricingPlans.API.model
{
    public class plansFeatures
    {
        
        public int PlanId { get; set; }
        public virtual plan Plan { get; set; }
        public int featureId { get; set; }
        public virtual feature feature { get; set; }

    }
}
