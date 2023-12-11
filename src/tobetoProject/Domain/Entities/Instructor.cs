using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Instructor : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
}
