using MediatR;
using School.Application.Interfaces.IRepositories;
using School.Domain.ModelsDto;

namespace School.Application.Handlers.Commands.UserCommands.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly ISchoolRepository schoolRepository;

        public AddUserHandler(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }
        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            List<GroupDto> groups = await schoolRepository.GetGroups() ?? new List<GroupDto>();
            foreach(int grouId in request.Groups)
            {
                if(groups.FirstOrDefault(g => g.Id == grouId) == null)
                {
                    throw new Exception($"Invalid group provided: {grouId}.");
                }
            }
            UserDto user = new UserDto()
            {
                Name = request.Name,
                Surname = request.Surname,
                Groups = request.Groups
            };
            return await schoolRepository.AddUser(user);
        }
    }
}
