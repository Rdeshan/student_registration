using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistration.Application.Interfaces;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // 1. Register Student
        public async Task<bool> RegisterStudentAsync(Student student)
        {
          
            student.CreatedDate = DateTime.Now;
            student.IsDeleted = false;

            await _studentRepository.AddAsync(student);
            return await _studentRepository.SaveChangesAsync();
        }

        // 2. Get All Active Students
        public async Task<IEnumerable<Student>> GetActiveStudentsAsync()
        {
            return await _studentRepository.GetAllActiveAsync();
        }

        // 3. Get Student By ID
        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }   

        // 4. Update Student
        public async Task<bool> UpdateStudentAsync(Student student)
        {
            student.UpdatedDate = DateTime.Now;
            await _studentRepository.UpdateAsync(student);
            return await _studentRepository.SaveChangesAsync();
        }

        // 5. Delete (Soft Delete)
        public async Task<bool> DeleteStudentAsync(int id)
        {
        
            await _studentRepository.SoftDeleteAsync(id);


            return await _studentRepository.SaveChangesAsync();
        }
    }
}