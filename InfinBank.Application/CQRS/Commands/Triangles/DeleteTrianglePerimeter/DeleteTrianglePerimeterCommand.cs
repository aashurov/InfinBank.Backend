using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Triangles.DeleteTrianglePerimeter;

public class DeleteTrianglePerimeterCommand : IRequest
{
    public int Id { get; set; }
}
