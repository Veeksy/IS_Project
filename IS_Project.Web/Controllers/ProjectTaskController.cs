using IS_Project.Application.UseCases.ProjectTask.Commands.Create;
using IS_Project.Application.UseCases.ProjectTask.Commands.Delete;
using IS_Project.Application.UseCases.ProjectTask.Commands.Update;
using IS_Project.Application.UseCases.ProjectTask.Queries.GetProjectTask;
using IS_Project.Application.UseCases.ProjectTask.Queries.GetProjectTaskWithPagination;
using IS_Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IS_Project.Web.Controllers;

/// <summary>
/// Контроллер для управления задачами
/// </summary>
/// <param name="sender"></param>
[Route("api/[controller]")]
[ApiController]
public class ProjectTaskController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Получает задачу по Id
    /// </summary>
    /// <param name="id">Ид задачи</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Объект задачия</returns>
    [HttpGet("{id:guid}", Name = nameof(GetProjectTaskQuery))]
    [Produces(typeof(ProjectTask))]
    [ProducesResponseType(typeof(ProjectTask), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(Guid id, CancellationToken token)
    {
        var prjTask = await sender.Send(new GetProjectTaskQuery(id), token);
        return Ok(prjTask);
    }

    /// <summary>
    /// Получает список задач
    /// </summary>
    /// <param name="token">Токен отмены</param>
    /// <returns>список задач</returns>
    [HttpGet]
    [Produces(typeof(List<ProjectTask>))]
    [ProducesResponseType(typeof(List<ProjectTask>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetList(CancellationToken token)
    {
        var projectTaskList = await sender.Send(new GetProjectTaskWithoutPagination(), token);
        return Ok(projectTaskList);
    }
    /// <summary>
    /// Добавить новую задачу
    /// </summary>
    /// <param name="create">Данные новой задачи</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Объект новой задачи</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProjectTask), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateProjectTaskCommand create, CancellationToken token)
    {
        var id = await sender.Send(create, token);
        return CreatedAtRoute(nameof(GetProjectTaskQuery), new { id }, null);
    }
    /// <summary>
    /// Обновить существующую задачу
    /// </summary>
    /// <param name="update">Обновленные данные</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Объект обновленной задачи</returns>
    [HttpPut]
    [ProducesResponseType(typeof(Performer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateProjectTaskCommand update, CancellationToken token)
    {
        var projectTask = await sender.Send(update, token);
        return Ok(projectTask);
    }
    /// <summary>
    /// Удаляет задачу из базы (совсем)
    /// </summary>
    /// <param name="id">Ид задачи</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>void</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken token)
    {
        await sender.Send(new DeleteProjectTaskCommand(id), token);
        return NoContent();
    }
}