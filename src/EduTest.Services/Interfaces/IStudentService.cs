using EduTest.Domain.CustomEntities;
using EduTest.Services.DTOs;
using EduTest.Services.QueryFilters;
using System.Threading.Tasks;

namespace EduTest.Services.Interfaces
{
    public interface IStudentService
    {
        Task AddStudentAsync(StudentDto studentDto);
        Task<(PagedList<StudentDto>, MetaData)> GetAllStudentsAsync(StudentQueryFilter filter = null);
        Task<StudentDto> GetStudentAsync(int id);
        Task RemoveStudentAsync(int id);
        Task UpdateStudentAsync(int id, StudentDto studentDto);
    }
}