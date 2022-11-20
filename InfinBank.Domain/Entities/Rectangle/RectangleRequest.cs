using InfinBank.Domain.Common;

namespace InfinBank.Domain.Entities.Rectangle;

/// <summary>
/// Request class for calculate the perimeter [P=(a + b)*2] and the area [S=a*b] of rectangle
/// </summary>
public class RectangleRequest : BaseAuditableEntity
{
    /// <summary>
    /// Length of rectangle
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Width of rectangle
    /// </summary>
    public double Width { get; set; }
}