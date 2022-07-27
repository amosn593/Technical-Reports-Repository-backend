

using DOMAIN.IRepository;

namespace DOMAIN.IConfiguration
{
    public interface IUnitOfWork : IDisposable
    {
     

        IReportRepo Report { get; }

        IDirectorateRepo Directorate { get; }

        IDepartmentRepo Department { get; }

        Task Save();
    } 
}
