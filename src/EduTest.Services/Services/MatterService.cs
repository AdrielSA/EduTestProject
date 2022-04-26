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

namespace EduTest.Services.Services
{
    public class MatterService : IMatterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MatterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MatterDto> GetMatterAsync(int id)
        {
            var matter = await _unitOfWork.MatterRepository.GetAsync(id);
            var matterDto = _mapper.Map<MatterDto>(matter);
            return matterDto;
        }

        public async Task<IEnumerable<MatterDto>> GetAllMattersAsync(MatterQueryFilter filter = null)
        {
            IEnumerable<Matter> matters = null;
            if (filter.StartTime != null)
            {
                matters = await _unitOfWork.MatterRepository
                    .GetAllAsync(p => p.StartTime.Equals(filter.StartTime));
            }
            if (filter.CourseId != null)
            {
                matters = await _unitOfWork.MatterRepository
                    .GetAllAsync(p => p.CourseId.Equals(filter.CourseId));
            }
            if (filter.EndTime != null)
            {
                matters = await _unitOfWork.MatterRepository
                    .GetAllAsync(p => p.EndTime.Equals(filter.EndTime));
            }
            if (matters == null)
            {
                matters = await _unitOfWork.MatterRepository.GetAllAsync();
            }

            var mattersDto = _mapper.Map<IEnumerable<MatterDto>>(matters);
            return mattersDto;
        }

        public async Task AddMatterAsync(MatterDto matterDto)
        {
            var matter = _mapper.Map<Matter>(matterDto);
            if (matter.StartTime >= matter.EndTime)
                throw new ApiException("Fecha de inicio supera fecha de término.");
            matter.CreationDate = DateTime.UtcNow;
            await _unitOfWork.MatterRepository.AddAsync(matter);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateMatterAsync(int id, MatterDto matterDto)
        {
            var matter = _mapper.Map<Matter>(matterDto);
            if (matter.StartTime >= matter.EndTime)
                throw new ApiException("Fecha de inicio supera fecha de término.");
            var entity = await _unitOfWork.MatterRepository.GetAsync(id);
            entity.Name = matter.Name;
            entity.CourseId = matter.CourseId;
            entity.UpdateDate = DateTime.UtcNow;
            _unitOfWork.MatterRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveMatterAsync(int id)
        {
            await _unitOfWork.MatterRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
