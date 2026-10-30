using FitnessClub.Application.Exceptions;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Validation;

public class PassportNumberUniquenessValidator(
    IRepository<Client> clientRepository,
    IRepository<Trainer> trainerRepository)
{
    public async Task EnsureUniqueAsync(string passportNumber, Person? personBeingUpdated = null)
    {
        var clients = await clientRepository.GetAllAsync();
        if (clients.Any(client =>
                client.PassportNumber == passportNumber &&
                (personBeingUpdated is not Client currentClient || client.Id != currentClient.Id)))
        {
            throw new ConflictException(
                $"Человек с паспортным номером {passportNumber} уже существует.");
        }
        var trainers = await trainerRepository.GetAllAsync();
        if (trainers.Any(trainer =>
                trainer.PassportNumber == passportNumber &&
                (personBeingUpdated is not Trainer currentTrainer || trainer.Id != currentTrainer.Id)))
        {
            throw new ConflictException(
                $"Человек с паспортным номером {passportNumber} уже существует.");
        }
    }
}
