using StudentRegistration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User?> ValidateUserAsync(String email , String password);

        Task<bool> RegisterUserAsync(User user);


    }
}
