namespace FitnessClub.Contracts.Dto;
/// <summary>
/// Данные зала для ответа API
/// </summary>
/// <param name="Id">
/// Идентификатор зала
/// </param>
/// <param name="Name">
/// Название зала
/// </param>
public record HallDto
(
    int Id,
    string Name
);