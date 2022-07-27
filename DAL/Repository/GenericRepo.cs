

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

        public virtual async Task<Response<IEnumerable<T>>> FindAll()
        {
            var response = new Response<IEnumerable<T>>();
            try
            {
              var items =  await _context.Set<T>().ToListAsync();

                if (items.Count < 1)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "UnSuccessful, no records found";
                    return response;
                }

                response.Data = items;
                response.Message = "Successful";
                return response;

            }
            catch(Exception)
            {
                throw;
            }
        }

        public virtual async Task<Response<T?>> FindById(int id)
        {
            var response = new Response<T>();
            try
            {
                var item = await _context.Set<T>().FindAsync(id);

                if (item == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "UnSuccessful, no records found";
                    return response;
                }

                response.Data = item;
                response.Message = "Successful";

                return response;

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
