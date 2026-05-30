using Cw8.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Cw8.DTOs;

namespace Cw8.Controllers;


[ApiController]
[Route("api/")]
public class HospitalController : ControllerBase
{
    private readonly IHospitalService service;
    public HospitalController(IHospitalService service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("patients")]
    public IActionResult GetPatients([FromQuery] string? search)
    {
        var list = service.GetPatients(search);
        if (list == null) return StatusCode(500);
        if (list.Count == 0) return NotFound();
        
        return Ok(list);
    }

    [HttpPost]
    [Route("patients/{id}/bedassignments")]
    public IActionResult AssignBed([FromRoute] string id, [FromBody] AssignBedDTO assignBedDto)
    {
        bool success = service.AssignBed(id, assignBedDto);
        if(!success) return NotFound("No available bed for the given criteria");
        return Ok("Assigned Bed successfully");
    }



}