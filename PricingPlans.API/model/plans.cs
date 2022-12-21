using PricingPlans.API.Data.Base;

namespace PricingPlans.API.model
{
    public class plan:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceMonth { get; set; }
        public decimal PriceYear { get; set; }
        public string Descraption { get; set; }
        public List<plansFeatures> plansFeatures { get; set; }

    }
}
