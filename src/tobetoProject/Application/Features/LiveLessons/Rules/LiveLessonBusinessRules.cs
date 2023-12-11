using Application.Features.LiveLessons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LiveLessons.Rules;

public class LiveLessonBusinessRules : BaseBusinessRules
{
    private readonly ILiveLessonRepository _liveLessonRepository;

    public LiveLessonBusinessRules(ILiveLessonRepository liveLessonRepository)
    {
        _liveLessonRepository = liveLessonRepository;
    }

    public Task LiveLessonShouldExistWhenSelected(LiveLesson? liveLesson)
    {
        if (liveLesson == null)
            throw new BusinessException(LiveLessonsBusinessMessages.LiveLessonNotExists);
        return Task.CompletedTask;
    }

    public async Task LiveLessonIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        LiveLesson? liveLesson = await _liveLessonRepository.GetAsync(
            predicate: ll => ll.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LiveLessonShouldExistWhenSelected(liveLesson);
    }
}