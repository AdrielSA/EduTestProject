using System;

namespace EduTest.Services.QueryFilters
{
    public class MatterQueryFilter
    {
        public int? CourseId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
