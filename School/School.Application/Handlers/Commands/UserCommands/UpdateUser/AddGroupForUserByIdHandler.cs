using MediatR;
using School.Application.Interfaces.IRepositories;
using School.Domain.ModelsDto;

namespace School.Application.Handlers.Commands.UserCommands.EditUser
{
    public class AddGroupForUserByIdHandler : IRequestHandler<AddGroupForUserByIdCommand, bool>
    {
        private readonly ISchoolRepository schoolRepository;

        public AddGroupForUserByIdHandler(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public async Task<bool> Handle(AddGroupForUserByIdCommand request, CancellationToken cancellationToken)
        {
            UserDto userToEdit = await schoolRepository.GetUser(request.UserId);
            if (userToEdit == null)
            {
                throw new Exception($"Could not find user with ID {request.UserId}.");
            }
            List<GroupDto> groups = await schoolRepository.GetGroups() ?? new List<GroupDto>();
            foreach (int grouId in request.GroupIds)
            {
                if (groups.FirstOrDefault(g => g.Id == grouId) == null)
                {
                    throw new Exception($"Invalid group provided: {grouId}.");
                } else if(!userToEdit.Groups.Contains(grouId))
                {
                    userToEdit.Groups.Add(grouId);
                }
            }
            return await schoolRepository.UpdateUser(userToEdit);
        }
    }
}
