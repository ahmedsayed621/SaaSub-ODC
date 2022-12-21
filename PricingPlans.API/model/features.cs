namespace PricingPlans.API.model
{
    public class feature
    {
        public int Id { get; set; }
        public string featuresName { get; set; }
        public List<plansFeatures> plansFeatures { get; set; }
    }
}
