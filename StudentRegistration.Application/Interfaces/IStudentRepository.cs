using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.Interfaces
{
    public interface IStudentRepository
    {
        
        Task<Student?> GetByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllActiveAsync();
        Task AddAsync(Student student);

        Task UpdateAsync(Student student);
        Task SoftDeleteAsync(int id);
        
        Task<bool> SaveChangesAsync();
    }
}