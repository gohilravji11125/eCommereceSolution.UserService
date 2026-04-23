using eCommerece.Application.Interfaces;
using eCommerece.Core.DTO;
using MediatR;

namespace eCommerece.Application.Commands.UserLoginCommand
{
    internal class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, AuthenticationResponse?>
    {
        private readonly IUserService _userService;
        public UserLoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<AuthenticationResponse?> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var loginRequest = new LoginRequest(
                Email: request.Email,
                Password: request.Password
            );
            return await _userService.LoginUserAsync(loginRequest);
        }
    }
}
