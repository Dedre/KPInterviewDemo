using AutoMapper;
using MediatR;
using School.Application.Interfaces.IRepositories;
using School.Domain.ModelsDto;
using School.Presentaion.Models;

namespace School.Application.Handlers.Queries.GroupQueries.GetAllGroups
{
    public class GetAllGroupsHandler : IRequestHandler<GetAllGroupsQuery, List<Group>>
    {
        private readonly ISchoolRepository schoolRepository;
        private readonly IMapper mapper;

        public GetAllGroupsHandler(ISchoolRepository schoolRepository, IMapper mapper)
        {
            this.schoolRepository = schoolRepository;
            this.mapper = mapper;
        }
        public async Task<List<Group>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            List<Group> result = new List<Group>();
            List<PermissionDto> permissions = await schoolRepository.GetPermissions() ?? new List<PermissionDto>();
            List<GroupDto> groups = await schoolRepository.GetGroups() ?? new List<GroupDto>();
            foreach (GroupDto groupDto in groups)
            {
                var goupToAdd = mapper.Map<Group>(groupDto);

                if(groupDto.Permissions?.Count > 0)
                {
                    foreach (int permissionId in groupDto.Permissions)
                    {
                        goupToAdd.Permissions.Add(permissions.FirstOrDefault(perm => perm.Id == permissionId)?.Name ?? "N/A");
                    }
                }
                result.Add(goupToAdd);
            }
            return result;
        }
    }
}
