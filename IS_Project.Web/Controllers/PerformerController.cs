using IS_Project.Application.Common;
using IS_Project.Application.UseCases.Performer.Commands.Create;
using IS_Project.Application.UseCases.Performer.Commands.Delete;
using IS_Project.Application.UseCases.Performer.Commands.Update;
using IS_Project.Application.UseCases.Performer.Queries.GetPerformer;
using IS_Project.Application.UseCases.Performer.Queries.GetPerformerWithPagination;
using IS_Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IS_Project.Web.Controllers;

/// <summary>
/// Контроллер по исполнителям
/// </summary>
/// <param name="sender"></param>
[Route("api/[controller]")]
[ApiController]
public class PerformerController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Получает исполнителя по Id
    /// </summary>
    /// <param name="id">Ид исполнителя</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Объект исполнителя</returns>
    [HttpGet("{id:guid}", Name = nameof(GetPerformerQuery))]
    [Produces(typeof(Performer))]
    [ProducesResponseType(typeof(Performer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(Guid id, CancellationToken token)
    {
        var performer = await sender.Send(new GetPerformerQuery(id), token);
        return Ok(performer);
    }
    /// <summary>
    /// Получает список исполнителей
    /// </summary>
    /// <param name="setting">Параметры поиска</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>список исполнителей</returns>
    [HttpGet]
    [Produces(typeof(PaginatedList<Performer>))]
    [ProducesResponseType(typeof(PaginatedList<Performer>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetList(GetPerformerWithPagination setting, CancellationToken token)
    {
        var performerList = await sender.Send(setting, token);
        return Ok(performerList);
    }
    /// <summary>
    /// Добавить нового исполнителя
    /// </summary>
    /// <param name="create">Данные нового исполнителя</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Объект нового исполнителя</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Performer), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreatePerformerCommand create, CancellationToken token)
    {
        var id = await sender.Send(create, token);
        return CreatedAtRoute(nameof(GetPerformerQuery), new { id }, null);
    }
    /// <summary>
    /// Обновить существующего исполнителя
    /// </summary>
    /// <param name="update">Обновленные данные</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Объект обновленного исполнителя</returns>
    [HttpPut]
    [ProducesResponseType(typeof(Performer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdatePerformerCommand update, CancellationToken token)
    {
        var performer = await sender.Send(update, token);
        return Ok(performer);
    }
    /// <summary>
    /// Удаляет исполнителя из базы (совсем)
    /// </summary>
    /// <param name="id">Ид исполнителя</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>void</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken token)
    {
        await sender.Send(new DeletePerformerCommand(id), token);
        return NoContent();
    }
}
