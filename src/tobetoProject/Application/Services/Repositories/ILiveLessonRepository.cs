using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILiveLessonRepository : IAsyncRepository<LiveLesson, Guid>, IRepository<LiveLesson, Guid>
{
}