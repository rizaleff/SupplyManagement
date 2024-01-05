using API.Contracts;
using API.DTOs.Employees;
using API.DTOs.VendorOffers;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _employeeRepository.GetAll();

        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        var data = result.Select(x => (EmployeeDto)x);

        return Ok(new ResponseOKHandler<IEnumerable<EmployeeDto>>(data));
    }


}
