using IdentityServer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityServer
{
    internal static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Local");
            var migrationsAssembly = typeof(Config).Assembly.GetName().Name;

            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<AccountsDbContext>(
                options => 
                    options.UseSqlServer(connectionString, o => o.MigrationsAssembly(migrationsAssembly))
            );
            builder.Services
                .AddIdentity<IdentityUser, IdentityRole>(
                    options =>
                    {
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 6;
                        options.User.RequireUniqueEmail = true;
                    }
                )
                .AddEntityFrameworkStores<AccountsDbContext>();
            builder.Services
                .AddIdentityServer(
                    options =>
                    {
                        options.Events.RaiseErrorEvents = true;
                        options.Events.RaiseInformationEvents = true;
                        options.Events.RaiseFailureEvents = true;
                        options.Events.RaiseSuccessEvents = true;

                        options.EmitStaticAudienceClaim = true;
                    }
                )
                .AddConfigurationStore(
                    options => options.ConfigureDbContext = b => b.UseSqlServer(
                        connectionString,
                        o => o.MigrationsAssembly(migrationsAssembly)
                    )
                )
                .AddOperationalStore(
                    options => options.ConfigureDbContext = b => b.UseSqlServer(
                        connectionString,
                        o => o.MigrationsAssembly(migrationsAssembly)
                    )
                )
                .AddAspNetIdentity<IdentityUser>();
            
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages().RequireAuthorization();

            return app;
        }
    }
}
