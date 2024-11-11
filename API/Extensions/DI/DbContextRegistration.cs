using GreenMarket.Data;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.API.Extensions.DI;

public static class DbContextRegistration
{
    public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BaseDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .LogTo(Console.WriteLine));
        
        builder.Services.AddDbContext<AppCommandDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .LogTo(Console.WriteLine));

        builder.Services.AddDbContext<AppQueryDbContext>(x =>
        {
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(Console.WriteLine);
        });

        return builder;
    }
}