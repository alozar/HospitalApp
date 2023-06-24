using HospitalApp.Models.Api.EditModels;
using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Api.ViewModels;

namespace HospitalApp.Services.Interfaces;

public interface IDoctorService : ICRUDService<DoctorEditModel>, IListViewModelService<DoctorViewModel, DoctorFilter>
{
}
