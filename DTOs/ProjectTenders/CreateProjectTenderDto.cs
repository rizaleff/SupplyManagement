using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.ProjectTenders;

public class CreateProjectTenderDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    
    public static implicit operator ProjectTender(CreateProjectTenderDto dto)
    {
        return new ProjectTender
        {
            Guid = Guid.NewGuid(),
            title = dto.Title,
            description = dto.Description,
            ProjectStatus = 0,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
        };
    }
}
