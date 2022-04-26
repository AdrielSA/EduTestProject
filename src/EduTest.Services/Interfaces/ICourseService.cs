using EduTest.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduTest.Services.Interfaces
{
    public interface ICourseService
    {
        Task AddCourseAsync(CourseDto courseDto);
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> GetCourseAsync(int id);
        Task RemoveCourseAsync(int id);
        Task UpdateCourseAsync(int id, CourseDto courseDto);
    }
}
