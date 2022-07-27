

using DOMAIN.Models;

namespace DOMAIN.IRepository
{
    public interface IGenericRepo<T>
    {
        Task<Response<IEnumerable<T>>> FindAll();
        Task<Response<T?>> FindById(int id);
       
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
