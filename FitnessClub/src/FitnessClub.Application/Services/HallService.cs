using FitnessClub.Domain.Interfaces;
using FitnessClub.Domain.Entities;
using FitnessClub.Contracts.Interfaces;
using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Application.Mapping;
using FitnessClub.Application.Exceptions;

namespace FitnessClub.Application.Services;

public class HallService(
    IRepository<Hall> hallRepository, 
    IRepository<Booking> bookingsRepository) : ICrudService<HallDto, HallEditDto>
{
    public async Task<IReadOnlyList<HallDto>> GetAllAsync()
    {
        var halls = await hallRepository.GetAllAsync();
        return [.. halls.Select(h => h.ToDto())];
    }
    public async Task<HallDto?> GetByIdAsync(int id)
    {
        var hall = await hallRepository.GetByIdAsync(id);
        return hall?.ToDto();
    }
    public async Task<HallDto> AddAsync(HallEditDto editDto)
    {
        var hall = await hallRepository.AddAsync(editDto.ToEntity());
        return hall.ToDto();
    }
    public async Task<HallDto?> UpdateAsync(int id, HallEditDto editDto)
    {
        var hall = await hallRepository.GetByIdAsync(id);
        if (hall is null)
            return null;
        hall.Name = editDto.Name;
        await hallRepository.UpdateAsync(hall);
        return hall.ToDto();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var allBookings = await bookingsRepository.GetAllAsync();
        if (allBookings.Any(b => b.Hall.Id == id))
            throw new ConflictException("Невозможно удалить зал, так как существуют бронирования для него.");
        return await hallRepository.DeleteAsync(id);
    }
}
