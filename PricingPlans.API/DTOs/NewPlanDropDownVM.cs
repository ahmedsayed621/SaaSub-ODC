using PricingPlans.API.model;

namespace PricingPlans.API.DTOs
{
    public class NewPlanDropDownVM
    {
        public NewPlanDropDownVM()
        {
            features = new List<feature>();
        }

        public List<feature> features { get;set; }
    }
}
