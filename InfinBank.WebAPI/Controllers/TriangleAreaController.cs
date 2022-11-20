using AutoMapper;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;
using InfinBank.Application.CQRS.Commands.Squares.CreateSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.DeleteSquareArea;
using InfinBank.Application.CQRS.Commands.Squares.UpdateSquareArea;
using InfinBank.Application.CQRS.Commands.Triangles.CreateTriangleArea;
using InfinBank.Application.CQRS.Commands.Triangles.DeleteTriangleArea;
using InfinBank.Application.CQRS.Commands.Triangles.UpdateTriangleArea;
using InfinBank.Application.CQRS.Queries.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleCircumferenceList;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;
using InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;
using InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaDetails;
using InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaList;
using InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterList;
using InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaDetails;
using InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaList;
using InfinBank.WebApi.Models.Circles;
using InfinBank.WebApi.Models.Squares;
using InfinBank.WebApi.Models.Triangles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinBank.WebApi.Controllers;

/// <summary>
/// Triangle
/// </summary>

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
[Produces("application/json")]
[Route("api/[controller]")]
public class TriangleAreaController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for class TriangleAreaController
    /// </summary>
    /// <param name="mapper"></param>
    public TriangleAreaController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of calculated and saved areas of triangle only for User
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// </remarks>
    /// <returns>
    /// Return TriangleAreaListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetAreas")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TriangleAreaListVm>> GetAreas()
    {
        var query = new GetTriangleAreaListQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get details area of triangle by id only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Area Id (int)</param>
    /// <returns>
    /// Return TriangleAreaDetailsVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetArea/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TriangleAreaDetailsVm>> GetArea(int Id)
    {
        var query = new GetTriangleAreaDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Calculate and save to database triangle area only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>
    /// Return Id (int)
    /// </returns>
    /// <param name="createTriangleAreaDto">CreateTriangleAreaDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost("CalculateArea")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CalculateArea([FromBody] CreateTriangleAreaDto createTriangleAreaDto)
    {
        var command = _mapper.Map<CreateTriangleAreaCommand>(createTriangleAreaDto);
        var triangleResponse = await Mediator.Send(command);
        return Ok(triangleResponse);
    }

    /// <summary>
    /// Update area of triangle by id only for User
    /// </summary>
    /// <param name="updateTriangleAreaDto"></param>
    /// <returns></returns>
    [HttpPut("UpdateArea")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateTriangleAreaDto updateTriangleAreaDto)
    {
        var command = _mapper.Map<UpdateTriangleAreaCommand>(updateTriangleAreaDto);
        var triangleResponse = await Mediator.Send(command);
        return Ok(triangleResponse);
    }

    /// <summary>
    /// Delete area of triangle by id only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Id of the triangle area</param>
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
        var query = new DeleteTriangleAreaCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }

}