using IS_Project.Application.Common;
using IS_Project.Application.UseCases.Project.Commands.Create;
using IS_Project.Application.UseCases.Project.Commands.Delete;
using IS_Project.Application.UseCases.Project.Commands.Update;
using IS_Project.Application.UseCases.Project.Queries.GetProject;
using IS_Project.Application.UseCases.Project.Queries.GetProjectWithPagination;
using IS_Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IS_Project.Web.Controllers;

/// <summary>
/// Контроллер для управления проектами
/// </summary>
/// <param name="sender"></param>
[Route("api/[controller]")]
[ApiController]
public class ProjectController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Получает проект по Id
    /// </summary>
    /// <param name="id">Ид проекта</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Объект проекта</returns>
    [HttpGet("{id:guid}", Name = nameof(GetProjectQuery))]
    [Produces(typeof(Project))]
    [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(Guid id, CancellationToken token)
    {
        var project = await sender.Send(new GetProjectQuery(id), token);
        return Ok(project);
    }

    /// <summary>
    /// Получает список проектов
    /// </summary>
    /// <param name="token">Токен отмены</param>
    /// <returns>список проектов</returns>
    [HttpGet]
    [Produces(typeof(PaginatedList<Project>))]
    [ProducesResponseType(typeof(PaginatedList<Project>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetList(CancellationToken token)
    {
        var projectList = await sender.Send(new GetProjectWithPagination(), token);
        return Ok(projectList);
    }
    /// <summary>
    /// Добавить новый проект
    /// </summary>
    /// <param name="create">Данные нового проекта</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Объект нового проекта</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Project), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateProjectCommand create, CancellationToken token)
    {
        var id = await sender.Send(create, token);
        return CreatedAtRoute(nameof(GetProjectQuery), new { id }, null);
    }
    /// <summary>
    /// Обновить существующий проект
    /// </summary>
    /// <param name="update">Обновленные данные</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Объект обновленного проекта</returns>
    [HttpPut]
    [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateProjectCommand update, CancellationToken token)
    {
        var project = await sender.Send(update, token);
        return Ok(project);
    }
    /// <summary>
    /// Удаляет проект из базы (совсем)
    /// </summary>
    /// <param name="id">Ид проекта</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>void</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken token)
    {
        await sender.Send(new DeleteProjectCommand(id), token);
        return NoContent();
    }
}
