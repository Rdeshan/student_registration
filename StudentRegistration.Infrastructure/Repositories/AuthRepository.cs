using System;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Domain.Entities;
using StudentRegistration.Application.Interfaces;
using StudentRegistration.Infrastructure.Data;

namespace StudentRegistration.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> ValidateUserAsync(String email , String password)
        {
            return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task AddUserAsync (User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
