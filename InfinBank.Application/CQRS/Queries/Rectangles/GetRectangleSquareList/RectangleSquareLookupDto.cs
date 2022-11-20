using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Rectangle;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectangleSquareList;

public class RectangleSquareLookupDto : IMapWith<RectangleEntity>
{
    public int Id { get; set; }

    /// <summary>
    /// Length of rectangle
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Width of rectangle
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Square of rectangle
    /// </summary>
    public double Square { get; set; }


    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RectangleEntity, RectangleSquareLookupDto>()
            .ForMember(rectanglePerimeterLookupDto => rectanglePerimeterLookupDto.Id, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Id))

            .ForMember(rectangleSquareLookupDto => rectangleSquareLookupDto.Width, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Width))
            .ForMember(rectangleSquareLookupDto => rectangleSquareLookupDto.Length, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Length))
            .ForMember(rectangleSquareLookupDto => rectangleSquareLookupDto.Square, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Square))

            .ForMember(rectangleSquareLookupDto => rectangleSquareLookupDto.DateCreated, opt => opt.MapFrom(rectangleEntity => rectangleEntity.DateCreated))
            .ForMember(rectangleSquareLookupDto => rectangleSquareLookupDto.DateUpdated, opt => opt.MapFrom(rectangleEntity => rectangleEntity.DateUpdated));
    }
}
