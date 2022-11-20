using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Square;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaList;

public class SquareAreaLookupDto : IMapWith<SquareEntity>
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
        profile.CreateMap<SquareEntity, SquareAreaLookupDto>()
            .ForMember(squareAreaLookupDto => squareAreaLookupDto.Id, opt => opt.MapFrom(squareEntity => squareEntity.Id))

            .ForMember(squareAreaLookupDto => squareAreaLookupDto.Side, opt => opt.MapFrom(squareEntity => squareEntity.Side))
            .ForMember(squareAreaLookupDto => squareAreaLookupDto.Area, opt => opt.MapFrom(squareEntity => squareEntity.Area))

            .ForMember(squareAreaLookupDto => squareAreaLookupDto.DateCreated, opt => opt.MapFrom(squareEntity => squareEntity.DateCreated))
            .ForMember(squareAreaLookupDto => squareAreaLookupDto.DateUpdated, opt => opt.MapFrom(squareEntity => squareEntity.DateUpdated));
    }
}
