using ContactAPI.Model;
using ContactAPI.Model.DTO;
using ContactAPI.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Services
{
    public class ContactService : IContactServices
    {
        private readonly ExamDbContext _context;

        public ContactService(ExamDbContext context)
        {
            _context = context;
        }

        public async Task<ContactDTO> CreateContact(ContactCreateDTO newContact)
        {
            var contact = new Contact
            {
                FirstName = newContact.FirstName,
                LastName = newContact.LastName,
                Email = newContact.Email,
                Phone = newContact.Phone,
            };
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return new ContactDTO
            {
                Id  = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone,
                CreatedAt = contact.CreatedAt
            } ;            
        }

        public async Task DeleteContact(int id)
        {
            var result = await _context.Contacts.FindAsync(id);

            if (result == null)
            {
                throw new KeyNotFoundException($"No Contact with Id {id} was found");
            }
            
            _context.Contacts.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactDTO>> GetAllContacts()
        {
            var result = await _context.Contacts.ToListAsync();
            return result.Select(c => new ContactDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                CreatedAt = c.CreatedAt,
                Phone = c.Phone,
                Email = c.Email
            });
        }
    }
}
