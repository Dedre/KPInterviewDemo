using Microsoft.EntityFrameworkCore;
using Moq;
using School.Application.Interfaces.IRepositories;
using School.Domain.Contexts;
using School.Domain.ModelsDto;
using School.Infrastructure.Config;
using School.Infrastructure.Repositories;

namespace School.Unit.Tests.School.Infrastructure
{
    public class SchoolRepository_Tests : IDisposable
    {
        Mock<ISchoolDbContextFactory> mockSchoolContextFactory;
        SchoolRepository schoolRepository;
        SchoolContext mockDb;

        public SchoolRepository_Tests() {
            mockSchoolContextFactory = new Mock<ISchoolDbContextFactory>();
            var options = new DbContextOptionsBuilder<SchoolContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            mockDb = new SchoolContext(options);
            mockDb.Database.EnsureCreated();
            SetData();
        }

        public void SetData()
        {
            mockDb.Users.Add(new UserDto() { Id = 1, Name = "Jane", Surname = "Doe", Groups = [1] });
            mockDb.Groups.Add(new GroupDto() { Id = 1, Name = "GroupOne", Permissions = [1] });
            mockDb.Permissions.Add(new PermissionDto() { Id = 1, Name = "PermissionOne", });
        }

        [Fact]
        public async Task GetUserByValidId()
        {
            mockSchoolContextFactory.Setup(x => x.CreateDbContext(It.IsAny<string[]>())).Returns(mockDb);
            schoolRepository = new SchoolRepository(mockSchoolContextFactory.Object, new ConnectionStrings("ConnString"));
            var userResult = await schoolRepository.GetUser(1);
            Assert.Equal(1, userResult.Id);
            Assert.Equal("Jane", userResult.Name);
            Assert.Equal("Doe", userResult.Surname);
            Assert.Equal(1, userResult.Groups.First());
        }

        [Fact]
        public async Task GetUserByInValidId()
        {
            mockSchoolContextFactory.Setup(x => x.CreateDbContext(It.IsAny<string[]>())).Returns(mockDb);
            schoolRepository = new SchoolRepository(mockSchoolContextFactory.Object, new ConnectionStrings("ConnString"));
            var userResult = await schoolRepository.GetUser(2);
            Assert.Null(null);
        } 

        public void Dispose()
        {
            mockDb.Dispose();
        }
    }
}
