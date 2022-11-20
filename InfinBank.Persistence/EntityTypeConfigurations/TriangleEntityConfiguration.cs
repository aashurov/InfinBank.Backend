using InfinBank.Domain.Entities.Triangle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfinBank.Persistence.EntityTypeConfigurations;

public class TriangleEntityConfiguration : IEntityTypeConfiguration<TriangleEntity>
{
    public void Configure(EntityTypeBuilder<TriangleEntity> builder)
    {
        builder.HasKey(rectangleRequest => rectangleRequest.Id);
        builder.HasIndex(rectangleRequest => rectangleRequest.Id).IsUnique();
        builder.Property(rectangleRequest => rectangleRequest.ASide).HasColumnType("double").IsRequired();
        builder.Property(rectangleRequest => rectangleRequest.BSide).HasColumnType("double").IsRequired();
        builder.Property(rectangleRequest => rectangleRequest.CSide).HasColumnType("double").IsRequired();
        builder.Property(rectangleRequest => rectangleRequest.Perimeter).HasColumnType("double");
        builder.Property(rectangleRequest => rectangleRequest.Square).HasColumnType("double");
    }
}