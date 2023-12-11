using FluentValidation;

namespace Application.Features.LiveLessons.Commands.Delete;

public class DeleteLiveLessonCommandValidator : AbstractValidator<DeleteLiveLessonCommand>
{
    public DeleteLiveLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}