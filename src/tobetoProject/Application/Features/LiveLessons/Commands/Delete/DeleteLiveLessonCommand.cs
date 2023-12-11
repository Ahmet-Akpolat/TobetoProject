using Application.Features.LiveLessons.Constants;
using Application.Features.LiveLessons.Constants;
using Application.Features.LiveLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.LiveLessons.Constants.LiveLessonsOperationClaims;

namespace Application.Features.LiveLessons.Commands.Delete;

public class DeleteLiveLessonCommand : IRequest<DeletedLiveLessonResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, LiveLessonsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLiveLessons";

    public class DeleteLiveLessonCommandHandler : IRequestHandler<DeleteLiveLessonCommand, DeletedLiveLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILiveLessonRepository _liveLessonRepository;
        private readonly LiveLessonBusinessRules _liveLessonBusinessRules;

        public DeleteLiveLessonCommandHandler(IMapper mapper, ILiveLessonRepository liveLessonRepository,
                                         LiveLessonBusinessRules liveLessonBusinessRules)
        {
            _mapper = mapper;
            _liveLessonRepository = liveLessonRepository;
            _liveLessonBusinessRules = liveLessonBusinessRules;
        }

        public async Task<DeletedLiveLessonResponse> Handle(DeleteLiveLessonCommand request, CancellationToken cancellationToken)
        {
            LiveLesson? liveLesson = await _liveLessonRepository.GetAsync(predicate: ll => ll.Id == request.Id, cancellationToken: cancellationToken);
            await _liveLessonBusinessRules.LiveLessonShouldExistWhenSelected(liveLesson);

            await _liveLessonRepository.DeleteAsync(liveLesson!);

            DeletedLiveLessonResponse response = _mapper.Map<DeletedLiveLessonResponse>(liveLesson);
            return response;
        }
    }
}