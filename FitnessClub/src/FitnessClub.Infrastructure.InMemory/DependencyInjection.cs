using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;
using FitnessClub.Infrastructure.InMemory.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.Infrastructure.InMemory;

public static class DependencyInjection
{
    public static IServiceCollection AddInMemoryStorage(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IRepository<>), typeof(InMemoryRepository<>));
        return services;
    }
}