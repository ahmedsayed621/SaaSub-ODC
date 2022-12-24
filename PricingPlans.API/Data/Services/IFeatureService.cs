using PricingPlans.API.DTOs;
using PricingPlans.API.model;

namespace PricingPlans.API.Data.Services
{
    public interface IFeatureService
    {
        Task<IEnumerable<FeatureDto>> GetFeatures();
        Task<FeatureDto> GetFeatureById(int id);
        Task<FeatureDto> CreateUpdateProduct(FeatureDto featureDto);
        Task<bool> DeleteFeature(int id);
    }
}
