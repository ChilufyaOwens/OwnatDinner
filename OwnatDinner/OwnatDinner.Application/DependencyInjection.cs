using Microsoft.Extensions.DependencyInjection;
using OwnatDinner.Application.Services.Authentication;

namespace OwnatDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;    
    }
}
