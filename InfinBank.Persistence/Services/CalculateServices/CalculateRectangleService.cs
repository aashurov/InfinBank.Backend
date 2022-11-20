using InfinBank.Application.Interfaces.ICalculateServices;
using System.Reflection.Metadata;

namespace InfinBank.Persistence.Services.CalculateServices;

public class CalculateRectangleService : ICalculateRectangleService
{
    //Calculating the perimeter[P = (a + b) * 2] and the area[S = a * b] of rectangle
    private double rectangleSquare { get; set; }
    private double rectanglePerimeter { get; set; }

    public double CalculateSquare(double a, double b)
    {
        rectangleSquare = a * b;
        return rectangleSquare;
    }

    public double CalculatePerimeter(double a, double b)
    {
        rectanglePerimeter = (a+b)*2;
        return rectanglePerimeter;
    }
}