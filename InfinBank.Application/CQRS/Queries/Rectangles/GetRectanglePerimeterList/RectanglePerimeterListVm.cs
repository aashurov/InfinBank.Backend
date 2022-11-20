using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinBank.Application.CQRS.Queries.Rectangles.GetRectanglePerimeterList;

public class RectanglePerimeterListVm
{
    public IList<RectanglePerimeterLookupDto> RectanglePerimeteres { get; set; }
}
