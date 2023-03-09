using MyStore.Application.Props.Commands.CreateTodoItem;
using MyStore.Application.Props.Commands.DeleteTodoItem;
using MyStore.Application.Props.Commands.UpdateTodoItem;
using MyStore.Application.Props.Commands.UpdateTodoItemDetail;
using MyStore.Application.Props.Queries.GetTodoItemsWithPagination;
using MyStore.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class PropsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<PropBriefDto>>> GetPropsWithPagination(
        [FromQuery] GetPropsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePropCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdatePropCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateItemDetails(int id, UpdatePropDetailCommand command)
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
        await Mediator.Send(new DeletePropCommand(id));

        return NoContent();
    }
}
