using eCommerece.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerece.Application.Commands.UserRegisterCommand
{
    public record UserRegisterCommand(string Email, string Password, string PersonName, string Gender) : IRequest<AuthenticationResponse?>;
}
