using eCommerece.Core.DTO;
namespace eCommerece.Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> RegisterUserAsync(RegisterRequest request);
        Task<AuthenticationResponse?> LoginUserAsync(LoginRequest request);
    }
}
