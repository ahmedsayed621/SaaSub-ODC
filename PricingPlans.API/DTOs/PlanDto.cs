using PricingPlans.API.model;

namespace PricingPlans.API.DTOs
{
    public class PlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descraption { get; set; }
        public decimal PriceMonth { get; set; }
        public decimal PriceYear { get; set; }
        public IList<FeatureDto> featureDtos { get; set; }

    }
}
