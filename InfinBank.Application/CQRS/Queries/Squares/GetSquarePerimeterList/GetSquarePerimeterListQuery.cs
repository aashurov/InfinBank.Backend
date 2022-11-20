using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterList;

public class GetSquarePerimeterListQuery : IRequest<SquarePerimeterListVm>
{
}

