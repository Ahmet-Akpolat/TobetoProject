using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseContent : Entity<Guid>
{
    public string Header { get; set; }
    public virtual ICollection<Video>? Videos { get; set; }
    public virtual ICollection<Mission>? Missions { get; set; }
    public virtual ICollection<LiveLesson>? LiveLessons { get; set; }


}