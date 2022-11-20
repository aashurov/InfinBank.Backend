using InfinBank.Application.Interfaces.ICalculateServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinBank.Persistence.Services.CalculateServices;

public class CalculateTriangleService: ICalculateTriangleService
{
    /// Request class for calculate the area [S=sqrt(p*(p-a)*(p-b)*(p-c))] and the perimeter [P=a+b+c] of a triangle
    private double squareArea { get; set; }

    private double squarePerimeter { get; set; }

    public double CalculateSquare(double a, double b, double c)
    {
        squarePerimeter = CalculatePerimeter(a, b, c);
        squareArea = Math.Sqrt(squarePerimeter * (squarePerimeter - a) * (squarePerimeter - b) * (squarePerimeter - c));
        return squareArea;
    }

    public double CalculatePerimeter(double a, double b, double c)
    {
        squarePerimeter = (a + b + c);
        return squarePerimeter;
    }
}
