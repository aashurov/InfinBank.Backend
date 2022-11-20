using AutoMapper;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.DeleteRectangleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectangleSquare;
using InfinBank.Application.CQRS.Queries.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleCircumferenceList;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;
using InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;
using InfinBank.Application.CQRS.Queries.Rectangles.GetRectangleSquareDetails;
using InfinBank.Application.CQRS.Queries.Rectangles.GetRectangleSquareList;
using InfinBank.WebApi.Models.Circles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinBank.WebApi.Controllers;

/// <summary>
/// Rectangle
/// </summary>

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
[Produces("application/json")]
[Route("api/[controller]")]
public class RectangleSquareController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for class RectangleSquareController 
    /// </summary>
    /// <param name="mapper"></param>
    public RectangleSquareController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of calculated and saved squares of rectanlge only for User
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// </remarks>
    /// <returns>
    /// Return RectangleSquareListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetSquares")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<RectangleSquareListVm>> GetSquares()
    {
        var query = new GetRectangleSquareListQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get details of square by id only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Square Id (int)</param>
    /// <returns>
    /// Return RectangleSquareDetailsVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetSquare/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<RectangleSquareDetailsVm>> GetSquare(int Id)
    {
        var query = new GetRectangleSquareDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Calculate and save to dattabase Rectangle square only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>
    /// Return Id (int)
    /// </returns>
    /// <param name="createRectangleSquareDto">CreateRectangleSquareDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost("CalculateSquare")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CalculateSquare([FromBody] CreateRectangleSquareDto createRectangleSquareDto)
    {
        var command = _mapper.Map<CreateRectangleSquareCommand>(createRectangleSquareDto);
        var rectangleResponse = await Mediator.Send(command);
        return Ok(rectangleResponse);
    }

    /// <summary>
    /// Update rectangle square by id only for User
    /// </summary>
    /// <param name="updateRectangleSquareDto"></param>
    /// <returns></returns>
    [HttpPut("UpdateSquare")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateRectangleSquareDto updateRectangleSquareDto)
    {
        var command = _mapper.Map<UpdateRectangleSquareCommand>(updateRectangleSquareDto);
        var rectangleResponse = await Mediator.Send(command);
        return Ok(rectangleResponse);
    }

    /// <summary>
    /// Delete rectangle square by id only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Id of the rectangle square</param>s
    /// <returns>
    /// Returns NoContent
    /// </returns>
    /// <responce code="204">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpDelete("DeleteSquare/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(int Id)
    {
        var query = new DeleteRectangleSquareCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }
 
}