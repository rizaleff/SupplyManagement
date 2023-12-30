using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.ProjectTenders;
public class ProjectTenderDto
{
    public Guid Guid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ProjectStatusLevel ProjectStatus { get; set; }

    public static implicit operator ProjectTender(ProjectTenderDto projectTenderDto)
    {
        return new ProjectTender
        {
            Guid = projectTenderDto.Guid,
            title = projectTenderDto.Title,
            description = projectTenderDto.Description,
            ProjectStatus = projectTenderDto.ProjectStatus,
            ModifiedDate = DateTime.Now
            


        };
    }

    public static explicit operator ProjectTenderDto(ProjectTender projectTender)
    {
        return new ProjectTenderDto
        {
            Guid = projectTender.Guid,
            Title = projectTender.title,
            Description = projectTender.description,
            ProjectStatus = projectTender.ProjectStatus,
        };
    }
}