using Microsoft.EntityFrameworkCore;
using School.Application.Interfaces.IRepositories;
using School.Domain.Contexts;
using School.Domain.ModelsDto;
using School.Infrastructure.Config;

namespace School.Infrastructure.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ISchoolDbContextFactory schoolContextFactory;
        private ConnectionStrings connectionStrings;

        public SchoolRepository(ISchoolDbContextFactory schoolContextFactory, ConnectionStrings connectionStrings)
        {
            this.schoolContextFactory = schoolContextFactory;
            this.connectionStrings = connectionStrings;
        }
        public async Task<int> AddUser(UserDto user)
        {
            using (SchoolContext schoolContext = schoolContextFactory.CreateDbContext([connectionStrings.SqlServer]))
            {
                await schoolContext.Users.AddAsync(user);
                await schoolContext.SaveChangesAsync();
                return user.Id;
            }
        }

        public async Task<List<GroupDto>> GetGroups()
        {
            using (SchoolContext schoolContext = schoolContextFactory.CreateDbContext([connectionStrings.SqlServer]))
            {
                return await schoolContext.Groups.ToListAsync();
            }
        }

        public async Task<List<PermissionDto>> GetPermissions()
        {
            using (SchoolContext schoolContext = schoolContextFactory.CreateDbContext([connectionStrings.SqlServer]))
            {
                return await schoolContext.Permissions.ToListAsync();
            }
        }

        public async Task<UserDto> GetUser(int userId)
        { 
            using(SchoolContext schoolContext = schoolContextFactory.CreateDbContext([connectionStrings.SqlServer]))
            {
                return await schoolContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
            }
        }

        public async Task<bool> DeleteUser(UserDto userToDelete)
        {
            using (SchoolContext schoolContext = schoolContextFactory.CreateDbContext([connectionStrings.SqlServer]))
            {
                schoolContext.Users.Remove(userToDelete);
                return await schoolContext.SaveChangesAsync() >= 1 ? true : false;
            }
        }

        public async Task<bool> UpdateUser(UserDto userToUpdate)
        {
            using (SchoolContext schoolContext = schoolContextFactory.CreateDbContext([connectionStrings.SqlServer]))
            {
                schoolContext.Users.Update(userToUpdate);
                return await schoolContext.SaveChangesAsync() >= 1 ? true : false;
            }
        }

        public async Task<int> GetUserCount()
        {
            using (SchoolContext schoolContext = schoolContextFactory.CreateDbContext([connectionStrings.SqlServer]))
            {
                return await schoolContext.Users.CountAsync();
            }
        }

        public async Task<int> GetUserCountPerGroup(int groupId)
        {
            using (SchoolContext schoolContext = schoolContextFactory.CreateDbContext([connectionStrings.SqlServer]))
            {
                return await schoolContext.Users.CountAsync(user => user.Groups.Contains(groupId));
            }
        }
    }
}
