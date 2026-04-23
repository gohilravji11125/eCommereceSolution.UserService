using eCommerece.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerece.Application.Commands.UserLoginCommand
{
    public record UserLoginCommand(string Email, string Password) : IRequest<AuthenticationResponse?>;
}
