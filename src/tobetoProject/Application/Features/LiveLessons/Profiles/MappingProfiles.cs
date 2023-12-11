using Application.Features.LiveLessons.Commands.Create;
using Application.Features.LiveLessons.Commands.Delete;
using Application.Features.LiveLessons.Commands.Update;
using Application.Features.LiveLessons.Queries.GetById;
using Application.Features.LiveLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LiveLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LiveLesson, CreateLiveLessonCommand>().ReverseMap();
        CreateMap<LiveLesson, CreatedLiveLessonResponse>().ReverseMap();
        CreateMap<LiveLesson, UpdateLiveLessonCommand>().ReverseMap();
        CreateMap<LiveLesson, UpdatedLiveLessonResponse>().ReverseMap();
        CreateMap<LiveLesson, DeleteLiveLessonCommand>().ReverseMap();
        CreateMap<LiveLesson, DeletedLiveLessonResponse>().ReverseMap();
        CreateMap<LiveLesson, GetByIdLiveLessonResponse>().ReverseMap();
        CreateMap<LiveLesson, GetListLiveLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<LiveLesson>, GetListResponse<GetListLiveLessonListItemDto>>().ReverseMap();
    }
}