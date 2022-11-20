using InfinBank.Domain.Common;

namespace InfinBank.Domain.Entities.Square;

/// <summary>
/// Request class for calculate the area [S=a*a] and the perimeter [P=4*a ] of a square 
/// </summary>
public class SquareEntity : BaseAuditableEntity
{
    /// <summary>
    /// Side of square
    /// </summary>
    public double Side { get; set; }

    /// <summary>
    /// Perimeter of square
    /// </summary>
    public double Perimeter { get; set; }

    /// <summary>
    /// Area of square
    /// </summary>
    public double Area { get; set; }
}