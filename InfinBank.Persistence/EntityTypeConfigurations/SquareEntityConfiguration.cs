using InfinBank.Domain.Entities.Circle;
using InfinBank.Domain.Entities.Square;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfinBank.Persistence.EntityTypeConfigurations;

public class SquareEntityConfiguration : IEntityTypeConfiguration<SquareEntity>
{
    public void Configure(EntityTypeBuilder<SquareEntity> builder)
    {
        builder.HasKey(rectangleRequest => rectangleRequest.Id);
        builder.HasIndex(rectangleRequest => rectangleRequest.Id).IsUnique();
        builder.Property(rectangleRequest => rectangleRequest.Side).HasColumnType("double").IsRequired();
        builder.Property(rectangleRequest => rectangleRequest.Perimeter).HasColumnType("double");
        builder.Property(rectangleRequest => rectangleRequest.Area).HasColumnType("double");
    }
}
 