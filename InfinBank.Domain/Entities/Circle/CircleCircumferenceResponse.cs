using InfinBank.Domain.Common;

namespace InfinBank.Domain.Entities.Circle;

/// <summary>
/// Response class for calculate the circumference [l=2πr] and the area [S=π×r2] of circle
/// </summary>
public class CircleCircumferenceResponse : BaseAuditableEntity
{
    /// <summary>
    /// Circumference of circle
    /// </summary>
    public double Circumference { get; set; }

    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }
   
}