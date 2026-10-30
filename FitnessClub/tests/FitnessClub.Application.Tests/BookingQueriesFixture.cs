using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;
using FitnessClub.Domain.Seeds;
using FitnessClub.Infrastructure.InMemory;
using FitnessClub.Infrastructure.InMemory.Seeding;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.Application.Tests;

public sealed class BookingQueriesFixture : IAsyncLifetime
{
    private ServiceProvider? _serviceProvider;

    public IReadOnlyList<Client> Clients { get; private set; } = [];
    public IReadOnlyList<Trainer> Trainers { get; private set; } = [];
    public IReadOnlyList<Hall> Halls { get; private set; } = [];
    public IReadOnlyList<Booking> Bookings { get; private set; } = [];

    public async ValueTask InitializeAsync()
    {
        var services = new ServiceCollection();
        services.AddInMemoryStorage();
        _serviceProvider = services.BuildServiceProvider();

        await using var scope = _serviceProvider.CreateAsyncScope();
        var scopedServices = scope.ServiceProvider;
        var seeder = scopedServices.GetRequiredService<DataSeeder>();
        await seeder.DataSeedingAsync(new SeedData());

        Clients = await scopedServices.GetRequiredService<IRepository<Client>>().GetAllAsync();
        Trainers = await scopedServices.GetRequiredService<IRepository<Trainer>>().GetAllAsync();
        Halls = await scopedServices.GetRequiredService<IRepository<Hall>>().GetAllAsync();
        Bookings = await scopedServices.GetRequiredService<IRepository<Booking>>().GetAllAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (_serviceProvider is not null)
            await _serviceProvider.DisposeAsync();
    }
}