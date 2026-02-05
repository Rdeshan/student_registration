
using StudentRegistration.Domain.Entities;  

namespace StudentRegistration.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> ValidateUserAsync(String email, String password);
        Task AddUserAsync(User user);

        Task<bool> SaveChangesAsync();


    }
}
