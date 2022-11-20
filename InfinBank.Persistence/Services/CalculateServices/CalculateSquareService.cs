using InfinBank.Application.Interfaces.ICalculateServices;

namespace InfinBank.Persistence.Services.CalculateServices;

public class CalculateSquareService : ICalculateSquareService
{
    // Calculate the area [S=a*a] and the perimeter [P=4*a ] of a square
    private double squareArea { get; set; }

    private double squarePerimeter { get; set; }

    public double CalculateSquare(double a)
    {
        squareArea = a * a;
        return squareArea;
    }

    public double CalculatePerimeter(double a)
    {
        squarePerimeter = (4 * a);
        return squarePerimeter;
    }
}