using API.Contracts;
using API.DTOs.Companies;
using API.DTOs.Vendors;
using API.Models;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VendorController : ControllerBase
{

    private readonly IVendorRepository _vendorRepository;

    public VendorController(IVendorRepository vendorRepository)
    {
        _vendorRepository = vendorRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _vendorRepository.GetAll();

        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        var data = result.Select(x => (VendorDto)x);

        return Ok(new ResponseOKHandler<IEnumerable<VendorDto>>(data));
    }

    [HttpPut("UpdateStatus")]
    public IActionResult UpdateStatus(UpdateVendorStatusDto statusVendorDto)
    {
        try
        {
            _vendorRepository.UpdateVendorStatus(statusVendorDto);

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

    [HttpPost]
    public IActionResult Create(CreateVendorDto vendorDto)
    {
        try
        {
            var result = _vendorRepository.Create(vendorDto);

            return Ok(new ResponseOKHandler<VendorDto>((VendorDto)result));
        }
        catch (ExceptionHandler ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed to create data",
                Error = ex.Message
            });
        }
    }

    [HttpPut]
    public IActionResult Update(VendorDto vendorDto)
    {
        try
        {
            var entity = _vendorRepository.GetByGuid(vendorDto.Guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            Vendor toUpdate = vendorDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            _vendorRepository.Update(toUpdate);

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