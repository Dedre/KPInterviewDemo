using MediatR;
using School.Application.Interfaces.IRepositories;
using School.Domain.ModelsDto;

namespace School.Application.Handlers.Commands.UserCommands.EditUser
{
    public class RemoveGroupForUserByIdHandler : IRequestHandler<RemoveGroupForUserByIdCommand, bool>
    {
        private readonly ISchoolRepository schoolRepository;

        public RemoveGroupForUserByIdHandler(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public async Task<bool> Handle(RemoveGroupForUserByIdCommand request, CancellationToken cancellationToken)
        {
            UserDto userToEdit = await schoolRepository.GetUser(request.UserId);
            if (userToEdit == null)
            {
                throw new Exception($"Could not find user with ID {request.UserId}.");
            }
            List<GroupDto> groups = await schoolRepository.GetGroups() ?? new List<GroupDto>();
            foreach (int groupId in request.GroupIds)
            {
                if (groups.FirstOrDefault(g => g.Id == groupId) == null)
                {
                    throw new Exception($"Invalid group provided: {groupId}.");
                } else if(userToEdit.Groups.Contains(groupId))
                {
                    userToEdit.Groups.Remove(groupId);
                }
            }
            return await schoolRepository.UpdateUser(userToEdit);
        }
    }
}
