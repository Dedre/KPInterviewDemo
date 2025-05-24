using MediatR;
using System.ComponentModel.DataAnnotations;

namespace School.Application.Handlers.Commands.UserCommands.EditUser
{
    public class RemoveGroupForUserByIdCommand : IRequest<bool>
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public List<int> GroupIds { get; set; } = new List<int>();
    }
}
