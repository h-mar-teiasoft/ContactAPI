using ContactAPI.Model;
using ContactAPI.Model.DTO;
using System.Security.Policy;

namespace ContactAPI.Services.interfaces
{
    public interface IContactServices
    {
        public Task<IEnumerable<ContactDTO>> GetAllContacts();
        public Task<ContactDTO> CreateContact(ContactCreateDTO newContact);
        public Task DeleteContact(int id);
    }
}
