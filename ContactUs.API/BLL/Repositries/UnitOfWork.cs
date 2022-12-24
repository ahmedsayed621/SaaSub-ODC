
using ContactUs.API.BLL.InterFaces;
using ContactUs.API.BLL.Repositries;
using ContactUs.API.data;
using ContactUs.API.Model;
using System.Collections;

namespace BLL.Repositries
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext _context;
        private Hashtable _repositries;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Complet()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();


        public IGenercRepositry<T> Repositry<T>() where T :class
        {

            if (_repositries == null) _repositries = new Hashtable();
            var type = typeof(T);
            if (!_repositries.ContainsKey(type))
            {
                var repositry = new GenericRepositry<T>(_context);
                _repositries.Add(type, repositry);
            }
            return (IGenercRepositry<T>)_repositries[type];
        }

    }
}
