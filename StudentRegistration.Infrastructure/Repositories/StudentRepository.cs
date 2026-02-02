using Microsoft.EntityFrameworkCore;
using StudentRegistration.Application.Interfaces;
using StudentRegistration.Domain.Entities;
using StudentRegistration.Infrastructure.Data;

namespace StudentRegistration.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllActiveAsync()
        {
       
            return await _context.Students.ToListAsync();
        }
    

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
        }

        public async Task SoftDeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
               
                student.IsDeleted = true;
                student.UpdatedDate = DateTime.Now;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Returns true if at least one row was affected in SQL Server
            return await _context.SaveChangesAsync() > 0;
        }
    }
}