
using ContactUs.API.BLL.InterFaces;
using ContactUs.API.BLL.Spcefication;
using ContactUs.API.data;
using ContactUs.API.Data;
using ContactUs.API.Model;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.API.BLL.Repositries
{
    public class GenericRepositry<TEntity> : IGenercRepositry<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepositry(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(TEntity entity)
        => await _context.Set<TEntity>().AddAsync(entity);

        public TEntity Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity).Entity;



        public TEntity Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity).Entity;
        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
            => await _context.Set<TEntity>().ToListAsync();


        public async Task<TEntity> GetDataByIdAsync(int id)
            => await _context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> GetDataByNameAsync(string Name)
           => await _context.Set<TEntity>().FindAsync(Name);

        public async Task<IReadOnlyList<TEntity>> GetAllDataWithSpecificatonAsync(ISpecification<TEntity> spec)
                => await ApplySpecification(spec).ToListAsync();

        public async Task<TEntity> GetDataByIdWithSpecificatonAsync(ISpecification<TEntity> spec)
            => await ApplySpecification(spec).FirstOrDefaultAsync();

        public async Task<int> Count(ISpecification<TEntity> spec)
            => await ApplySpecification(spec).CountAsync();
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpcificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), spec);
        }

    }
}
