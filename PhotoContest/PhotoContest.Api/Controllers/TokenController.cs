using Microsoft.AspNetCore.Mvc;
using PhotoContest.Services.Contracts.SecurityContracts;
using PhotoContest.Services.Models.SecurityModels;
using System;
using System.Threading.Tasks;

namespace PhotoContest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;
        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }
        /// <summary>
        /// Create token.
        /// </summary>
        /// <param name="model">Validation details.</param>
        /// <returns>Returns created token.</returns>
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromQuery]TokenRequestModel model)
        {
            try
            {
                var result = await this.tokenService.GetTokenAsync(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
