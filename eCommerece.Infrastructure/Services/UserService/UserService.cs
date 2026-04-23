using eCommerece.Application.Interfaces;
using eCommerece.Core.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerece.Infrastructure.Services.UserService
{
    internal class UserService : IUserService
    {
        private readonly IAuthenticationService _authenticationService;
        public UserService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<AuthenticationResponse?> LoginUserAsync(LoginRequest request)
        {
            var userId = Guid.NewGuid();
            var Result = new AuthenticationResponse
            (
                userId,
                request.Email,
                "John Doe",
                "Male",
                _authenticationService.GenerateToken(userId, request.Email, "John Doe"),
                true
            );
            await Task.CompletedTask;
            return Result;
        }
            


        public async Task<AuthenticationResponse?> RegisterUserAsync(RegisterRequest request)
        {
            var userId = Guid.NewGuid();
            var Result = new AuthenticationResponse
            (
                userId,
                request.Email,
                request.PersonName,
                request.Gender,
                _authenticationService.GenerateToken(userId, request.Email, request.PersonName),
                true
            );
            await Task.CompletedTask;
            return Result;
        }
    }
}
