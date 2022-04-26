using System.Collections.Generic;

namespace EduTest.Domain.Entities
{
    public partial class Course : BaseEntity
    {
        public Course()
        {
            Matters = new HashSet<Matter>();
            Students = new HashSet<Student>();
        }

        public string Name { get; set; }

        public virtual ICollection<Matter> Matters { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
