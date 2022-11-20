using AutoMapper;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleSquare;
using InfinBank.Application.CQRS.Queries.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleCircumferenceList;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;
using InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;
using InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;
using InfinBank.WebApi.Models.Circles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinBank.WebApi.Controllers;

/// <summary>
/// Circle
/// </summary>

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
[Produces("application/json")]
[Route("api/[controller]")]
public class CircleSquareController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for class CircleSquareController
    /// </summary>
    /// <param name="mapper"></param>
    public CircleSquareController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of calculated and saved squares only for Administrator
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// </remarks>
    /// <returns>
    /// Return CircleSquareListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetSquares")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CircleSquareListVm>> GetSquares()
    {
        var query = new GetCircleSquareListQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get details of square by id only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Square Id (int)</param>
    /// <returns>
    /// Return CircleSquareDetailsVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetSquare/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CircleSquareDetailsVm>> GetSquare(int Id)
    {
        var query = new GetCircleSquareDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Calculate and save to database cisrcle square only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>
    /// Return Id (int)
    /// </returns>
    /// <param name="createCircleSquareDto">CreateCircleSquareDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost("CalculateSquare")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CalculateSquare([FromBody] CreateCircleSquareDto createCircleSquareDto)
    {
        var command = _mapper.Map<CreateCircleSquareCommand>(createCircleSquareDto);
        var circleResponse = await Mediator.Send(command);
        return Ok(circleResponse);
    }

    /// <summary>
    /// Update circle Square by id only for Administrator
    /// </summary>
    /// <param name="updateCircleSquareDto"></param>
    /// <returns></returns>
    [HttpPut("UpdateSquare")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateCircleSquareDto updateCircleSquareDto)
    {
        var command = _mapper.Map<UpdateCircleSquareCommand>(updateCircleSquareDto);
        var circleResponse = await Mediator.Send(command);
        return Ok(circleResponse);
    }

    /// <summary>
    /// Delete circle square by id only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Id of the circle square</param>
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
        var query = new DeleteCircleSquareCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }
 
}