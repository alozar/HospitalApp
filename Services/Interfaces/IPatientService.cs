using HospitalApp.Models.Api.EditModels;
using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Api.ViewModels;

namespace HospitalApp.Services.Interfaces
{
    public interface IPatientService : ICRUDService<PatientEditModel>, IListViewModelService<PatientViewModel, PatientFilter>
    {
    }
}
