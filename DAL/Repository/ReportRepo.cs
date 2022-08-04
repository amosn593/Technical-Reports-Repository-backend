

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
        public override async Task<IEnumerable<Report>> FindAll()
        {
            
            try
            {
                var reports = await _context.Reports
                    .Include(d => d.Directorate)
                    .ToListAsync();
               
                
                return reports;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<Report> FindById(int id)
        {
           
            try
            {
                var report = await _context.Reports
                    .Include(d => d.Directorate)
                    .FirstOrDefaultAsync(i => i.ReportId == id);
               
                return report;

            }
            catch (Exception)
            {
                throw;

            }
        }

        public async Task<IEnumerable<Report>> FindByString(string searchstring)
        {
            
            try
            {
                var reports = await _context.Reports
                    .Where(c => c.Citation.Contains(searchstring))
                    .Include(d => d.Directorate)
                    .ToListAsync();
                

                return reports;

            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}
