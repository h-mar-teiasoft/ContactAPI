using ContactAPI.Model.DTO;

namespace ContactAPI.Services.interfaces
{
    public interface IGroupService
    {
        public Task<GroupDTO> CreateGroup(GroupCreateDTO newGroup);
        public Task AddContactToGroup(int ContactId, int GroupId);
        public Task<GroupDTO> GetGroupContacts(int GroupId);
        public Task<IEnumerable<GroupDTO>> GetAllGroups();
    }
}
