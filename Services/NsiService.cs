using AutoMapper;
using HospitalApp.Models;
using HospitalApp.Models.Api.ViewModels;
using Microsoft.EntityFrameworkCore;
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

        public List<CabinetViewModel> GetCabinets()
        {
            if (!_cache.TryGetValue("Cabinets", out List<CabinetViewModel> cabinets))
            {
                cabinets = _mapper.Map<List<CabinetViewModel>>(_context.Cabinets.AsNoTracking().ToList());
                _cache.Set("Cabinets", cabinets);
            }
            return cabinets;
        }

        public List<DistrictViewModel> GetDistricts()
        {
            if (!_cache.TryGetValue("Districts", out List<DistrictViewModel> districts))
            {
                districts = _mapper.Map<List<DistrictViewModel>>(_context.Districts.AsNoTracking().ToList());
                _cache.Set("Districts", districts);
            }
            return districts;
        }

        public List<SpecializationViewModel> GetSpecializations()
        {
            if (!_cache.TryGetValue("Specializations", out List<SpecializationViewModel> specializations))
            {
                specializations = _mapper.Map<List<SpecializationViewModel>>(_context.Specializations.AsNoTracking().ToList());
                _cache.Set("Specializations", specializations);
            }
            return specializations;
        }
    }
}
