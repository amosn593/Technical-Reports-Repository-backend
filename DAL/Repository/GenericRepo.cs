

using DAL.Data;
using DOMAIN.IRepository;
using DOMAIN.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public abstract class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private protected PoultryDbContext _context;

        public GenericRepo(PoultryDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> FindAll()
        {
           
            try
            {
              var reports =  await _context.Set<T>().ToListAsync();

                
                return reports;

            }
            catch(Exception)
            {
                throw;
            }
        }

        public virtual async Task<T> FindById(int id)
        {
            
            try
            {
                var report = await _context.Set<T>().FindAsync(id);

                

                
                return report;

            }
            catch (Exception)
            {
                throw;

            }
        }
        public void Create(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);

            }
            catch (Exception)
            {
                throw;

            }
        }            
        public void Update(T entity)
        {
            try
            {
                //_context.Set<T>().Update(entity);
                _context.Entry(entity).State = EntityState.Modified;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);

            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}
