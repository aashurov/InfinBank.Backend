using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InfinBank.Application.CQRS.Commands.Triangles.DeleteTriangleArea;

public class DeleteTriangleAreaCommand : IRequest
{
    public int Id { get; set; }
}
