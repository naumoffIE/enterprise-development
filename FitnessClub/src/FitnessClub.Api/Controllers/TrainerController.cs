using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Api.Controllers;

/// <summary>
/// Управление залами
/// </summary>
[ApiController]
[Route("api/trainers")]
public class TrainersController(ICrudService<TrainerDto, TrainerEditDto> service) : ControllerBase
{
    /// <summary>
    /// Получить всех тренеров
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TrainerDto>>> GetAll() =>
        Ok(await service.GetAllAsync());
    /// <summary>
    /// Получить тренера по Id
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TrainerDto>> GetById(int id)
    {
        var trainer = await service.GetByIdAsync(id);
        return trainer is null ? NotFound() : Ok(trainer);
    }
    /// <summary>
    /// Создать тренера
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TrainerDto>> Create(TrainerEditDto dto)
    {
        var created = await service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    /// <summary>
    /// Изменить тренера
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<TrainerDto>> Update(int id, TrainerEditDto dto)
    {
        var updated = await service.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }
    /// <summary>
    /// Удалить тренера
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}