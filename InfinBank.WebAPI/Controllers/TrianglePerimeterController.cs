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
using InfinBank.Application.CQRS.Commands.Triangles.CreateTrianglePerimeter;
using InfinBank.Application.CQRS.Commands.Triangles.DeleteTriangleArea;
using InfinBank.Application.CQRS.Commands.Triangles.DeleteTrianglePerimeter;
using InfinBank.Application.CQRS.Commands.Triangles.UpdateTriangleArea;
using InfinBank.Application.CQRS.Commands.Triangles.UpdateTrianglePerimeter;
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
using InfinBank.Application.CQRS.Queries.Triangles.GetTrianglePerimeterDetails;
using InfinBank.Application.CQRS.Queries.Triangles.GetTrianglePerimeterList;
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
public class TrianglePerimeterController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for class TrianglePerimeterController
    /// </summary>
    /// <param name="mapper"></param>
    public TrianglePerimeterController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of calculated and saved perimetres of triangle only for User
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// </remarks>
    /// <returns>
    /// Return TrianglePerimetreListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetPerimetres")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TrianglePerimeterListVm>> GetPerimetres()
    {
        var query = new GetTrianglePerimeterListQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get details perimeter of triangle by id only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Perimeter Id (int)</param>
    /// <returns>
    /// Return TrianglePerimeterDetailsVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetPerimeter/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TrianglePerimeterDetailsVm>> GetPerimeter(int Id)
    {
        var query = new GetTrianglePerimeterDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Calculate and save to database triangle perimeter only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>
    /// Return Id (int)
    /// </returns>
    /// <param name="createTrianglePerimeterDto">CreateTrianglePerimeterDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost("CalculatePerimeter")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CalculatePerimeter([FromBody] CreateTrianglePerimeterDto createTrianglePerimeterDto)
    {
        var command = _mapper.Map<CreateTrianglePerimeterCommand>(createTrianglePerimeterDto);
        var triangleResponse = await Mediator.Send(command);
        return Ok(triangleResponse);
    }

    /// <summary>
    /// Update perimeter of triangle by id only for User
    /// </summary>
    /// <param name="updateTrianglePerimeterDto"></param>
    /// <returns></returns>
    [HttpPut("UpdatePerimeter")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateTrianglePerimeterDto updateTrianglePerimeterDto)
    {
        var command = _mapper.Map<UpdateTrianglePerimeterCommand>(updateTrianglePerimeterDto);
        var triangleResponse = await Mediator.Send(command);
        return Ok(triangleResponse);
    }

    /// <summary>
    /// Delete perimeter of triangle by id only for User
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Id of the triangle perimeter</param>
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
        var query = new DeleteTrianglePerimeterCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }

}