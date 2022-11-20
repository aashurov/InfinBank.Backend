using AutoMapper;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleCircumference;
using InfinBank.Application.CQRS.Commands.Circles.DeleteCircleSquare;
using InfinBank.Application.CQRS.Commands.Circles.UpdateCircleCircumference;
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

//[Authorize(Roles = "Administrator")]
//[Authorize]
[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
[Produces("application/json")]
[Route("api/[controller]")]
public class CircleCircumferenceController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for class CircleCircumferenceController
    /// </summary>
    /// <param name="mapper"></param>
    public CircleCircumferenceController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get the list of calculated and saved circumference only for Administrator
    /// </summary>
    /// <remarks>
    /// Sample request: 
    /// </remarks>
    /// <returns>
    /// Return CircleCircumferenceListVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    /// <responce code="404">Not Found</responce>
    [HttpGet("GetCircumferences")]
    //[Authorize(Policy ="AdminPolicy")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CircleCircumferenceListVm>> GetCircumferences()
    {
        var query = new GetCircleCircumferenceListQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Get details of circumference by id only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Circumference Id (int)</param>
    /// <returns>
    /// Return CircleCircumferenceDetailsVm
    /// </returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpGet("GetCircumference/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CircleCircumferenceDetailsVm>> GetCircumference(int Id)
    {
        var query = new GetCircleCircumferenceDetailsQuery
        {
            Id = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Calculate and save to database cisrcle circumference only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>
    /// Return Id (int)
    /// </returns>
    /// <param name="createCircleCircumferenceDto">CreateCircleCircumferenceDto object</param>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpPost("CalculateCircumference")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CalculateCircumference([FromBody] CreateCircleCircumferenceDto createCircleCircumferenceDto)
    {
        var command = _mapper.Map<CreateCircleCircumferenceCommand>(createCircleCircumferenceDto);
        var circleCircumferenceResponse = await Mediator.Send(command);
        return Ok(circleCircumferenceResponse);
    }

    /// <summary>
    /// Update circle circumference by id only for Administrator
    /// </summary>
    /// <param name="updateCircleCircumferenceDto"></param>
    /// <returns></returns>
    [HttpPut("UpdateCircumference")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateCircleCircumferenceDto updateCircleCircumferenceDto)
    {
        var command = _mapper.Map<UpdateCircleCircumferenceCommand>(updateCircleCircumferenceDto);
        var circleCircumferenceResponse = await Mediator.Send(command);
        return Ok(circleCircumferenceResponse);
    }

    /// <summary>
    /// Delete circle circumference by id only for Administrator
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="Id">Id of the circle circumference</param>
    /// <returns>
    /// Returns NoContent
    /// </returns>
    /// <responce code="204">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpDelete("DeleteCircumference/{Id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(int Id)
    {
        var query = new DeleteCircleCircumferenceCommand
        {
            Id = Id
        };
        await Mediator.Send(query);
        return NoContent();
    }
}