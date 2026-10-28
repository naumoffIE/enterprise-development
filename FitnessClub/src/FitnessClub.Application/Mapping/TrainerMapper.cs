using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Domain.Entities;

namespace FitnessClub.Application.Mapping;

public static class TrainerMapper
{
    public static TrainerDto ToDto(this Trainer trainer) =>
        new
        (
            trainer.Id,
            trainer.FullName,
            trainer.PassportNumber,
            trainer.Gender,
            trainer.BirthDate,
            trainer.PhoneNumber,
            trainer.Specialization.Name,
            trainer.Experience
        );
    public static Trainer ToEntity(this TrainerEditDto trainerEditDto, Specialization specialization) =>
        new()
        {
            FullName = trainerEditDto.FullName,
            PassportNumber = trainerEditDto.PassportNumber,
            Gender = trainerEditDto.Gender,
            BirthDate = trainerEditDto.BirthDate,
            PhoneNumber = trainerEditDto.PhoneNumber,
            Specialization = specialization,
            Experience = trainerEditDto.Experience
        };
    public static void UpdateEntity(this Trainer trainer, TrainerEditDto trainerEditDto, Specialization specialization)
    {
        trainer.FullName = trainerEditDto.FullName;
        trainer.PassportNumber = trainerEditDto.PassportNumber;
        trainer.Gender = trainerEditDto.Gender;
        trainer.BirthDate = trainerEditDto.BirthDate;
        trainer.PhoneNumber = trainerEditDto.PhoneNumber;
        trainer.Specialization = specialization;
        trainer.Experience = trainerEditDto.Experience;
    }
}