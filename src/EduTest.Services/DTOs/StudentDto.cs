using System;

namespace EduTest.Services.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int? CourseId { get; set; }
        public int? MatterId { get; set; }
    }
}
