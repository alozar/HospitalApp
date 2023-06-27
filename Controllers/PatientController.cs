using HospitalApp.Models.Api.EditModels;
using HospitalApp.Models.Api.ListViewModels;
using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Api.ViewModels;
using HospitalApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{id}")]
    public ActionResult<PatientEditModel> Get(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var patient = _patientService.Get(id.Value);
        return Ok(patient);
    }

    [HttpGet]
    public ActionResult<ListViewModel<PatientViewModel, PatientFilter>> GetAll([FromQuery] ListOptions<PatientFilter> options)
    {
        var patient = _patientService.Get(options);
        return Ok(patient);
    }

    [HttpPost]
    public ActionResult<int> Post([FromBody] PatientEditModel model)
    {
        var id = _patientService.Create(model);
        return Ok(id);
    }

    [HttpPut]
    public ActionResult Put([FromBody] PatientEditModel model)
    {
        _patientService.Update(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        _patientService.Delete(id.Value);
        return Ok();
    }
}
