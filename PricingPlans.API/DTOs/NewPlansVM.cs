namespace PricingPlans.API.DTOs
{
    public class NewPlanVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceMonth { get; set; }
        public decimal PriceYear { get; set; }
    }
}
