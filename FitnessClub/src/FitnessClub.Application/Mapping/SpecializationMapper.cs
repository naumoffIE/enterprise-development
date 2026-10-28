using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Domain.Entities;

namespace FitnessClub.Application.Mapping;

public static class SpecializationMapper
{
    /// <summary>
    /// Преобразует специализацию в DTO
    /// </summary>
    public static SpecializationDto ToDto(this Specialization specialization) =>
        new(specialization.Id, specialization.Name);
    /// <summary>
    /// Создаёт специализацию из DTO
    /// </summary>
    public static Specialization ToEntity(this SpecializationEditDto specializationEditDto) =>
        new() { Name = specializationEditDto.Name };
}