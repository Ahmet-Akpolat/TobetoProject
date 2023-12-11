using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Course : Entity<Guid>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int? Like { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual ICollection<CourseContent> CourseContents { get; set; }
    public virtual Manufacturer Manufacturers { get; set; }
}