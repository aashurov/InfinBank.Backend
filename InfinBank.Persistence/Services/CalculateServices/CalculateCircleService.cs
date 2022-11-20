using InfinBank.Application.Interfaces.ICalculateServices;

namespace InfinBank.Persistence.Services.CalculateServices;

public class CalculateCircleService : ICalculateCircleService

{
    private double circleSquare { get; set; }
    private double circleCircumference { get; set; }

    public double CalculateSquare(double r)
    {
        circleSquare = 3.14 * r * 2;
        return circleSquare;
    }

    public double CalculateCircumference(double r)
    {
        circleCircumference = 2 * 3.14 * r;
        return circleCircumference;
    }
}