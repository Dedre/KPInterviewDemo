using Moq;
using School.Application.Handlers.Commands.UserCommands.DeleteUser;
using School.Application.Interfaces.IRepositories;
using School.Domain.ModelsDto;
namespace School.Unit.Tests.School.Application.Handlers.Commands.DeleteUser
{
    public class DeleteUserByIdHandler_Tests
    {
        Mock<ISchoolRepository> schoolRepository;
        DeleteUserByIdHandler deleteUserByIdHandler;
        ISchoolRepository mockSchoolRepositoryObject;

        public DeleteUserByIdHandler_Tests()
        {
            schoolRepository = new Mock<ISchoolRepository>();
            schoolRepository.Setup(x => x.DeleteUser(It.IsAny<UserDto>())).Returns(It.IsAny<Task<bool>>);
            schoolRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<UserDto>(null));
            mockSchoolRepositoryObject = schoolRepository.Object;
            deleteUserByIdHandler = new DeleteUserByIdHandler(mockSchoolRepositoryObject);
        }

        [Fact]
        public async Task ItShouldShowErrorIfNoUserFoundForProvidedId()
        {
            Exception ex = await Assert.ThrowsAsync<Exception>(() => deleteUserByIdHandler.Handle(new DeleteUserByIdCommand() { UserId = 1 }, CancellationToken.None));
            Assert.Equal("Could not find user with ID 1.", ex.Message);
        }
    }
}
