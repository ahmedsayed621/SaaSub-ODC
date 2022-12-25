using AutoMapper;
using ContactUs.API.DTO;
using ContactUs.API.Model;

namespace ProductService.API.MappingConfig
{
    public class MappingConfig 
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config=>
            {
                config.CreateMap<ContactInfo, ContactDTO>();
                config.CreateMap<ContactDTO, ContactInfo>();

          

            });

            return mappingConfig;
        }
    }
}
