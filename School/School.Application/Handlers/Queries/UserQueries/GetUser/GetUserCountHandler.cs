using MediatR;
using School.Application.Interfaces.IRepositories;

namespace School.Application.Handlers.Queries.UserQueries.GetUser
{
    public class GetUserCountHandler : IRequestHandler<GetUserCountQuery, int>
    {
        private readonly ISchoolRepository schoolRepository;

        public GetUserCountHandler(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public Task<int> Handle(GetUserCountQuery request, CancellationToken cancellationToken)
        {
            return schoolRepository.GetUserCount();
        }
    }
}
