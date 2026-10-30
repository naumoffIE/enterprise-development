using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Api.Controllers;

/// <summary>
/// Управление залами
/// </summary>
[ApiController]
[Route("api/clients")]
public class ClientsController(ICrudService<ClientDto, ClientEditDto> service) : ControllerBase
{
    /// <summary>
    /// Получить все клиенты
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClientDto>>> GetAll() =>
        Ok(await service.GetAllAsync());
    /// <summary>
    /// Получить клиента по Id
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClientDto>> GetById(int id)
    {
        var client = await service.GetByIdAsync(id);
        return client is null ? NotFound() : Ok(client);
    }
    /// <summary>
    /// Создать клиента
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ClientDto>> Create(ClientEditDto dto)
    {
        var created = await service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    /// <summary>
    /// Изменить клиента
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<ClientDto>> Update(int id, ClientEditDto dto)
    {
        var updated = await service.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }
    /// <summary>
    /// Удалить клиента
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}