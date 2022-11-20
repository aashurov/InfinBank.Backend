using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Application.CQRS.Commands.Circles.CreateCircleSquare;

namespace InfinBank.WebApi.Models.Circles;

/// <summary>
///Class CreateCircleSquareDto
/// </summary>
public class CreateCircleSquareDto : IMapWith<CreateCircleSquareCommand>
{
    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCircleSquareDto, CreateCircleSquareCommand>()
            .ForMember(createCircleSquareDto => createCircleSquareDto.Radius,
                options => options.MapFrom(createBranchDto => createBranchDto.Radius));
    }
}