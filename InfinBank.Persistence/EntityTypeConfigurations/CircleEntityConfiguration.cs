using InfinBank.Domain.Entities.Circle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfinBank.Persistence.EntityTypeConfigurations;

public class CircleEntityConfiguration : IEntityTypeConfiguration<CircleEntity>
{
    public void Configure(EntityTypeBuilder<CircleEntity> builder)
    {
        builder.HasKey(rectangleRequest => rectangleRequest.Id);
        builder.HasIndex(rectangleRequest => rectangleRequest.Id).IsUnique();
        builder.Property(rectangleRequest => rectangleRequest.Radius).HasColumnType("double").IsRequired();
        builder.Property(rectangleRequest => rectangleRequest.Square).HasColumnType("double");
        builder.Property(rectangleRequest => rectangleRequest.Circumference).HasColumnType("double");
    }
}