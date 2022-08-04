namespace DOMAIN.IRepository
{
    public interface IGenericRepo<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(int id);
       
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
