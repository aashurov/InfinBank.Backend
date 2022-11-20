using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaDetails;

public class GetSquareAreaDetailsQuery : IRequest<SquareAreaDetailsVm>
{
    public int Id { get; set; }
}