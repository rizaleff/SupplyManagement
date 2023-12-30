using API.Contracts;
using API.DTOs.VendorOffers;
using API.Models;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VendorOfferController : ControllerBase
{
    private readonly IVendorOfferRepository _vendorOfferRepository;

    public VendorOfferController(IVendorOfferRepository vendorOfferRepository)
    {
        _vendorOfferRepository = vendorOfferRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _vendorOfferRepository.GetAll();

        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        var data = result.Select(x => (VendorOfferDto)x);

        return Ok(new ResponseOKHandler<IEnumerable<VendorOfferDto>>(data));
    }


    [HttpPost]
    public IActionResult Create(CreateVendorOfferDto vendorOfferDto)
    {
        try
        {
            var result = _vendorOfferRepository.Create(vendorOfferDto);

            return Ok(new ResponseOKHandler<VendorOfferDto>((VendorOfferDto)result));
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
    public IActionResult Update(VendorOfferDto vendorOfferDto)
    {
        try
        {
            var entity = _vendorOfferRepository.GetByGuid(vendorOfferDto.Guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            VendorOffer toUpdate = vendorOfferDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            _vendorOfferRepository.Update(toUpdate);

            return Ok(new ResponseOKHandler<string>("Data Updated"));
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


    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        try
        {
            var entity = _vendorOfferRepository.GetByGuid(guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            _vendorOfferRepository.Delete(entity);

            return Ok(new ResponseOKHandler<string>("Data Deleted"));
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
}