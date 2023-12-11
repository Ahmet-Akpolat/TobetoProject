using Application.Features.LiveLessons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.LiveLessons.Constants.LiveLessonsOperationClaims;

namespace Application.Features.LiveLessons.Queries.GetList;

public class GetListLiveLessonQuery : IRequest<GetListResponse<GetListLiveLessonListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLiveLessons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLiveLessons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLiveLessonQueryHandler : IRequestHandler<GetListLiveLessonQuery, GetListResponse<GetListLiveLessonListItemDto>>
    {
        private readonly ILiveLessonRepository _liveLessonRepository;
        private readonly IMapper _mapper;

        public GetListLiveLessonQueryHandler(ILiveLessonRepository liveLessonRepository, IMapper mapper)
        {
            _liveLessonRepository = liveLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLiveLessonListItemDto>> Handle(GetListLiveLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LiveLesson> liveLessons = await _liveLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLiveLessonListItemDto> response = _mapper.Map<GetListResponse<GetListLiveLessonListItemDto>>(liveLessons);
            return response;
        }
    }
}