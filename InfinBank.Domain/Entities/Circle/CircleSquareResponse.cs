using InfinBank.Domain.Common;

namespace InfinBank.Domain.Entities.Circle;

/// <summary>
/// Response class for calculate the circumference [l=2πr] and the area [S=π×r2] of circle
/// </summary>
public class CircleSquareResponse : BaseAuditableEntity
{
    /// <summary>
    /// Square of circle
    /// </summary>
    public double Square { get; set; }

    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }
   
}