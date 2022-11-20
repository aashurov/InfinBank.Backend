using MediatR;

namespace InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareDetails;

public class GetCircleSquareDetailsQuery : IRequest<CircleSquareDetailsVm>
{
    public int Id { get; set; }
}