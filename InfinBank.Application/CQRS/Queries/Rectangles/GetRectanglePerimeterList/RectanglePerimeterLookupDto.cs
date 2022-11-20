using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfinBank.Application.Common.Mappings;
using InfinBank.Domain.Entities.Rectangle;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterList;

public class RectanglePerimeterLookupDto : IMapWith<RectangleEntity>
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
    /// Perimeter of rectangle
    /// </summary>
    public double Perimeter { get; set; }


    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RectangleEntity, RectanglePerimeterLookupDto>()
            .ForMember(rectanglePerimeterLookupDto => rectanglePerimeterLookupDto.Id, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Id))

            .ForMember(rectanglePerimeterLookupDto => rectanglePerimeterLookupDto.Width, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Width))
            .ForMember(rectanglePerimeterLookupDto => rectanglePerimeterLookupDto.Length, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Length))
            .ForMember(rectanglePerimeterLookupDto => rectanglePerimeterLookupDto.Perimeter, opt => opt.MapFrom(rectangleEntity => rectangleEntity.Perimeter))

            .ForMember(rectanglePerimeterLookupDto => rectanglePerimeterLookupDto.DateCreated, opt => opt.MapFrom(rectangleEntity => rectangleEntity.DateCreated))
            .ForMember(rectanglePerimeterLookupDto => rectanglePerimeterLookupDto.DateUpdated, opt => opt.MapFrom(rectangleEntity => rectangleEntity.DateUpdated));
    }
}
