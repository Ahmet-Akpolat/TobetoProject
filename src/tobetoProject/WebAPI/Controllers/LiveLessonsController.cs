using Application.Features.LiveLessons.Commands.Create;
using Application.Features.LiveLessons.Commands.Delete;
using Application.Features.LiveLessons.Commands.Update;
using Application.Features.LiveLessons.Queries.GetById;
using Application.Features.LiveLessons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LiveLessonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLiveLessonCommand createLiveLessonCommand)
    {
        CreatedLiveLessonResponse response = await Mediator.Send(createLiveLessonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLiveLessonCommand updateLiveLessonCommand)
    {
        UpdatedLiveLessonResponse response = await Mediator.Send(updateLiveLessonCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedLiveLessonResponse response = await Mediator.Send(new DeleteLiveLessonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdLiveLessonResponse response = await Mediator.Send(new GetByIdLiveLessonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLiveLessonQuery getListLiveLessonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLiveLessonListItemDto> response = await Mediator.Send(getListLiveLessonQuery);
        return Ok(response);
    }
}