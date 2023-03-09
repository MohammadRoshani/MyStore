using MyStore.Application.Categories.Commands.CreateTodoList;
using MyStore.Application.Categories.Commands.DeleteTodoList;
using MyStore.Application.Categories.Commands.UpdateTodoList;
using MyStore.Application.Categories.Queries.ExportTodos;
using MyStore.Application.Categories.Queries.GetTodos;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class CategoriesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ItemsVm>> Get()
    {
        return await Mediator.Send(new GetItemsQuery());
    }

    [HttpGet("{id}")]
    public async Task<FileResult> Get(int id)
    {
        ExportItemsVm vm = await Mediator.Send(new ExportItemsQuery { CategoryId = id });

        return File(vm.Content, vm.ContentType, vm.FileName);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteCategoryCommand(id));

        return NoContent();
    }
}
