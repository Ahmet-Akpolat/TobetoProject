using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Categories
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Delete" });
        #endregion
        #region Manufacturers
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Delete" });
        #endregion
        #region Courses
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Delete" });
        #endregion
        #region CourseContents
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Delete" });
        #endregion
        #region Instructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Delete" });
        #endregion
        #region LiveLessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "LiveLessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LiveLessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LiveLessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LiveLessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LiveLessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LiveLessons.Delete" });
        #endregion
        #region Missions
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Missions.Delete" });
        #endregion
        #region Videos
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Videos.Delete" });
        #endregion
        return seeds;
    }
}
