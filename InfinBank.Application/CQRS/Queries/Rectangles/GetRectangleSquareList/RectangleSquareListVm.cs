using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectangleSquareList;

public class RectangleSquareListVm
{
    public IList<RectangleSquareLookupDto> RectangleSquares { get; set; }
}
