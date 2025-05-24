using AutoMapper;
using Moq;
using School.Application.Handlers;
using School.Application.Interfaces.IRepositories;
using School.Application.Mappers;
using School.Domain.ModelsDto;

namespace School.Unit.Tests.School.Application.Handlers.Queries.UserQueries
{
    public class GetUserByIdHandler_Tests
    {
        Mock<ISchoolRepository> schoolRepository;
        GetUserByIdHandler getUserByIdHandler;
        ISchoolRepository mockSchoolRepositoryObject;

        public GetUserByIdHandler_Tests()
        {
            schoolRepository = new Mock<ISchoolRepository>();
            schoolRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(It.IsAny<Task<UserDto>>);
            mockSchoolRepositoryObject = schoolRepository.Object;
            getUserByIdHandler = new GetUserByIdHandler(mockSchoolRepositoryObject, new MapperConfiguration(cfg => cfg.AddProfile<SchoolMapper>()).CreateMapper());
        }

        [Fact]
        public void ItShouldCallTheRepositoryToGetAUserById()
        {
            getUserByIdHandler.Handle(new GetUserByIdQuery() { UserId = 1 }, CancellationToken.None);
            schoolRepository.Verify(x => x.GetUser(1), Times.Once());
        }
    }
}
