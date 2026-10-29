using FitnessClub.Application.Exceptions;
using FitnessClub.Application.Mapping;
using FitnessClub.Contracts.Dtos.Edit;
using FitnessClub.Contracts.Dtos.Read;
using FitnessClub.Contracts.Interfaces;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Application.Services;

public class ClientService(
    IRepository<Client> clientRepository,
    IRepository<Booking> bookingRepository) : ICrudService<ClientDto, ClientEditDto>
{
    public async Task<IReadOnlyList<ClientDto>> GetAllAsync()
    {
        var clients = await clientRepository.GetAllAsync();
        return [.. clients.Select(c => c.ToDto())];
    }
    public async Task<ClientDto?> GetByIdAsync(int id)
    {
        var client = await clientRepository.GetByIdAsync(id);
        return client?.ToDto();
    }
    public async Task<ClientDto> AddAsync(ClientEditDto editDto)
    {
        var client = await clientRepository.AddAsync(editDto.ToEntity());
        return client.ToDto();
    }
    public async Task<ClientDto?> UpdateAsync(int id, ClientEditDto editDto)
    {
        var client = await clientRepository.GetByIdAsync(id);
        if (client is null)
            return null;
        client.UpdateEntity(editDto);
        await clientRepository.UpdateAsync(client);
        return client.ToDto();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var allBookings = await bookingRepository.GetAllAsync();
        if (allBookings.Any(b => b.Client.Id == id))
            throw new ConflictException("Невозможно удалить клиента, так как существуют бронирования для него.");
        return await clientRepository.DeleteAsync(id);
    }
}
