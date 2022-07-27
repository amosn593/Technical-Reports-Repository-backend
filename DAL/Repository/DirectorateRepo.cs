

using DAL.Data;
using DOMAIN.IRepository;
using DOMAIN.Models;

namespace DAL.Repository
{
    public class DirectorateRepo : GenericRepo<Directorate>, IDirectorateRepo
    {
        public DirectorateRepo(PoultryDbContext context) : base(context)
        {

        }
    }
}
