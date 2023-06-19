using HospitalApp.Models.Entities;
using HospitalApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers;

[ApiController]
[Route("[controller]")]
public class NsiController : ControllerBase
{
    private readonly INsiService _nsiService;

    public NsiController(INsiService nsiService)
    {
        _nsiService = nsiService;
    }

    [HttpGet]
    [Route("/cabinets")]
    public ActionResult<List<Cabinet>> Cabinets()
    {
        var cabinets = _nsiService.GetCabinets();
        return Ok(cabinets);
    }

    [HttpGet]
    [Route("/districts")]
    public ActionResult<List<District>> Districts()
    {
        var districts = _nsiService.GetDistricts();
        return Ok(districts);
    }

    [HttpGet]
    [Route("/specializations")]
    public ActionResult<List<Specialization>> Specializations()
    {
        var specializations = _nsiService.GetSpecializations();
        return Ok(specializations);
    }
}
