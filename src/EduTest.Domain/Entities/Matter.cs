using System;
using System.Collections.Generic;

namespace EduTest.Domain.Entities
{
    public partial class Matter : BaseEntity
    {
        public Matter()
        {
            Students = new HashSet<Student>();
        }

        public string Name { get; set; }
        public int CourseId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
