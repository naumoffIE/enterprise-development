using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Domain.Entities;

namespace FitnessClub.Application.Mapping;

public static class BookingMapper
{
    /// <summary>
    /// Преобразует запись в DTO
    /// </summary>
    public static BookingDto ToDto(this Booking booking) =>
        new
        (
            booking.Id,
            booking.Client.Id,
            booking.Trainer.Id,
            booking.Hall.Id,
            booking.DateTime,
            booking.IsTrial,
            booking.Duration
        );
    /// <summary>
    /// Создаёт запись из DTO и связанных сущностей
    /// </summary>
    public static Booking ToEntity(this BookingEditDto bookingEditDto, Client client, Trainer trainer, Hall hall) =>
        new()
        {
            Client = client,
            Trainer = trainer,
            Hall = hall,
            DateTime = bookingEditDto.DateTime,
            IsTrial = bookingEditDto.IsTrial,
            Duration = bookingEditDto.Duration
        };
    /// <summary>
    /// Обновляет запись данными из DTO и связанными сущностями
    /// </summary>
    public static void UpdateEntity(this Booking booking, BookingEditDto bookingEditDto, Client client, Trainer trainer, Hall hall)
    {
        booking.Client = client;
        booking.Trainer = trainer;
        booking.Hall = hall;
        booking.DateTime = bookingEditDto.DateTime;
        booking.IsTrial = bookingEditDto.IsTrial;
        booking.Duration = bookingEditDto.Duration;
    }
}