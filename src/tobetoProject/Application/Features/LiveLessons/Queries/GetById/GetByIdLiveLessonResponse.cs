using Core.Application.Responses;

namespace Application.Features.LiveLessons.Queries.GetById;

public class GetByIdLiveLessonResponse : IResponse
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