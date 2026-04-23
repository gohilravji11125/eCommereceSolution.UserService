using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerece.Application.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateToken(Guid userId, string email, string PersonName);
    }
}
