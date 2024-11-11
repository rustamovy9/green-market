using System.Reflection;
using FluentValidation;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Validations;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.API.Extensions.DI;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    { 
        services.AddScoped(typeof(IGenericAddRepository<>), typeof(GenericAddRepository<>));
        services.AddScoped(typeof(IGenericUpdateRepository<>), typeof(GenericUpdateRepository<>));
        services.AddScoped(typeof(IGenericDeleteRepository<>), typeof(GenericDeleteRepository<>));
        services.AddScoped(typeof(IGenericFindRepository<>), typeof(GenericFindRepository<>));
        
        
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        
        services.AddMediatR(cfg =>
                 cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            x.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        return services;
    }
}