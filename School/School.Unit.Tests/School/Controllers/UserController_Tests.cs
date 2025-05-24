using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using School.Application.Handlers.Commands.UserCommands.AddUser;
using School.Controllers;
using School.Presentaion.Models;

namespace School.Unit.Tests.School.Controllers
{
    public class UserController_Tests
    {
        UserController userController;
        Mock<IMediator> mediatr;

        public UserController_Tests()
        {
            mediatr = new Mock<IMediator>();
            userController = new UserController(mediatr.Object);
        }

        [Fact]
        public async void ShouldReturnBadRequestIfUserNameEmpty()
        {
            var res = userController.Create(new AddUserCommand()
            {
                Name = "",
                Surname = "Surname",
                Groups = []
            });
            var badResult = Assert.IsType<OkObjectResult>(res.Result);
            Assert.Equal("xyc", badResult.Value);
        }

        [Fact]
        public async void ShouldReturnBadRequestIfUserNameContainsSpecialChars()
        {

        }

        [Fact]
        public async void ShouldReturnBadRequestIfUserNameLongerThanThirtyChars()
        {

        }

        [Fact]
        public async void ShouldReturnBadRequestIfUserSurnameEmpty()
        {

        }

        [Fact]
        public async void ShouldReturnBadRequestIfUserSurnameContainsSpecialChars()
        {

        }

        [Fact]
        public async void ShouldReturnBadRequestIfUserSurnameLongerThanThirtyChars()
        {

        }
    }
}
