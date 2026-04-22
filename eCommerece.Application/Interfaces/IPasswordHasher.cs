using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerece.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string HashedPassword(string password);
    }
}
