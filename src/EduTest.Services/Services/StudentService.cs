using AutoMapper;
using EduTest.Infrastructure.Interfaces;
using EduTest.Services.DTOs;
using EduTest.Domain.Entities;
using EduTest.Domain.Exceptions;
using EduTest.Services.Interfaces;
using EduTest.Services.QueryFilters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using EduTest.Domain.Options;
using EduTest.Domain.CustomEntities;

namespace EduTest.Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PaginationOptions _options;
        private readonly IUriService<StudentDto> _uriService;

        public StudentService(
            IUnitOfWork unitOfWork,
            IUriService<StudentDto> uriService,
            IMapper mapper, 
            IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _uriService = uriService;
            _mapper = mapper;
            _options = options.Value;
        }

        public async Task<StudentDto> GetStudentAsync(int id)
        {
            var student= await _unitOfWork.StudentRepository.GetAsync(id);
            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }

        public async Task<(PagedList<StudentDto>, MetaData)> GetAllStudentsAsync(StudentQueryFilter filter = null)
        {
            filter.PageNumber = filter.PageNumber.Equals(0) ? _options.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize.Equals(0) ? _options.DefaultPageSize : filter.PageSize;
            IEnumerable<Student> students = null;
            if (filter.LastName != null)
            {
                students = await _unitOfWork.StudentRepository
                    .GetAllAsync(p => p.LastName.Equals(filter.LastName));
            }
            if (filter.CourseId != null)
            {
                students = await _unitOfWork.StudentRepository
                    .GetAllAsync(p => p.CourseId.Equals(filter.CourseId));
            }
            if (filter.MatterId != null)
            {
                students = await _unitOfWork.StudentRepository
                    .GetAllAsync(p => p.MatterId.Equals(filter.MatterId));
            }
            if (students == null)
            {
                students = await _unitOfWork.StudentRepository.GetAllAsync();
            }


            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            var pagedStudent = _uriService.Create(studentsDto, filter.PageSize, filter.PageNumber);
            var nextPag = filter.PageNumber >= 1 && filter.PageNumber < pagedStudent.TotalPages ? filter.PageNumber + 1 : 1;
            var prevPag = filter.PageNumber - 1 >= 1 && filter.PageNumber <= pagedStudent.TotalPages ? filter.PageNumber - 1 : 1;
            var metaData = new MetaData
            {
                NextPageUrl = _uriService.GetPaginationUri(filter, nextPag, "/api/student").ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(filter, prevPag, "/api/student").ToString(),
                TotalCount = pagedStudent.TotalCount,
                PageSize = pagedStudent.PageSize,
                CurrentPage = pagedStudent.CurrentPage,
                TotalPage = pagedStudent.TotalPages,
                HasNextPage = pagedStudent.HasNextPage,
                HasPreviousPage = pagedStudent.HasPreviousPage
            };
            return (pagedStudent, metaData);
        }

        public async Task AddStudentAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await CheckMatter(student.CourseId, student.MatterId);
            student.CreationDate = DateTime.UtcNow;
            await _unitOfWork.StudentRepository.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(int id, StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await CheckMatter(student.CourseId, student.MatterId);
            var entity = await _unitOfWork.StudentRepository.GetAsync(id);
            entity.FirstName = student.FirstName;
            entity.LastName = student.LastName;
            entity.DateOfBirth = student.DateOfBirth;
            entity.Email = student.Email;
            entity.MatterId = student.MatterId;
            entity.CourseId = student.CourseId;
            entity.UpdateDate = DateTime.UtcNow;
            _unitOfWork.StudentRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveStudentAsync(int id)
        {
            await _unitOfWork.StudentRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        #region Validations

        private async Task CheckMatter(int? courseId, int? matterId)
        {
            if (matterId.HasValue)
            {
                var matter = await _unitOfWork.MatterRepository.GetAsync(matterId.Value);
                if (!courseId.Value.Equals(matter.CourseId))
                    throw new ApiException("La materia no está habilitada en este curso.");
            }
        }

        #endregion
    }
}
