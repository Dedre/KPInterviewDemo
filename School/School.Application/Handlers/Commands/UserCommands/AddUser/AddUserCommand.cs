using MediatR;
using System.ComponentModel.DataAnnotations;

namespace School.Application.Handlers.Commands.UserCommands.AddUser
{
    public class AddUserCommand : IRequest<int>
    {
        [Required]
        [RegularExpression("^[A-Za-z-]+$")]
        [MinLength(1)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z-]+$")]
        [MinLength(1)]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        public List<int> Groups { get; set; }
    }
}
