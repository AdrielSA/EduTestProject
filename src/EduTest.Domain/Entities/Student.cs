using System;

namespace EduTest.Domain.Entities
{
    public partial class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int? CourseId { get; set; }
        public int? MatterId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Matter Matter { get; set; }
    }
}
