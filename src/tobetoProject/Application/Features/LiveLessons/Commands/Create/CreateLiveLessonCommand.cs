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

namespace Application.Features.LiveLessons.Commands.Create;

public class CreateLiveLessonCommand : IRequest<CreatedLiveLessonResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public string? RecordVideo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string[] Roles => new[] { Admin, Write, LiveLessonsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLiveLessons";

    public class CreateLiveLessonCommandHandler : IRequestHandler<CreateLiveLessonCommand, CreatedLiveLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILiveLessonRepository _liveLessonRepository;
        private readonly LiveLessonBusinessRules _liveLessonBusinessRules;

        public CreateLiveLessonCommandHandler(IMapper mapper, ILiveLessonRepository liveLessonRepository,
                                         LiveLessonBusinessRules liveLessonBusinessRules)
        {
            _mapper = mapper;
            _liveLessonRepository = liveLessonRepository;
            _liveLessonBusinessRules = liveLessonBusinessRules;
        }

        public async Task<CreatedLiveLessonResponse> Handle(CreateLiveLessonCommand request, CancellationToken cancellationToken)
        {
            LiveLesson liveLesson = _mapper.Map<LiveLesson>(request);

            await _liveLessonRepository.AddAsync(liveLesson);

            CreatedLiveLessonResponse response = _mapper.Map<CreatedLiveLessonResponse>(liveLesson);
            return response;
        }
    }
}