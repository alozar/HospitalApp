using AutoMapper;
using HospitalApp.Models.Api.EditModels;
using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Api.ListViewModels;
using HospitalApp.Models.Api.ViewModels;
using HospitalApp.Models;
using HospitalApp.Models.Entities;
using HospitalApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalAppContext _context;
        private readonly IListEntityService<Patient> _listPatientService;
        private readonly IMapper _mapper;

        public PatientService(
            HospitalAppContext context,
            IListEntityService<Patient> listPatientService,
            IMapper mapper)
        {
            _context = context;
            _listPatientService = listPatientService;
            _mapper = mapper;
        }

        public int Create(PatientEditModel model)
        {
            var patient = _mapper.Map<Patient>(model);
            _context.Patients.Add(patient);
            return _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var patient = _context.Patients.FirstOrDefault(d => d.Id == id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }

        public ListViewModel<PatientViewModel, PatientFilter> Get(ListOptions<PatientFilter> options)
        {
            var orderOptions = options.Order ?? new OrderOptions();
            var ids = _listPatientService.GetIds(
                _context.Patients.AsNoTracking(),
                options.Filter ?? new PatientFilter(),
                orderOptions,
                options.Page ?? new PageOptions());

            var patients = _context.Patients
                .Where(d => ids.Contains(d.Id))
                .Include(d => d.District)
                .AsNoTracking();

            var sortPatients = _listPatientService.QueryOrder(patients, orderOptions).ToList();

            var model = new ListViewModel<PatientViewModel, PatientFilter>
            {
                List = _mapper.Map<List<PatientViewModel>>(sortPatients),
                Options = options
            };

            return model;
        }

        public PatientEditModel Get(int id)
        {
            var patient = _context.Patients.FirstOrDefault(d => d.Id == id);
            return _mapper.Map<PatientEditModel>(patient);
        }

        public void Update(PatientEditModel model)
        {
            var patient = _mapper.Map<Patient>(model);
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }
    }
}
