using MyStore.Application.Commodities.Commands.CreateTodoItem;
using MyStore.Application.Commodities.Commands.DeleteTodoItem;
using MyStore.Application.Commodities.Commands.UpdateTodoItem;
using MyStore.Application.Commodities.Commands.UpdateTodoItemDetail;
using MyStore.Application.Commodities.Queries.GetTodoItemsWithPagination;
using MyStore.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class CommoditiesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<CommodityBriefDto>>> GetCommoditiesWithPagination(
        [FromQuery] GetCommoditiesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCommodityCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateCommodityCommand command)
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
    public async Task<IActionResult> UpdateItemDetails(int id, UpdateCommodityDetailCommand command)
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
        await Mediator.Send(new DeleteCommodityCommand(id));

        return NoContent();
    }
}
