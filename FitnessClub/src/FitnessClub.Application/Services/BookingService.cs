using FitnessClub.Application.Mapping;
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
        var client = await clientRepository.GetByIdAsync(editDto.ClientId);
        var trainer = await trainerRepository.GetByIdAsync(editDto.TrainerId);
        var hall = await hallRepository.GetByIdAsync(editDto.HallId);

        if (client is null || trainer is null || hall is null)
            throw new ArgumentException("Client, Trainer or Hall not found.");

        var booking = await bookingRepository.AddAsync(editDto.ToEntity(client, trainer, hall));
        return booking.ToDto();
    }
    public async Task<BookingDto?> UpdateAsync(int id, BookingEditDto editDto)
    {
        var booking = await bookingRepository.GetByIdAsync(id);
        if (booking is null)
            return null;

        var client = await clientRepository.GetByIdAsync(editDto.ClientId);
        var trainer = await trainerRepository.GetByIdAsync(editDto.TrainerId);
        var hall = await hallRepository.GetByIdAsync(editDto.HallId);

        if (client is null || trainer is null || hall is null)
            throw new ArgumentException("Client, Trainer or Hall not found.");

        booking.UpdateEntity(editDto, client, trainer, hall);
        await bookingRepository.UpdateAsync(booking);
        return booking.ToDto();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await bookingRepository.DeleteAsync(id);
    }
}