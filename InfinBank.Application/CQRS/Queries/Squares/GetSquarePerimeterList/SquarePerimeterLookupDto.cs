using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Square;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterList;

public class SquarePerimeterLookupDto : IMapWith<SquareEntity>
{
    public int Id { get; set; }

    /// <summary>
    /// Side of square
    /// </summary>
    public double Side { get; set; }

    /// <summary>
    /// Perimeter of square
    /// </summary>
    public double Perimeter { get; set; }


    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<SquareEntity, SquarePerimeterLookupDto>()
            .ForMember(squarePerimeterLookupDto => squarePerimeterLookupDto.Id, opt => opt.MapFrom(squareEntity => squareEntity.Id))

            .ForMember(squarePerimeterLookupDto => squarePerimeterLookupDto.Side, opt => opt.MapFrom(squareEntity => squareEntity.Side))
            .ForMember(squarePerimeterLookupDto => squarePerimeterLookupDto.Perimeter, opt => opt.MapFrom(squareEntity => squareEntity.Perimeter))

            .ForMember(squarePerimeterLookupDto => squarePerimeterLookupDto.DateCreated, opt => opt.MapFrom(squareEntity => squareEntity.DateCreated))
            .ForMember(squarePerimeterLookupDto => squarePerimeterLookupDto.DateUpdated, opt => opt.MapFrom(squareEntity => squareEntity.DateUpdated));
    }
}
