using EduTest.Services.DTOs;
using EduTest.Services.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduTest.Services.Interfaces
{
    public interface IMatterService
    {
        Task AddMatterAsync(MatterDto matterDto);
        Task<IEnumerable<MatterDto>> GetAllMattersAsync(MatterQueryFilter filter = null);
        Task<MatterDto> GetMatterAsync(int id);
        Task RemoveMatterAsync(int id);
        Task UpdateMatterAsync(int id, MatterDto matterDto);
    }
}
