using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using InfinBank.Domain.Entities.Rectangle;

namespace InfinBank.Persistence.EntityTypeConfigurations;

public class RectangleEntityConfiguration : IEntityTypeConfiguration<RectangleEntity>
{
    public void Configure(EntityTypeBuilder<RectangleEntity> builder)
    {
        builder.HasKey(rectangleRequest => rectangleRequest.Id);
        builder.HasIndex(rectangleRequest => rectangleRequest.Id).IsUnique();
        builder.Property(rectangleRequest => rectangleRequest.Length).HasColumnType("double").IsRequired();
        builder.Property(rectangleRequest => rectangleRequest.Width).HasColumnType("double").IsRequired();
        builder.Property(rectangleRequest => rectangleRequest.Perimeter).HasColumnType("double");
        builder.Property(rectangleRequest => rectangleRequest.Square).HasColumnType("double");
    }
}
 