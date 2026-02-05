using System;
using System.Collections.Generic;
using StudentRegistration.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Application.Interfaces
{
    public interface IStudentService
    {
      
        Task<bool> RegisterStudentAsync(Student student);

        Task<IEnumerable<Student>> GetActiveStudentsAsync();

        Task<Student?> GetStudentByIdAsync(int id);
     
        Task<bool> UpdateStudentAsync(Student student);
  
        Task<bool> DeleteStudentAsync(int id);
    }
}
