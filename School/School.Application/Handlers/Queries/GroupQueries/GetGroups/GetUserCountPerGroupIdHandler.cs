using MediatR;
using School.Application.Interfaces.IRepositories;

namespace School.Application.Handlers.Queries.GroupQueries.GetGroups
{
    public class GetUserCountPerGroupIdHandler : IRequestHandler<GetUserCountPerGroupIdQuery, int>
    {
        private readonly ISchoolRepository schoolRepository;

        public GetUserCountPerGroupIdHandler(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public async Task<int> Handle(GetUserCountPerGroupIdQuery request, CancellationToken cancellationToken)
        {
            return await schoolRepository.GetUserCountPerGroup(request.GroupId);
        }
    }
}
