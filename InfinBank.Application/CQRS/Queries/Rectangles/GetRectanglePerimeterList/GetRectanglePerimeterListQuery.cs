using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterList;

public class GetRectanglePerimeterListQuery : IRequest<RectanglePerimeterListVm>
{
}
