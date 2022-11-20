﻿using InfinBank.Domain.Common;

namespace InfinBank.Domain.Entities.Triangle;

/// <summary>
/// Request class for calculate the area [S=sqrt(p*(p-a)*(p-b)*(p-c))] and the perimeter [P=a+b+c] of a triangle
/// </summary>
public class TrianglePerimeterResponse : BaseAuditableEntity
{
    /// <summary>
    /// A side of triangle
    /// </summary>
    public double ASide { get; set; }

    /// <summary>
    /// B side of triangle
    /// </summary>
    public double BSide { get; set; }

    /// <summary>
    /// B side of triangle
    /// </summary>
    public double CSide { get; set; }

    /// <summary>
    /// Perimeter of square
    /// </summary>
    public double Perimeter { get; set; }

  
}