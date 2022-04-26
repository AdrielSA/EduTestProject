using EduTest.Domain.Entities;
using System.Threading.Tasks;

namespace EduTest.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Course> CourseRepository { get; }
        IRepository<Student> StudentRepository { get; }
        IRepository<Matter> MatterRepository { get; }
        Task SaveChangesAsync();
    }
}
