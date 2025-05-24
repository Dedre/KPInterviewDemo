using School.Domain.ModelsDto;

namespace School.Application.Interfaces.IRepositories
{
    public interface ISchoolRepository
    {
        public Task<UserDto> GetUser(int userId);
        public Task<int> GetUserCount();
        public Task<int> AddUser(UserDto user);
        public Task<bool> DeleteUser(UserDto userToDelete);
        public Task<bool> UpdateUser(UserDto userToUpdate);
        public Task<List<GroupDto>> GetGroups();
        public Task<int> GetUserCountPerGroup(int groupId);
        public Task<List<PermissionDto>> GetPermissions();
    }
}
