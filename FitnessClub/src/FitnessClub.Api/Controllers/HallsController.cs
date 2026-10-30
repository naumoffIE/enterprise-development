using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Api.Controllers;

/// <summary>
/// Управление залами
/// </summary>
[ApiController]
[Route("api/halls")]
public class HallsController(ICrudService<HallDto, HallEditDto> service) : ControllerBase
{
    /// <summary>
    /// Получить все залы
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<HallDto>>> GetAll() =>
        Ok(await service.GetAllAsync());
    /// <summary>
    /// Получить зал по Id
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<HallDto>> GetById(int id)
    {
        var hall = await service.GetByIdAsync(id);
        return hall is null ? NotFound() : Ok(hall);
    }
    /// <summary>
    /// Создать зал
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<HallDto>> Create(HallEditDto dto)
    {
        var created = await service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    /// <summary>
    /// Изменить зал
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<HallDto>> Update(int id, HallEditDto dto)
    {
        var updated = await service.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }
    /// <summary>
    /// Удалить зал
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}