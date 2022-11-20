using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaList;

public class TriangleAreaListVm
{
    public IList<TriangleAreaLookupDto> TriangleAreas { get; set; }
}
