namespace FitnessClub.Contracts.Dto;
/// <summary>
/// Данные специализации для ответа API
/// </summary>
/// <param name="Id">
/// Идентификатор специализации
/// </param>
/// <param name="Name">
/// Название специализации
/// </param>
public record SpecializationDto
(
    int Id,
    string Name
);