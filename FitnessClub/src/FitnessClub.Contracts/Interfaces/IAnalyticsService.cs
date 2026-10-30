using FitnessClub.Contracts.Dtos.Analytics;
using FitnessClub.Contracts.Dtos.Read;

namespace FitnessClub.Contracts.Interfaces;

public interface IAnalyticsService
{
    public Task<IReadOnlyList<TrainerDto>> GetExperiencedTrainersAsync(
        int minimumExperience = 5);
    public Task<IReadOnlyList<ClientDto>> GetClientsWithOverdueSubscriptionsAsync(
        DateOnly asOfDate);
    public Task<IReadOnlyList<PopularTrainerDto>> GetMostPopularTrainersAsync(
        int count = 5);
    public Task<bool> IsHallAvailableAsync(int hallId, DateTime dateTime);
    public Task<IReadOnlyList<BookingDto>> GetBookingsInHallForMonthAsync(
        int hallId,
        DateOnly dateInMonth);
}