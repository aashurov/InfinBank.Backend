namespace InfinBank.Domain.Entities.Circle;

public class CircleEntity : BaseAuditableEntity
{
    /// <summary>
    /// Square of circle
    /// </summary>
    public double Square { get; set; }

    /// <summary>
    /// Circumference of circle
    /// </summary>
    public double Circumference { get; set; }

    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; set; }
}