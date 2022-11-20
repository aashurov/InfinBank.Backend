using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InfinBank.Application.CQRS.Queries.Squares.GetSquareAreaList;

public class SquareAreaListVm
{
    public IList<SquareAreaLookupDto> SquareAreas { get; set; }
}
