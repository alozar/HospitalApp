using AutoMapper;
using HospitalApp.Models;
using HospitalApp.Models.Api.EditModels;
using HospitalApp.Models.Api.ViewModels;
using HospitalApp.Models.Entities;

namespace HospitalApp.Infrastructure
{
    public class HospitalAppMappingProfile: Profile
    {
        public HospitalAppMappingProfile()
        {
            CreateMap<Cabinet, CabinetViewModel>().ReverseMap();
            CreateMap<District, DistrictViewModel>().ReverseMap();
            CreateMap<Specialization, SpecializationViewModel>().ReverseMap();

            CreateMap<Doctor, DoctorEditModel>().ReverseMap();
            CreateMap<Doctor, DoctorViewModel>()
                .ForMember(dest => dest.Cabinet, opt => opt.MapFrom(src => src.Cabinet.Num))
                .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization.Name))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District.Num));

            CreateMap<Patient, PatientEditModel>().ReverseMap();
            CreateMap<Patient, PatientViewModel>()
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District.Num));
        }
    }
}
