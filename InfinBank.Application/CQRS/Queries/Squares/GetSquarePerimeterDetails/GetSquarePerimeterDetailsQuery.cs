using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterDetails;

public class GetSquarePerimeterDetailsQuery : IRequest<SquarePerimeterDetailsVm>
{
    public int Id { get; set; }
}