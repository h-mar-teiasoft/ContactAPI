using ContactAPI.Model;
using ContactAPI.Model.DTO;
using ContactAPI.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ContactAPI.Services
{
    public class GroupService : IGroupService
    {
        private readonly ExamDbContext _context;

        public GroupService(ExamDbContext context)
        {
            _context = context;
        }

        public async Task AddContactToGroup(int ContactId, int GroupId)
        {
            var contact = await _context.Contacts.FindAsync(ContactId);
            var group = await _context.Groups.FindAsync(GroupId);

            var link = new GroupsContact
            {
                ContactId = ContactId,
                GroupId = GroupId,
            };

            _context.Set<GroupsContact>().Add(link);
            await _context.SaveChangesAsync();

            
        }

        public async Task<GroupDTO> CreateGroup(GroupCreateDTO newGroup)
        {
            var grp = new Group
            {
                Name = newGroup.Name,
            };

            _context.Groups.Add(grp);
            await _context.SaveChangesAsync();

            return new GroupDTO
            {
                Name = grp.Name,
                Id = grp.Id
            };
        }

        public async Task<IEnumerable<GroupDTO>> GetAllGroups()
        {
            var result = await _context.Groups.ToListAsync();

            return result.Select(g => new GroupDTO
            {
                Name = g.Name,
                Id = g.Id
            });
        }

        public Task<GroupDTO> GetGroupContacts(int GroupId)
        {
            throw new NotImplementedException();
        }
    }
}
