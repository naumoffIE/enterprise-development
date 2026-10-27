using FitnessClub.Domain.Entities;

namespace FitnessClub.Contracts.Dto;
/// <summary>
/// Данные клиента для ответа API
/// </summary>
/// <param name="Id">
/// Идентификатор клиента
/// </param>
/// <param name="PassportNumber">
/// Номер паспорта
/// </param>
/// <param name="FullName">
/// Полное имя
/// </param>
/// <param name="Gender">
/// Пол (my genda?... ima mechanic)
/// </param>
/// <param name="BirthDate">
/// Дата рождения
/// </param>
/// <param name="PhoneNumber">
/// Номер телефона
/// </param>
/// <param name="SubscriptionStart">
/// Начало абонемента
/// </param>
/// <param name="SubscriptionEnd">
/// Окончание абонемента
/// </param>
public record ClientDto
(
    int Id,
    string PassportNumber,
    string FullName,
    Gender Gender,
    DateOnly BirthDate,
    string? PhoneNumber,
    DateOnly SubscriptionStart,
    DateOnly SubscriptionEnd
);