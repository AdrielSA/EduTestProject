using EduTest.Domain.Entities;
using EduTest.Infrastructure.Context;
using EduTest.Infrastructure.Interfaces;
using EduTest.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace EduTest.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EduTestDbContext _context;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Matter> _matterRepository;

        public UnitOfWork(
            EduTestDbContext context,
            IRepository<Course> courseRepository,
            IRepository<Student> studentRepository,
            IRepository<Matter> matterRepository)
        {
            _context = context;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _matterRepository = matterRepository;
        }

        public IRepository<Course> CourseRepository => _courseRepository ?? new Repository<Course>(_context);
        public IRepository<Student> StudentRepository => _studentRepository ?? new Repository<Student>(_context);
        public IRepository<Matter> MatterRepository => _matterRepository ?? new Repository<Matter>(_context);

        public async ValueTask DisposeAsync()
        {
            if (_context != null)
                await _context.DisposeAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
