namespace InfinBank.Domain.Entities.Rectangle;

public class RectangleEntity : BaseAuditableEntity
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
    /// Perimeter of rectangle
    /// </summary>
    public double Perimeter { get; set; }

    /// <summary>
    /// Square of rectangle
    /// </summary>
    public double Square { get; set; }
}