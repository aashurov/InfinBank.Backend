using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinBank.Application.CQRS.Commands.Squares.DeleteSquareArea;

public class DeleteSquareAreaCommand : IRequest
{
    public int Id { get; set; }
}

