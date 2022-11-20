namespace InfinBank.Domain.Entities.Rectangle;

/// <summary>
/// Response class for calculating the perimeter [P=(a + b)*2] and the area [S=a*b] of rectangle
/// </summary>
public class RectangleSquareResponse : BaseAuditableEntity
{
    
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
}