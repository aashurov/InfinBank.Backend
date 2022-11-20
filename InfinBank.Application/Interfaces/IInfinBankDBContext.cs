using InfinBank.Domain.Entities.Circle;
using InfinBank.Domain.Entities.Rectangle;
using InfinBank.Domain.Entities.Square;
using InfinBank.Domain.Entities.Triangle;
using InfinBank.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Application.Interfaces;

public interface IInfinBankDBContext
{
    DbSet<TriangleEntity> TriangleEntity { get; set; }
    DbSet<CircleEntity> CircleEntity { get; set; }
    DbSet<SquareEntity> SquareEntity { get; set; }
    DbSet<RectangleEntity> RectangleEntity { get; set; }

    DbSet<RefreshToken> RefreshToken { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}