using Application.Features.LiveLessons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LiveLessons;

public class LiveLessonsManager : ILiveLessonsService
{
    private readonly ILiveLessonRepository _liveLessonRepository;
    private readonly LiveLessonBusinessRules _liveLessonBusinessRules;

    public LiveLessonsManager(ILiveLessonRepository liveLessonRepository, LiveLessonBusinessRules liveLessonBusinessRules)
    {
        _liveLessonRepository = liveLessonRepository;
        _liveLessonBusinessRules = liveLessonBusinessRules;
    }

    public async Task<LiveLesson?> GetAsync(
        Expression<Func<LiveLesson, bool>> predicate,
        Func<IQueryable<LiveLesson>, IIncludableQueryable<LiveLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LiveLesson? liveLesson = await _liveLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return liveLesson;
    }

    public async Task<IPaginate<LiveLesson>?> GetListAsync(
        Expression<Func<LiveLesson, bool>>? predicate = null,
        Func<IQueryable<LiveLesson>, IOrderedQueryable<LiveLesson>>? orderBy = null,
        Func<IQueryable<LiveLesson>, IIncludableQueryable<LiveLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LiveLesson> liveLessonList = await _liveLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return liveLessonList;
    }

    public async Task<LiveLesson> AddAsync(LiveLesson liveLesson)
    {
        LiveLesson addedLiveLesson = await _liveLessonRepository.AddAsync(liveLesson);

        return addedLiveLesson;
    }

    public async Task<LiveLesson> UpdateAsync(LiveLesson liveLesson)
    {
        LiveLesson updatedLiveLesson = await _liveLessonRepository.UpdateAsync(liveLesson);

        return updatedLiveLesson;
    }

    public async Task<LiveLesson> DeleteAsync(LiveLesson liveLesson, bool permanent = false)
    {
        LiveLesson deletedLiveLesson = await _liveLessonRepository.DeleteAsync(liveLesson);

        return deletedLiveLesson;
    }
}
