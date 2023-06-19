using AutoMapper;
using HospitalApp.Models.Dto;
using HospitalApp.Models.Entities;

namespace HospitalApp.Infrastructure
{
    public class HospitalAppMappingProfile: Profile
    {
        public HospitalAppMappingProfile()
        {
            CreateMap<Cabinet, CabinetDto>().ReverseMap();
        }
    }
}
