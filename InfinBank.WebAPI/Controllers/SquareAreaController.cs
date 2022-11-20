using AutoMapper;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.DeleteSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.UpdateSquareArea;
using InfinBank.Application.CQRS.Queries.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleCircumferenceList;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;
using InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;
using InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaDetails;
using InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaList;
using InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterList;
using InfinBank.WebApi.Models.Circles;
using InfinBank.WebApi.Models.Squares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinBank.WebApi.Controllers;

/// <summary>
/// Square
/// </summary>

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
[Produces("application/json")]
[Route("api/[controller]")]
public class SquareAreaController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for class SquareAreaController
    /// </summary>
    /// <param name="mapper"></param>
    public SquareAreaController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of calculated and saved areas of square only for Administrator
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// </remarks>
    /// <returns>
    /// Return SquareAreaListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetAreas")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<SquareAreaListVm>> GetAreas()
    {
        var query = new GetSquareAreaListQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get details area of square by id only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Area Id (int)</param>
    /// <returns>
    /// Return SquareAreaDetailsVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetArea/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<SquareAreaDetailsVm>> GetArea(int Id)
    {
        var query = new GetSquareAreaDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Calculate and save to database square area only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>
    /// Return Id (int)
    /// </returns>
    /// <param name="createSquareAreaDto">CreateSquareAreaDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost("CalculateArea")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CalculateArea([FromBody] CreateSquareAreaDto createSquareAreaDto)
    {
        var command = _mapper.Map<CreateSquareAreaCommand>(createSquareAreaDto);
        var squareResponse = await Mediator.Send(command);
        return Ok(squareResponse);
    }

    /// <summary>
    /// Update area of square by id only for Administrator
    /// </summary>
    /// <param name="updateSquareAreaDto"></param>
    /// <returns></returns>
    [HttpPut("UpdateArea")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateSquareAreaDto updateSquareAreaDto)
    {
        var command = _mapper.Map<UpdateSquareAreaCommand>(updateSquareAreaDto);
        var squareResponse = await Mediator.Send(command);
        return Ok(squareResponse);
    }

    /// <summary>
    /// Delete area of square by id only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Id of the square area</param>
    /// <returns>
    /// Returns NoContent
    /// </returns>
    /// <responce code="204">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpDelete("DeleteArea/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(int Id)
    {
        var query = new DeleteSquareAreaCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }

}