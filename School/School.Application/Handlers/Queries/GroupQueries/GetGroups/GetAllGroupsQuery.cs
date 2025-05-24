using MediatR;
using School.Presentaion.Models;

namespace School.Application.Handlers.Queries.GroupQueries.GetAllGroups
{
    public class GetAllGroupsQuery : IRequest<List<Group>>
    {
    }
}
