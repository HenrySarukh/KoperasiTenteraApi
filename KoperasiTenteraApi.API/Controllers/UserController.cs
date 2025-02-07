using KoperasiTenteraApi.Application.Authentication.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KoperasiTenteraApi.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public sealed class UserController(
        IMediator mediator,
        ILogger<AuthenticationController> logger)
        : ApiController
    {
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request)
        {
            var result = await mediator.Send(request);
            if (result.IsError)
            {
                return Problem(result.Errors);
            }

            return Created();
        }
    }
}