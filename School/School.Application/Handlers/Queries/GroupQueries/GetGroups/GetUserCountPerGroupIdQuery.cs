using MediatR;
using System.ComponentModel.DataAnnotations;

namespace School.Application.Handlers.Queries.GroupQueries.GetGroups
{
    public class GetUserCountPerGroupIdQuery : IRequest<int>
    {
        [Required]
        public int GroupId { get; set; }
    }
}
