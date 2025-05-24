using AutoMapper;
using MediatR;
using School.Application.Interfaces.IRepositories;
using School.Domain.ModelsDto;
using School.Presentaion.Models;

namespace School.Application.Handlers
{ 
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly ISchoolRepository schoolRepository;
        private readonly IMapper mapper;

        public GetUserByIdHandler(ISchoolRepository schoolRepository, IMapper mapper)
        {
            this.schoolRepository = schoolRepository;
            this.mapper = mapper;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = null;
            UserDto userDto = await schoolRepository.GetUser(request.UserId);
            if(userDto != null)
            {
                user = mapper.Map<User>(userDto);
                List<GroupDto> groups = await schoolRepository.GetGroups() ?? new List<GroupDto>();
                foreach(GroupDto group in groups)
                {
                    if(userDto.Groups.Contains(group.Id))
                    {
                        user.Groups.Add(group.Name);
                    }
                }
            }
            return user;
        }
    }
}
