using AutoMapper;
using EduTest.Infrastructure.Interfaces;
using EduTest.Services.DTOs;
using EduTest.Domain.Entities;
using EduTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduTest.Services.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CourseDto> GetCourseAsync(int id)
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(id);
            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();
            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return coursesDto;
        }

        public async Task AddCourseAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            course.CreationDate = DateTime.UtcNow;
            await _unitOfWork.CourseRepository.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(int id, CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            var entity = await _unitOfWork.CourseRepository.GetAsync(id);
            entity.Name = course.Name;
            entity.UpdateDate = DateTime.UtcNow;
            _unitOfWork.CourseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveCourseAsync(int id)
        {
            await _unitOfWork.CourseRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
