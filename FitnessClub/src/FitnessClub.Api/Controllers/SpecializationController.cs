using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Api.Controllers;

/// <summary>
/// Управление залами
/// </summary>
[ApiController]
[Route("api/specializations")]
public class SpecializationsController(ICrudService<SpecializationDto, SpecializationEditDto> service) : ControllerBase
{
    /// <summary>
    /// Получить все специализации
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SpecializationDto>>> GetAll() =>
        Ok(await service.GetAllAsync());
    /// <summary>
    /// Получить специализацию по Id
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SpecializationDto>> GetById(int id)
    {
        var specialization = await service.GetByIdAsync(id);
        return specialization is null ? NotFound() : Ok(specialization);
    }
    /// <summary>
    /// Создать специализацию
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<SpecializationDto>> Create(SpecializationEditDto dto)
    {
        var created = await service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    /// <summary>
    /// Изменить специализацию
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<SpecializationDto>> Update(int id, SpecializationEditDto dto)
    {
        var updated = await service.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }
    /// <summary>
    /// Удалить специализацию
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}