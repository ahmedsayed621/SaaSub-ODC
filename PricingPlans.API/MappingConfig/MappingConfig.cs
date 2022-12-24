using AutoMapper;
using PricingPlans.API.DTOs;
using PricingPlans.API.model;



namespace ProductService.API.MappingConfig
{
    public class MappingConfig 
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config=>
            { config.CreateMap<feature, FeatureDto>();
                config.CreateMap<FeatureDto, feature>();
                config.CreateMap<PlanDto, plan>();
                config.CreateMap<plan, PlanDto>();

            });

            return mappingConfig;
        }
    }
}
