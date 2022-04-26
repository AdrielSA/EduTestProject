using AutoMapper;
using EduTest.Domain.Entities;
using EduTest.Services.DTOs;

namespace EduTest.Services.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>()
                .ReverseMap()
                .ForMember(p => p.Course, c => c.Ignore())
                .ForMember(p => p.Matter, c => c.Ignore())
                .ForMember(p => p.CreationDate, c => c.Ignore())
                .ForMember(p => p.UpdateDate, c => c.Ignore());

            CreateMap<Matter, MatterDto>()
                .ReverseMap()
                .ForMember(p => p.Course, c => c.Ignore())
                .ForMember(p => p.Students, c => c.Ignore())
                .ForMember(p => p.CreationDate, c => c.Ignore())
                .ForMember(p => p.UpdateDate, c => c.Ignore());

            CreateMap<Course, CourseDto>()
                .ReverseMap()
                .ForMember(p => p.Matters, c => c.Ignore())
                .ForMember(p => p.Students, c => c.Ignore())
                .ForMember(p => p.CreationDate, c => c.Ignore())
                .ForMember(p => p.UpdateDate, c => c.Ignore());
        }
    }
}
