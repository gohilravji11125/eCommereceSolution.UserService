using eCommerece.Application.Commands.UserLoginCommand;
using eCommerece.Application.Commands.UserRegisterCommand;
using eCommerece.Core.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerece.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;
        public UsersController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var data = await _sender.Send(new UserRegisterCommand(request.Email, request.Password, request.PersonName, request.Email));
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("User registration failed.");
            }
        }

        [HttpPost]
        [Route("login")]
        [Authorize]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var data = await _sender.Send(new UserLoginCommand(request.Email, request.Password));
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("User login failed.");
            }
        }
    }
}
