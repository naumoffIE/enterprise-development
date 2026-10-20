using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace FitnessClub.Domain.Seeds;
public static class SeedingExtensions
{
    /// <summary>
    /// Кладёт начальные данные в репозитории
    /// </summary>
    public static void Seed(this IServiceProvider services, SeedData data)
    {
        var specializations = services.GetRequiredService<IRepository<Specialization>>();
        var halls = services.GetRequiredService<IRepository<Hall>();
        var clients = services.GetRequiredService<IRepository<Client>();
        var trainers = services.GetRequiredService<IRepository<Trainer>();
        var bookings = services.GetRequiredService<IRepository<Booking>();

        foreach (var s in data.Specializations) specializations.Add(s);
        foreach (var h in data.Halls) halls.AddAsync(h);
        foreach (var c in data.Clients) clients.Add(c);
        foreach (var t in data.Trainers) trainers.Add(t);
        foreach (var b in data.Bookings) bookings.Add(b);
    }
}