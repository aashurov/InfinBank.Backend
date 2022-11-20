using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTrianglePerimeterList;

public class TrianglePerimeterListVm
{
    public IList<TrianglePerimeterLookupDto> TrianglePerimetres { get; set; }
}
