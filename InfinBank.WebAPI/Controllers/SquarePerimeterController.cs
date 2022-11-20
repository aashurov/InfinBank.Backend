using AutoMapper;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquarePerimeter;
using InfinBank.Application.CQRS.Commands.Squares.DeleteSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.DeleteSquarePerimeter;
using InfinBank.Application.CQRS.Commands.Squares.UpdateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.UpdateSquarePerimeter;
using InfinBank.Application.CQRS.Queries.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleCircumferenceList;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;
using InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;
using InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaDetails;
using InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaList;
using InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterDetails;
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
public class SquarePerimeterController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for class CircleController
    /// </summary>
    /// <param name="mapper"></param>
    public SquarePerimeterController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of calculated and saved perimetres of square only for Administrator
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// </remarks>
    /// <returns>
    /// Return SquarePerimeterListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetPerimetres")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<SquarePerimeterListVm>> GetPerimetres()
    {
        var query = new GetSquarePerimeterListQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get details perimeter of square by id only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Perimeter Id (int)</param>
    /// <returns>
    /// Return SquarePerimeterDetailsVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetPerimeter/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<SquarePerimeterDetailsVm>> GetPerimeter(int Id)
    {
        var query = new GetSquarePerimeterDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Calculate and save to database square perimeter only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>
    /// Return Id (int)
    /// </returns>
    /// <param name="createSquarePerimeterDto">CreateSquareAreaDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost("CalculatePerimeter")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CalculatePerimeter([FromBody] CreateSquarePerimeterDto createSquarePerimeterDto)
    {
        var command = _mapper.Map<CreateSquarePerimeterCommand>(createSquarePerimeterDto);
        var squareResponse = await Mediator.Send(command);
        return Ok(squareResponse);
    }

    /// <summary>
    /// Update perimeter of square by id only for Administrator
    /// </summary>
    /// <param name="updateSquarePerimeterDto"></param>
    /// <returns></returns>
    [HttpPut("UpdatePerimeter")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateSquarePerimeterDto updateSquarePerimeterDto)
    {
        var command = _mapper.Map<UpdateSquarePerimeterCommand>(updateSquarePerimeterDto);
        var squareResponse = await Mediator.Send(command);
        return Ok(squareResponse);
    }

    /// <summary>
    /// Delete perimeter of square by id only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Id of the circle square</param>
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
        var query = new DeleteSquarePerimeterCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }

}