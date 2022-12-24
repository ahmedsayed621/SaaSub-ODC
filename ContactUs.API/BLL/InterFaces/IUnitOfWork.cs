using BLL.Repositries;
using ContactUs.API.Model;

namespace ContactUs.API.BLL.InterFaces
{
    public interface IUnitOfWork : IDisposable 
    {
        IGenercRepositry<T> Repositry<T>() where T :class ;
        Task<int> Complet();


    }
}
