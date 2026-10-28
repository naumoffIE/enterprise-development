using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Domain.Entities;

namespace FitnessClub.Application.Mapping;

public static class HallMapper
{
    public static HallDto ToDto(this Hall hall) => new(hall.Id, hall.Name);
    public static Hall ToEntity(this HallEditDto hallEditDto) =>
        new() { Name = hallEditDto.Name };
}