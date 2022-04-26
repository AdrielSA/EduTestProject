using System;

namespace EduTest.Services.QueryFilters
{
    public class StudentQueryFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public int? CourseId { get; set; }
        public int? MatterId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
