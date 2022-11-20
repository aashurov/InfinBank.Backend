using AutoMapper;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectanglePerimeter;
using InfinBank.Application.CQRS.Commands.Rectangles.CreateRectangleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.DeleteRectanglePerimeter;
using InfinBank.Application.CQRS.Commands.Rectangles.DeleteRectangleSquare;
using InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectanglePerimeter;
using InfinBank.Application.CQRS.Commands.Rectangles.UpdateRectangleSquare;
using InfinBank.Application.CQRS.Queries.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleCircumferenceList;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;
using InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;
using InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterDetails;
using InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterList;
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
public class RectanglePerimeterController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for class RectanglePerimeterController only for User
    /// </summary>
    /// <param name="mapper"></param>
    public RectanglePerimeterController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of calculated and saved perimetres
    /// </summary>
    /// <remarks>
    /// Sample request: http://localhost:..../GetPerimetres
    /// </remarks>
    /// <returns>
    /// Return RectanglePerimeterListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetPerimetres")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<RectanglePerimeterListVm>> GetPerimetres()
    {
        var query = new GetRectanglePerimeterListQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get details of perimeter by id only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Square Id (int)</param>
    /// <returns>
    /// Return RectanglePerimeterDetailsVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetPerimeter/{Id}")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<RectanglePerimeterDetailsVm>> GetPerimeter(int Id)
    {
        var query = new GetRectanglePerimeterDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Calculate and save to database rectangle perimeter only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>
    /// Return Id (int)
    /// </returns>
    /// <param name="createRectanglePerimeterDto">CreateRectanglePerimeterDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost("CalculatePerimeter")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CalculatePerimeter([FromBody] CreateRectanglePerimeterDto createRectanglePerimeterDto)
    {
        var command = _mapper.Map<CreateRectanglePerimeterCommand>(createRectanglePerimeterDto);
        var rectangleResponse = await Mediator.Send(command);
        return Ok(rectangleResponse);
    }

    /// <summary>
    /// Update pectangle perimeter by id only for User
    /// </summary>
    /// <param name="updateRectanglePerimeterDto"></param>
    /// <returns></returns>
    [HttpPut("UpdatePerimeter")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateRectanglePerimeterDto updateRectanglePerimeterDto)
    {
        var command = _mapper.Map<UpdateRectanglePerimeterCommand>(updateRectanglePerimeterDto);
        var rectangleResponse = await Mediator.Send(command);
        return Ok(rectangleResponse);
    }

    /// <summary>
    /// Delete rectangle perimeter by id only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Id of the rectangle perimeter</param>
    /// <returns>
    /// Returns NoContent
    /// </returns>
    /// <responce code="204">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpDelete("DeletePerimeter/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(int Id)
    {
        var query = new DeleteRectanglePerimeterCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }
 
}