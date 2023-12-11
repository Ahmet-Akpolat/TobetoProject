using Core.Application.Responses;

namespace Application.Features.LiveLessons.Commands.Delete;

public class DeletedLiveLessonResponse : IResponse
{
    public Guid Id { get; set; }
}