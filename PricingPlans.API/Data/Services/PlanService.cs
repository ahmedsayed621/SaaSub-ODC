using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PricingPlans.API.DTOs;
using PricingPlans.API.model;
using System;

namespace PricingPlans.API.Data.Services
{
    public class PlanService : IPlanService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public PlanService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PlanDto> CreateUpdatePlan(PlanDto planDto)
        {
            plan pln = _mapper.Map<plan>(planDto);
            if (pln.Id > 0)
            {
                _context.Update(pln);
            }
            else
            {
                _context.Add(pln);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<plan, PlanDto>(pln);
        }

        public async Task<bool> DeletePlan(int id)
        {
            try
            {
                plan pln = await _context.plans.FirstOrDefaultAsync(x => x.Id == id);
                if (pln == null)
                {
                    return false;
                }

                _context.plans.Remove(pln);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<PlanDto> GetPlanById(int id)
        {
            plan pln = await _context.plans.Include(x=>x.plansFeatures).ThenInclude(x=>x.feature).Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<PlanDto>(pln);
        }

        public async Task<IEnumerable<PlanDto>> GetPlans()
        {
            List<plan> planList = await _context.plans.ToListAsync();
            return _mapper.Map<List<PlanDto>>(planList);
        }
    }
}
