using cw10.DTOs;
using cw10.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionDto prescriptionDto)
    {
        PrescriptionDto result = await _dbService.AddPrescription(prescriptionDto);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPatientWithData(int id)
    {
        var res = await _dbService.GetPatientWithData(id);
        return Ok(res);
    }
}