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

namespace Application.Features.LiveLessons.Commands.Update;

public class UpdateLiveLessonCommand : IRequest<UpdatedLiveLessonResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public string? RecordVideo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string[] Roles => new[] { Admin, Write, LiveLessonsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLiveLessons";

    public class UpdateLiveLessonCommandHandler : IRequestHandler<UpdateLiveLessonCommand, UpdatedLiveLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILiveLessonRepository _liveLessonRepository;
        private readonly LiveLessonBusinessRules _liveLessonBusinessRules;

        public UpdateLiveLessonCommandHandler(IMapper mapper, ILiveLessonRepository liveLessonRepository,
                                         LiveLessonBusinessRules liveLessonBusinessRules)
        {
            _mapper = mapper;
            _liveLessonRepository = liveLessonRepository;
            _liveLessonBusinessRules = liveLessonBusinessRules;
        }

        public async Task<UpdatedLiveLessonResponse> Handle(UpdateLiveLessonCommand request, CancellationToken cancellationToken)
        {
            LiveLesson? liveLesson = await _liveLessonRepository.GetAsync(predicate: ll => ll.Id == request.Id, cancellationToken: cancellationToken);
            await _liveLessonBusinessRules.LiveLessonShouldExistWhenSelected(liveLesson);
            liveLesson = _mapper.Map(request, liveLesson);

            await _liveLessonRepository.UpdateAsync(liveLesson!);

            UpdatedLiveLessonResponse response = _mapper.Map<UpdatedLiveLessonResponse>(liveLesson);
            return response;
        }
    }
}