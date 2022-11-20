using InfinBank.Domain.Common;

namespace InfinBank.Domain.Entities.Circle;

/// <summary>
/// Request class for calculate circumference [l=2πr] and square [S=π×r2] of circle
/// </summary>
public class CircleRequest : BaseAuditableEntity
{
    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }
}