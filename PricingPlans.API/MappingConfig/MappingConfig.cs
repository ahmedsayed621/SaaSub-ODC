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
            {
                config.CreateMap<feature, FeatureDto>();
                config.CreateMap<FeatureDto, feature>();

                config.CreateMap<PlanDto, plan>();

                config.CreateMap<plan, PlanDto>().
                ForMember(dto => dto.featureDtos, opt => opt.MapFrom(x => x.plansFeatures.Select(y => y.feature).ToList()));
                config.CreateMap<plansFeatures, PlanDto>();

            });

            return mappingConfig;
        }
    }
}
