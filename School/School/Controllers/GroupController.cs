using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Handlers.Queries.GroupQueries.GetAllGroups;
using School.Application.Handlers.Queries.GroupQueries.GetGroups;
using School.Presentaion.Models;

namespace School.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private readonly IMediator mediator;

        public GroupController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("/allGroups")]
        public async Task<ActionResult> AllGroupData()
        {
            try
            {
                List<Group> groupsResult = await mediator.Send(new GetAllGroupsQuery());
                if (groupsResult != null)
                {
                    return Ok(groupsResult);
                } else
                {
                    return NotFound();
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/totalUsersPerGroup/{id}")]
        public async Task<ActionResult> TotalUsersPerGroup(int id)
        {
            try
            {
                return Ok(await mediator.Send(new GetUserCountPerGroupIdQuery() { GroupId = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
