using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
        Task DeleteContactAsync(string id);
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
    }
}
