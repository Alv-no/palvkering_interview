using System.Runtime.CompilerServices;
using Alv.Parkering.Application.Interfaces;
using Alv.Parkering.Infrastructure.Context;
using Alv.Parkering.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Alv.Parkering.Host")]

namespace Alv.Parkering.Infrastructure;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
        return services
            .AddTransient<ParkeringContext>()
            .AddTransient<IParkingStore, ParkingSpotRepository>();
    }
}
