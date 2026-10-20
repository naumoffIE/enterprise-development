using System.ComponentModel.DataAnnotations;

namespace FitnessClub.Contracts.Dto;
public class TrainerEditDto
{
    [Required, MaxLength(200)] public required string Fullname { get; set; }
    [Range(0, 60)] public int Experience { get; set; }
    public int SpecializationId { get; set; }
    // подумать че мне вообще здесь надо (спросить Данилу)
}