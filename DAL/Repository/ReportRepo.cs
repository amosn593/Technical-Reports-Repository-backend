

using DAL.Data;
using DOMAIN.IRepository;
using DOMAIN.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ReportRepo : GenericRepo<Report>, IReportRepo
    {
        public ReportRepo(PoultryDbContext context) : base(context)
        {

        }
        public override async Task<Response<IEnumerable<Report>>> FindAll()
        {
            var response = new Response<IEnumerable<Report>>();
            try
            {
                var items = await _context.Reports
                    .Include(d => d.Directorate)
                    .ToListAsync();

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
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<Response<Report?>> FindById(int id)
        {
            var response = new Response<Report>();
            try
            {
                var items = await _context.Reports
                    .Include(d => d.Directorate)
                    .FirstOrDefaultAsync(i => i.ReportId == id);
                if(items == null)
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
            catch (Exception)
            {
                throw;

            }
        }
    }
}
