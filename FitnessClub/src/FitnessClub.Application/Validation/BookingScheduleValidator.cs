using FitnessClub.Application.Exceptions;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Validation;

public class BookingScheduleValidator(
    IRepository<Booking> bookingRepository)
{
    public async Task EnsureAvailableAsync(
        Booking candidate,
        int? excludingBookingId = null)
    {
        var allBookings = await bookingRepository.GetAllAsync();
        var end = candidate.DateTime + candidate.Duration;
        var overlappingBookings = allBookings
            .Where(existing =>
                existing.Id != excludingBookingId &&
                existing.DateTime < end &&
                candidate.DateTime < existing.DateTime + existing.Duration)
            .ToList();
        if (overlappingBookings.Any(b =>
                b.Hall.Id == candidate.Hall.Id))
        {
            throw new ConflictException(
                "Зал уже занят в выбранное время.");
        }
        if (overlappingBookings.Any(b =>
                b.Trainer.Id == candidate.Trainer.Id))
        {
            throw new ConflictException(
                "У тренера уже есть занятие в выбранное время.");
        }
        if (overlappingBookings.Any(b =>
                b.Client.Id == candidate.Client.Id))
        {
            throw new ConflictException(
                "У клиента уже есть занятие в выбранное время.");
        }
    }
}