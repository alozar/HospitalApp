using HospitalApp.Models.Api.EditModels;
using HospitalApp.Models.Api.ListViewModels;
using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Api.ViewModels;
using HospitalApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("{id}")]
    public ActionResult<DoctorEditModel> Get(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var doctor = _doctorService.Get(id.Value);
        return Ok(doctor);
    }

    [HttpGet]
    public ActionResult<ListViewModel<DoctorViewModel, DoctorFilter>> GetAll([FromQuery] ListOptions<DoctorFilter> options)
    {
        var doctors = _doctorService.Get(options);
        return Ok(doctors);
    }

    [HttpPost]
    public ActionResult<int> Post([FromBody] DoctorEditModel model)
    {
        var id = _doctorService.Create(model);
        return Ok(id);
    }

    [HttpPut]
    public ActionResult Put([FromBody] DoctorEditModel model)
    {
        _doctorService.Update(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        _doctorService.Delete(id.Value);
        return Ok();
    }
}
