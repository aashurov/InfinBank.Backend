using MediatR;

namespace InfinBank.Application.CQRS.Queries.Circles.GetlCircleCircumferenceDetails;

public class GetCircleCircumferenceDetailsQuery : IRequest<CircleCircumferenceDetailsVm>
{
    public int Id { get; set; }
}