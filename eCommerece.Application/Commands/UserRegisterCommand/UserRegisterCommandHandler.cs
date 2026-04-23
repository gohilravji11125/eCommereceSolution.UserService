using eCommerece.Application.Interfaces;
using eCommerece.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerece.Application.Commands.UserRegisterCommand
{
    internal class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, AuthenticationResponse?>
    {
        private readonly IUserService _userService;
        public UserRegisterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<AuthenticationResponse?> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var registerRequest = new RegisterRequest(
            
                Email: request.Email,
                Password: request.Password,
                PersonName: request.PersonName,
                Gender: request.Gender
            );
            return await _userService.RegisterUserAsync(registerRequest);
        }
    }
}
