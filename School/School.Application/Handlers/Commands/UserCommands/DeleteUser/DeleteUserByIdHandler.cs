using MediatR;
using School.Application.Interfaces.IRepositories;
using School.Domain.ModelsDto;

namespace School.Application.Handlers.Commands.UserCommands.DeleteUser
{
    public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdCommand, bool>
    {
        private readonly ISchoolRepository schoolRepository;

        public DeleteUserByIdHandler(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public async Task<bool> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            UserDto userToDelete = await schoolRepository.GetUser(request.UserId);
            if (userToDelete == null)
            {
                throw new Exception($"Could not find user with ID {request.UserId}.");
            }
            return await schoolRepository.DeleteUser(userToDelete);
        }
    }
}
