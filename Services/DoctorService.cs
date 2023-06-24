using AutoMapper;
using HospitalApp.Models;
using HospitalApp.Models.Api.EditModels;
using HospitalApp.Models.Api.ListViewModels;
using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Api.ViewModels;
using HospitalApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalAppContext _context;
        private readonly IListEntityService<Doctor> _listEntityService;
        private readonly IMapper _mapper;

        public DoctorService(
            HospitalAppContext context,
            IListEntityService<Doctor> listEntityService,
            IMapper mapper)
        {
            _context = context;
            _listEntityService = listEntityService;
            _mapper = mapper;
        }

        public int Create(DoctorEditModel model)
        {
            var doctor = _mapper.Map<Doctor>(model);
            _context.Add(doctor);
            return _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }

        public ListViewModel<DoctorViewModel, DoctorFilter> Get(ListOptions<DoctorFilter> options)
        {
            var ids = _listEntityService.GetIds(_context.Doctors.AsNoTracking(), options.Filter, options.Order, options.Page);

            var doctors = _context.Doctors
                .Where(d => ids.Contains(d.Id))
                .Include(d => d.Cabinet)
                .Include(d => d.Specialization)
                .Include(d => d.District)
                .AsNoTracking()
                .ToList();

            var model = new ListViewModel<DoctorViewModel, DoctorFilter>
            {
                List = _mapper.Map<List<DoctorViewModel>>(doctors),
                Options = options
            };

            return model;
        }

        public DoctorEditModel Get(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            return _mapper.Map<DoctorEditModel>(doctor);
        }

        public void Update(DoctorEditModel model)
        {
            throw new NotImplementedException();
        }
    }
}
