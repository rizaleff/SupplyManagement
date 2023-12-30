using API.Contracts;
using API.DTOs.ProjectTenders;
using API.Models;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectTenderController : ControllerBase
{
    private readonly IProjectTenderRepository _projectTenderRepository;

    public ProjectTenderController(IProjectTenderRepository projectTenderRepository)
    {
        _projectTenderRepository = projectTenderRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _projectTenderRepository.GetAll();

        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        var data = result.Select(x => (ProjectTenderDto)x);

        return Ok(new ResponseOKHandler<IEnumerable<ProjectTenderDto>>(data));
    }


    [HttpPost]
    public IActionResult Create(CreateProjectTenderDto projectTenderDto)
    {
        try
        {
            var result = _projectTenderRepository.Create(projectTenderDto);

            return Ok(new ResponseOKHandler<ProjectTenderDto>((ProjectTenderDto)result));
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
    public IActionResult Update(ProjectTenderDto projectTenderDto)
    {
        try
        {
            var entity = _projectTenderRepository.GetByGuid(projectTenderDto.Guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            ProjectTender toUpdate = projectTenderDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            _projectTenderRepository.Update(toUpdate);

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
            var entity = _projectTenderRepository.GetByGuid(guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            _projectTenderRepository.Delete(entity);

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