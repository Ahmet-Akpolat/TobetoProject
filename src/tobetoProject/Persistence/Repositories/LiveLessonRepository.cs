using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LiveLessonRepository : EfRepositoryBase<LiveLesson, Guid, BaseDbContext>, ILiveLessonRepository
{
    public LiveLessonRepository(BaseDbContext context) : base(context)
    {
    }
}