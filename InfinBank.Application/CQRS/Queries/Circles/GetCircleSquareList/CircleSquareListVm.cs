using InfinBank.Application.CQRS.Queries.Circles.GetCircleCircumferenceList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinBank.Application.CQRS.Queries.Circles.GetCircleSquareList;

public class CircleSquareListVm
{
    public IList<CircleSquareLookupDto> CircleSquares { get; set; }
}
