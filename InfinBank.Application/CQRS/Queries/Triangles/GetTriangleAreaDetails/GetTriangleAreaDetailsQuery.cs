using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InfinBank.Application.CQRS.Queries.Triangles.GetTriangleAreaDetails;

public class GetTriangleAreaDetailsQuery : IRequest<TriangleAreaDetailsVm>
{
    public int Id { get; set; }
}