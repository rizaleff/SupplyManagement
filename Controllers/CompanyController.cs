using API.Contracts;
using API.DTOs.Companies;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{

    private readonly ICompanyRepository _companyRepository;

    public CompanyController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _companyRepository.GetAll();

        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        var data = result.Select(x => (CompanyDto)x);

        return Ok(new ResponseOKHandler<IEnumerable<CompanyDto>>(data));
    }

    [HttpPut("UpdateStatus")]
    public IActionResult UpdateStatus(UpdateCompanyStatusDto statusCompanyDto)
    {
        try
        {
            _companyRepository.UpdateCompanyStatus(statusCompanyDto);

            return Ok(new ResponseOKHandler<string>("Data Updated"));
        }
        catch (ExceptionHandler ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed to update data",
                Error = ex.Message
            });
        }
    }




}