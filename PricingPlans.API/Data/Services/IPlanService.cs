using PricingPlans.API.DTOs;
using PricingPlans.API.model;

namespace PricingPlans.API.Data.Services
{
    public interface IPlanService
    {
        Task<IEnumerable<PlanDto>> GetPlans();
        Task<PlanDto> GetPlanById(int id);
        Task<PlanDto> CreateUpdatePlan(PlanDto planDto);
        Task<bool> DeletePlan(int id);
    }
}
