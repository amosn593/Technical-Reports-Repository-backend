

using DOMAIN.Models;

namespace DOMAIN.IRepository
{
    public interface IReportRepo : IGenericRepo<Report>
    {
        Task<IEnumerable<Report>> FindByString(string searchstring);
    }
}

