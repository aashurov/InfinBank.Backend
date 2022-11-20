using InfinBank.Application.Interfaces;
using InfinBank.Domain.Entities.Circle;
using InfinBank.Domain.Entities.Rectangle;
using InfinBank.Domain.Entities.Square;
using InfinBank.Domain.Entities.Triangle;
using InfinBank.Domain.Entities.UserEntities;
using InfinBank.Persistence.Common;
using InfinBank.Persistence.EntityTypeConfigurations;
using InfinBank.Persistence.Interceptors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfinBank.Persistence;

public class InfinBankDBContext : IdentityDbContext<User, Role, string,
    IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>, IInfinBankDBContext
{
    public DbSet<CircleEntity> CircleEntity { get; set; }
    public DbSet<TriangleEntity> TriangleEntity { get; set; }
    public DbSet<SquareEntity> SquareEntity { get; set; }
    public DbSet<RectangleEntity> RectangleEntity { get; set; }
    public DbSet<RefreshToken> RefreshToken { get; set; }

    private readonly IDateTimeService _dateTimeService;

    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    private readonly IMediator _mediator;

    public InfinBankDBContext(DbContextOptions<InfinBankDBContext> options, IDateTimeService dateTimeService, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor, IMediator mediator) : base(options)
    {
        _dateTimeService = dateTimeService;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        _mediator = mediator;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new RectangleEntityConfiguration());
        builder.ApplyConfiguration(new CircleEntityConfiguration());
        builder.ApplyConfiguration(new TriangleEntityConfiguration());
        builder.ApplyConfiguration(new SquareEntityConfiguration());

        builder.Entity<Role>().HasData(
            new Role { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
            new Role { Id = "68373a2b-932e-4fff-a7a9-b31e156d4101", Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString("D") });

        var hasher = new PasswordHasher<User>();
        var password = hasher.HashPassword(null, "Qwertyruru20@@");
        builder.Entity<User>().HasData(

        new User() { Id = "30a8f9cc-8d37-4d93-ab2f-774428387e4a", UserName = "administrator", NormalizedUserName = "ADMINISTRATOR", Email = "admin@gmail.com", NormalizedEmail = "ADMIN@GMAIL.COM", FirstName = "AdministratorFirstName", LastName = "AdministratorLastName", Address = "Address1", PhoneNumber = "998970000675", PasswordHash = password, DateCreated = _dateTimeService.Now },
        new User() { Id = "cadaa51d-ddb3-4564-a8c5-79e80c98a032", UserName = "user", NormalizedUserName = "USER", Email = "user@gmail.com", NormalizedEmail = "USER@GMAIL.COM", FirstName = "UserFirstName", LastName = "UserLastName", Address = "Address2", PhoneNumber = "998970000676", PasswordHash = password, DateCreated = _dateTimeService.Now });

        builder.Entity<UserRole>().HasData(
         new UserRole { RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210", UserId = "30a8f9cc-8d37-4d93-ab2f-774428387e4a" },
         new UserRole { RoleId = "68373a2b-932e-4fff-a7a9-b31e156d4101", UserId = "cadaa51d-ddb3-4564-a8c5-79e80c98a032" });

        
    }
}