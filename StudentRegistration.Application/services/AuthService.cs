using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistration.Application.Interfaces;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User?> ValidateUserAsync(String email,String password)
        {
            var user = await _authRepository.ValidateUserAsync(email, password);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            await _authRepository.AddUserAsync(user);
            return await _authRepository.SaveChangesAsync();
        }

    }
}
