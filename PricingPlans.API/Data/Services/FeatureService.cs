using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PricingPlans.API.DTOs;
using PricingPlans.API.model;

namespace PricingPlans.API.Data.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public FeatureService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FeatureDto> CreateUpdateProduct(FeatureDto featureDto)
        {
            feature feat = _mapper.Map<feature>(featureDto);
            if (feat.Id > 0)
            {
                _context.Update(feat);
            }
            else
            {
                _context.Add(feat);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<feature, FeatureDto>(feat);
        }

        public async Task<bool> DeleteFeature(int id)
        {
            try
            {
                feature feat = await _context.features.FirstOrDefaultAsync(x => x.Id == id);
                if (feat == null)
                {
                    return false;
                }

                _context.features.Remove(feat);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<FeatureDto> GetFeatureById(int id)
        {
            feature feat = await _context.features.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<FeatureDto>(feat);
        }

        public async Task<IEnumerable<FeatureDto>> GetFeatures()
        {
            List<feature> featuresList = await _context.features.ToListAsync();
            return _mapper.Map<List<FeatureDto>>(featuresList);
        }
    }
}
