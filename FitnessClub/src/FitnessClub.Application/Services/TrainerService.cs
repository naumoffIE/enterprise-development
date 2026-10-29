using FitnessClub.Application.Exceptions;
using FitnessClub.Application.Mapping;
using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Interfaces;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services;

public class TrainerService(
    IRepository<Trainer> trainerRepository,
    IRepository<Booking> bookingRepository,
    IRepository<Specialization> specializationRepository) : ICrudService<TrainerDto, TrainerEditDto>
{
    public async Task<IReadOnlyList<TrainerDto>> GetAllAsync()
    {
        var trainers = await trainerRepository.GetAllAsync();
        return [.. trainers.Select(t => t.ToDto())];
    }
    public async Task<TrainerDto?> GetByIdAsync(int id)
    {
        var trainer = await trainerRepository.GetByIdAsync(id);
        return trainer?.ToDto();
    }
    public async Task<TrainerDto> AddAsync(TrainerEditDto editDto)
    {
        var specialization = await specializationRepository.GetByIdAsync(editDto.SpecializationId) ?? throw new ArgumentException("Специализация не найдена.");
        var trainer = await trainerRepository.AddAsync(editDto.ToEntity(specialization));
        return trainer.ToDto();
    }
    public async Task<TrainerDto?> UpdateAsync(int id, TrainerEditDto editDto)
    {
        var trainer = await trainerRepository.GetByIdAsync(id);
        if (trainer is null)
            return null;
        var specialization = await specializationRepository.GetByIdAsync(editDto.SpecializationId) ?? throw new ArgumentException("Специализация не найдена.");
        trainer.UpdateEntity(editDto, specialization);
        await trainerRepository.UpdateAsync(trainer);
        return trainer.ToDto();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var allBookings = await bookingRepository.GetAllAsync();
        if (allBookings.Any(b => b.Trainer.Id == id))
            throw new ConflictException("Невозможно удалить тренера, так как существуют бронирования для него.");
        return await trainerRepository.DeleteAsync(id);
    }
}