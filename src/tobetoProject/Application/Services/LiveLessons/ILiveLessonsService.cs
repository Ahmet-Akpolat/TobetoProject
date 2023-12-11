using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LiveLessons;

public interface ILiveLessonsService
{
    Task<LiveLesson?> GetAsync(
        Expression<Func<LiveLesson, bool>> predicate,
        Func<IQueryable<LiveLesson>, IIncludableQueryable<LiveLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LiveLesson>?> GetListAsync(
        Expression<Func<LiveLesson, bool>>? predicate = null,
        Func<IQueryable<LiveLesson>, IOrderedQueryable<LiveLesson>>? orderBy = null,
        Func<IQueryable<LiveLesson>, IIncludableQueryable<LiveLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LiveLesson> AddAsync(LiveLesson liveLesson);
    Task<LiveLesson> UpdateAsync(LiveLesson liveLesson);
    Task<LiveLesson> DeleteAsync(LiveLesson liveLesson, bool permanent = false);
}
