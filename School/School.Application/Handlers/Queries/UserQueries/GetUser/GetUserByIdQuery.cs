using MediatR;
using School.Presentaion.Models;
using System.ComponentModel.DataAnnotations;

namespace School.Application.Handlers
{
    public class GetUserByIdQuery : IRequest<User>
    {
        [Required]
        public int UserId { get; set; }
    }
}
