
namespace PricingPlans.API.model
{
    public class feature
    {
        public int Id { get; set; }
        public string featuresName { get; set; }
        public virtual ICollection<plansFeatures> plansFeatures { get; set; }
    }
}
