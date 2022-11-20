using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InfinBank.Application.CQRS.Queries.Squares.GetSquarePerimeterList;

public class SquarePerimeterListVm
{
    public IList<SquarePerimeterLookupDto> SquarePerimetres { get; set; }
}
