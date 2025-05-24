using MediatR;
using System.ComponentModel.DataAnnotations;

namespace School.Application.Handlers.Commands.UserCommands.DeleteUser
{
    public class DeleteUserByIdCommand : IRequest<bool>
    {
        [Required]
        public int UserId { get; set; }
    }
}
