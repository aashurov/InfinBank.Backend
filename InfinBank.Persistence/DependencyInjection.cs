using InfinBank.Application.Interfaces;
using InfinBank.Application.Interfaces.ICalculateServices;
using InfinBank.Domain.Entities.UserEntities;
using InfinBank.Persistence.Interceptors;
using InfinBank.Persistence.Services;
using InfinBank.Persistence.Services.CalculateServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfinBank.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<InfinBankDBContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IInfinBankDBContext>(
            provider => provider.GetService<InfinBankDBContext>());
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<ICalculateCircleService, CalculateCircleService>();
            services.AddTransient<ICalculateRectangleService, CalculateRectangleService>();
            services.AddTransient<ICalculateTriangleService, CalculateTriangleService>();
            services.AddTransient<ICalculateSquareService, CalculateSquareService>();
            services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<InfinBankDBContext>();
            services.AddScoped<RoleManager<Role>>();
            services.AddScoped<UserManager<User>>();
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminRole", policy =>
            //           policy.RequireRole("Administrator"));
            //});
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                      policy.RequireClaim("Administrator"));
            });
            return services;
        }
    }
}