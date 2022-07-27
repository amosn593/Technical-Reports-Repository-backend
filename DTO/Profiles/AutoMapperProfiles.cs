

using AutoMapper;
using DOMAIN.Models;
using DTO.Models;

namespace DTO.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Report, ReportDTO>().ReverseMap();
        }
    }
}
