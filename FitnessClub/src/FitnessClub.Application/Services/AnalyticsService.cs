using FitnessClub.Application.Exceptions;
using FitnessClub.Application.Mapping;
using FitnessClub.Contracts.Dtos.Analytics;
using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Interfaces;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services;

public class AnalyticsService(
    IRepository<Trainer> trainerRepository,
    IRepository<Client> clientRepository,
    IRepository<Booking> bookingRepository,
    IRepository<Hall> hallRepository) : IAnalyticsService
{
    public async Task<IReadOnlyList<TrainerDto>> GetExperiencedTrainersAsync(
        int minimumExperience = 5)
    {
        var trainers = await trainerRepository.GetAllAsync();
        return [.. trainers
            .Where(trainer => trainer.Experience >= minimumExperience)
            .Select(trainer => trainer.ToDto())];
    }

    public async Task<IReadOnlyList<ClientDto>> GetClientsWithOverdueSubscriptionsAsync(
        DateOnly asOfDate)
    {
        var clients = await clientRepository.GetAllAsync();
        return [.. clients
            .Where(client => client.SubscriptionEnd < asOfDate)
            .OrderBy(client => client.FullName)
            .Select(client => client.ToDto())];
    }

    public async Task<IReadOnlyList<PopularTrainerDto>> GetMostPopularTrainersAsync(
        int count = 5)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(count);

        var bookings = await bookingRepository.GetAllAsync();
        return [.. bookings
            .GroupBy(booking => booking.Trainer)
            .Select(group => new PopularTrainerDto(
                group.Key.Id,
                group.Key.FullName,
                group.Count()))
            .OrderByDescending(trainer => trainer.BookingCount)
            .Take(count)];
    }

    public async Task<bool> IsHallAvailableAsync(int hallId, DateTime dateTime)
    {
        await EnsureHallExistsAsync(hallId);

        var bookings = await bookingRepository.GetAllAsync();
        return !bookings.Any(booking =>
            booking.Hall.Id == hallId &&
            booking.DateTime <= dateTime &&
            dateTime < booking.DateTime + booking.Duration);
    }

    public async Task<IReadOnlyList<BookingDto>> GetBookingsInHallForMonthAsync(
        int hallId,
        DateOnly dateInMonth)
    {
        await EnsureHallExistsAsync(hallId);

        var bookings = await bookingRepository.GetAllAsync();
        return [.. bookings
            .Where(booking =>
                booking.Hall.Id == hallId &&
                booking.DateTime.Year == dateInMonth.Year &&
                booking.DateTime.Month == dateInMonth.Month)
            .Select(booking => booking.ToDto())];
    }

    private async Task EnsureHallExistsAsync(int hallId)
    {
        if (await hallRepository.GetByIdAsync(hallId) is null)
            throw new NotFoundException($"Зал с ID {hallId} не найден.");
    }
}
