using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Domain.Entities;

namespace FitnessClub.Application.Mapping;

public static class ClientMapper
{
    public static ClientDto ToDto(this Client client) =>
        new
        (
            client.Id,
            client.FullName,
            client.PassportNumber,
            client.Gender,
            client.BirthDate,
            client.PhoneNumber,
            client.SubscriptionStart,
            client.SubscriptionEnd
        );
    public static Client ToEntity(this ClientEditDto clientEditDto) =>
        new()
        {
            FullName = clientEditDto.FullName,
            PassportNumber = clientEditDto.PassportNumber,
            Gender = clientEditDto.Gender,
            BirthDate = clientEditDto.BirthDate,
            PhoneNumber = clientEditDto.PhoneNumber,
            SubscriptionStart = clientEditDto.SubscriptionStart,
            SubscriptionEnd = clientEditDto.SubscriptionEnd
        };
    public static void UpdateEntity(this Client client, ClientEditDto clientEditDto)
    {
        client.FullName = clientEditDto.FullName;
        client.PassportNumber = clientEditDto.PassportNumber;
        client.Gender = clientEditDto.Gender;
        client.BirthDate = clientEditDto.BirthDate;
        client.PhoneNumber = clientEditDto.PhoneNumber;
        client.SubscriptionStart = clientEditDto.SubscriptionStart;
        client.SubscriptionEnd = clientEditDto.SubscriptionEnd; 
    }
}