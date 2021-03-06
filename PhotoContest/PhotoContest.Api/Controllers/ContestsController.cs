using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoContest.Services.Models.Create;
using PhotoContest.Services.Models.Update;
using PhotoContest.Services.Services;
using System;
using System.Threading.Tasks;

namespace PhotoContest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestsController : ControllerBase
    {
        private readonly IContestService contestService;

        public ContestsController(IContestService contestService)
        {
            this.contestService = contestService;
        }

        /// <summary>
        /// Get all contests.
        /// </summary>
        /// <returns>Returns all contests.</returns>
        [Authorize(Roles = "Admin,Organizer")]
        [HttpGet]
        public async Task<IActionResult> GetContests()
        {
            var contests = await this.contestService.GetAllAsync();
            return Ok(contests);
        }

        /// <summary>
        /// Get all open contests.
        /// </summary>
        /// <param name="phase">all/Phase 1/Phase 2/Finished</param>
        /// <returns>Returns all open contests.</returns>
        [Authorize]
        [HttpGet("open")]
        public async Task<IActionResult> GetOpenContests(string phase)
        {
            try
            {
                var contests = await this.contestService.GetAllOpenAsync(phase);
                return Ok(contests);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Enroll user into a contest.
        /// </summary>
        /// <param name="contestName">Name of the contest to enroll in.</param>
        /// <returns>Returns true if successful or an appropriate error message.</returns>
        [Authorize(Roles = "User")]
        [HttpPost("enroll")]
        public async Task<IActionResult> Enroll(string contestName)
        {
            try
            {
                var isEnrolled = await this.contestService.EnrollApiAsync(contestName);
                return Ok(isEnrolled);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Invite user into a contest.
        /// </summary>
        /// <param name="contestName">Name of the contest to invite to.</param>
        /// <param name="username">Username of the user to invite.</param>
        /// <returns>Returns true if successful or an appropriate error message.</returns>
        [Authorize(Roles = "Admin,Organizer")]
        [HttpPost("invite")]
        public async Task<IActionResult> Invite(string contestName, string username)
        {
            try
            {
                var isInvited = await this.contestService.InviteAsync(contestName, username);
                return Ok(isInvited);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Choose jury members from users.
        /// </summary>
        /// <param name="contestName">Name of the contest to choose for.</param>
        /// <param name="username">Username of the user to choose.</param>
        /// <returns>Returns true if successful or an appropriate error message.</returns>
        [Authorize(Roles = "Admin,Organizer")]
        [HttpPost("chooseJury")]
        public async Task<IActionResult> ChooseJury(string contestName, string username)
        {
            try
            {
                var isInvited = await this.contestService.ChooseJuryAsync(contestName, username);
                return Ok(isInvited);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update a contest.
        /// </summary>
        /// <param name="contestName">Name for contest to update.</param>
        /// <param name="model">Details of the contest to be updated.</param>
        /// <returns>Returns the updated contest or an appropriate error message.</returns>
        [Authorize(Roles = "Admin,Organizer")]
        [HttpPut]
        public async Task<IActionResult> UpdateContest(string contestName, [FromBody] UpdateContestDTO model)
        {
            try
            {
                var contest = await this.contestService.UpdateAsync(contestName, model);
                return Ok(contest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Create a contest.
        /// </summary>
        /// <param name="dto">Details of the contest to be created.</param>
        /// <returns>Returns the created contest or an appropriate error message.</returns>
        [Authorize(Roles = "Admin,Organizer")]
        [HttpPost]
        public async Task<IActionResult> CreateContest([FromQuery] NewContestDTO dto)
        {
            try
            {
                var contest = await this.contestService.CreateAsync(dto);
                return Created("post", contest);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Delete a contest.
        /// </summary>
        /// <param name="contestName">Name of the contest to delete.</param>
        /// <returns>Returns NoContent or an appropriate error message.</returns>
        [Authorize(Roles = "Admin,Organizer")]
        [HttpDelete]
        public async Task<IActionResult> DeleteContest(string contestName)
        {
            try
            {
                var contest = await this.contestService.DeleteAsync(contestName);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Filter and/or sort contests by phase.
        /// </summary>
        /// <param name="phaseName">phase 1/phase 2/finished</param>
        /// <param name="sortBy">name/category/newest/oldest</param>
        /// <param name="order">asc/desc</param>
        /// <returns>Returns filtered and/or sorted contests or an appropriate error message.</returns>
        [Authorize(Roles = "Admin,Organizer")]
        [HttpGet("filterByPhase")]
        public async Task<IActionResult> GetByPhase([FromQuery] string phaseName, string sortBy, string order)
        {
            try
            {
                var contestsDTO = await this.contestService.GetByPhaseAsync(phaseName, sortBy, order);
                return Ok(contestsDTO);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Filter and/or sort contests by user.
        /// </summary>
        /// <param name="filter">current/past</param>
        /// <returns></returns>
        [Authorize(Roles = "User")]
        [HttpGet("filterForUser")]
        public async Task<IActionResult> GetByUser(string filter)
        {
            try
            {
                var contestsDTO = await this.contestService.GetByUserAsync(filter);
                return Ok(contestsDTO);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
