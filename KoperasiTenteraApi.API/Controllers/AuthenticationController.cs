using KoperasiTenteraApi.Application.Authentication.Commands.ValidateOtp;
using KoperasiTenteraApi.Application.Authentication.Queries.GetByIC;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KoperasiTenteraApi.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public sealed class AuthenticationController(
        IMediator mediator,
        ILogger<AuthenticationController> logger)
        : ApiController
    {
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> ValidateOtp([FromBody] ValidateOtpCommand request)
        {
            var result = await mediator.Send(request);
            if (result.IsError)
            {
                return Problem(result.Errors);
            }

            return Ok(result.Value);
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetOtpByIC([FromQuery] GetByICQuery query)
        {
            var result = await mediator.Send(query);
            if (result.IsError)
            {
                return Problem(result.Errors);
            }

            return Ok(result.Value);
        }
    }
}