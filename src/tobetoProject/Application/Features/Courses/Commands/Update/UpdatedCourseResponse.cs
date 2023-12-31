using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Courses.Commands.Update;

public class UpdatedCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int? Like { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Manufacturer Manufacturer { get; set; }
}