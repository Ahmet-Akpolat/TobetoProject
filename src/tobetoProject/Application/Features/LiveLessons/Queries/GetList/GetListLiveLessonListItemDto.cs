using Core.Application.Dtos;

namespace Application.Features.LiveLessons.Queries.GetList;

public class GetListLiveLessonListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public string? RecordVideo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}