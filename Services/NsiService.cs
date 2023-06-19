using AutoMapper;
using HospitalApp.Models;
using HospitalApp.Models.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace HospitalApp.Services
{
    public class NsiService : INsiService
    {
        private readonly HospitalAppContext _context;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public NsiService(
            HospitalAppContext context,
            IMemoryCache cache,
            IMapper mapper)
        {
            _context = context;
            _cache = cache;
            _mapper = mapper;
        }

        public List<CabinetDto> GetCabinets()
        {
            if (!_cache.TryGetValue("Cabinets", out List<CabinetDto> cabinets))
            {
                cabinets = _mapper.Map<List<CabinetDto>>(_context.Cabinets.ToList());
                _cache.Set("Cabinets", cabinets);
            }
            return cabinets;
        }

        public List<DistrictDto> GetDistricts()
        {
            if (!_cache.TryGetValue("Districts", out List<DistrictDto> districts))
            {
                districts = _mapper.Map<List<DistrictDto>>(_context.Districts.ToList());
                _cache.Set("Districts", districts);
            }
            return districts;
        }

        public List<SpecializationDto> GetSpecializations()
        {
            if (!_cache.TryGetValue("Specializations", out List<SpecializationDto> specializations))
            {
                specializations = _mapper.Map<List<SpecializationDto>>(_context.Specializations.ToList());
                _cache.Set("Specializations", specializations);
            }
            return specializations;
        }
    }
}
