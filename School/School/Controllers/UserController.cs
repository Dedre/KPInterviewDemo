using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Handlers;
using School.Application.Handlers.Commands.UserCommands.AddUser;
using School.Application.Handlers.Commands.UserCommands.DeleteUser;
using School.Application.Handlers.Commands.UserCommands.EditUser;
using School.Application.Handlers.Queries.UserQueries.GetUser;
using School.Presentaion.Models;

namespace School.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            try
            {
                User userResult = await mediator.Send(new GetUserByIdQuery() { UserId = id });
                if (userResult != null)
                {
                    return Ok(userResult);
                } else
                {
                    return NotFound();
                }
            } catch (Exception ex)
             {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AddUserCommand addUserCommand)
        {
            try
            {
                return Ok(await mediator.Send(addUserCommand));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                return Ok(await mediator.Send(new DeleteUserByIdCommand() { UserId = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/addGroup")]
        public async Task<ActionResult> AddGroup([FromBody] AddGroupForUserByIdCommand addGroupForUserByIdCommand)
        {
            try
            {
                return Ok(await mediator.Send(addGroupForUserByIdCommand));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/removeGroup")]
        public async Task<ActionResult> RemoveGroup([FromBody] RemoveGroupForUserByIdCommand removeGroupForUserByIdCommand)
        {
            try
            {
                return Ok(await mediator.Send(removeGroupForUserByIdCommand));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/totalUsers")]
        public async Task<ActionResult> TotalUsers()
        {
            try
            {
                return Ok(await mediator.Send(new GetUserCountQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
