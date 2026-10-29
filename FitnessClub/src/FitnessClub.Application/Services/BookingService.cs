using FitnessClub.Application.Mapping;
using FitnessClub.Application.Exceptions;
using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Interfaces;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services;

public class BookingService(
    IRepository<Booking> bookingRepository,
    IRepository<Client> clientRepository,
    IRepository<Trainer> trainerRepository,
    IRepository<Hall> hallRepository) : ICrudService<BookingDto, BookingEditDto>
{
    public async Task<IReadOnlyList<BookingDto>> GetAllAsync()
    {
        var bookings = await bookingRepository.GetAllAsync();
        return [.. bookings.Select(b => b.ToDto())];
    }
    public async Task<BookingDto?> GetByIdAsync(int id)
    {
        var booking = await bookingRepository.GetByIdAsync(id);
        return booking?.ToDto();
    }
    public async Task<BookingDto> AddAsync(BookingEditDto editDto)
    {
        var (client, trainer, hall) = await GetBookingReferencesAsync(editDto);

        var booking = await bookingRepository.AddAsync(editDto.ToEntity(client, trainer, hall));
        return booking.ToDto();
    }
    public async Task<BookingDto?> UpdateAsync(int id, BookingEditDto editDto)
    {
        var booking = await bookingRepository.GetByIdAsync(id);
        if (booking is null)
            return null;

        var (client, trainer, hall) = await GetBookingReferencesAsync(editDto);

        booking.UpdateEntity(editDto, client, trainer, hall);
        await bookingRepository.UpdateAsync(booking);
        return booking.ToDto();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await bookingRepository.DeleteAsync(id);
    }

    private async Task<(Client, Trainer, Hall)> GetBookingReferencesAsync(
        BookingEditDto editDto)
    {
        var client = await clientRepository.GetByIdAsync(editDto.ClientId)
            ?? throw new NotFoundException($"Клиент с ID {editDto.ClientId} не найден.");
        var trainer = await trainerRepository.GetByIdAsync(editDto.TrainerId)
            ?? throw new NotFoundException($"Тренер с ID {editDto.TrainerId} не найден.");
        var hall = await hallRepository.GetByIdAsync(editDto.HallId)
            ?? throw new NotFoundException($"Зал с ID {editDto.HallId} не найден.");
        return (client, trainer, hall);
    }
}