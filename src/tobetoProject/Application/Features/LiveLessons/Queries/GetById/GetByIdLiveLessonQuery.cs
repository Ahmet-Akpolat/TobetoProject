using Application.Features.LiveLessons.Constants;
using Application.Features.LiveLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.LiveLessons.Constants.LiveLessonsOperationClaims;

namespace Application.Features.LiveLessons.Queries.GetById;

public class GetByIdLiveLessonQuery : IRequest<GetByIdLiveLessonResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdLiveLessonQueryHandler : IRequestHandler<GetByIdLiveLessonQuery, GetByIdLiveLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILiveLessonRepository _liveLessonRepository;
        private readonly LiveLessonBusinessRules _liveLessonBusinessRules;

        public GetByIdLiveLessonQueryHandler(IMapper mapper, ILiveLessonRepository liveLessonRepository, LiveLessonBusinessRules liveLessonBusinessRules)
        {
            _mapper = mapper;
            _liveLessonRepository = liveLessonRepository;
            _liveLessonBusinessRules = liveLessonBusinessRules;
        }

        public async Task<GetByIdLiveLessonResponse> Handle(GetByIdLiveLessonQuery request, CancellationToken cancellationToken)
        {
            LiveLesson? liveLesson = await _liveLessonRepository.GetAsync(predicate: ll => ll.Id == request.Id, cancellationToken: cancellationToken);
            await _liveLessonBusinessRules.LiveLessonShouldExistWhenSelected(liveLesson);

            GetByIdLiveLessonResponse response = _mapper.Map<GetByIdLiveLessonResponse>(liveLesson);
            return response;
        }
    }
}