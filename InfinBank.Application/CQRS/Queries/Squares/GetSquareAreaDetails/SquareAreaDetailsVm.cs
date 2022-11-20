using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Square;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaDetails;

public class SquareAreaDetailsVm : IMapWith<SquareEntity>
{
    public int Id { get; set; }

    /// <summary>
    /// Side of square
    /// </summary>
    public double Side { get; set; }

    /// <summary>
    /// Area of square
    /// </summary>
    public double Area { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<SquareEntity, SquareAreaDetailsVm>()
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.Id, opt => opt.MapFrom(squareEntity => squareEntity.Id))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.Side, opt => opt.MapFrom(squareEntity => squareEntity.Side))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.Area, opt => opt.MapFrom(squareEntity => squareEntity.Area))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.DateCreated, opt => opt.MapFrom(squareEntity => squareEntity.DateCreated))
            .ForMember(squareAreaDetailsVm => squareAreaDetailsVm.DateUpdated, opt => opt.MapFrom(squareEntity => squareEntity.DateUpdated));
    }
}
