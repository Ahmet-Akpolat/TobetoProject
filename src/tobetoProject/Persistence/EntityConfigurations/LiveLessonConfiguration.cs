using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LiveLessonConfiguration : IEntityTypeConfiguration<LiveLesson>
{
    public void Configure(EntityTypeBuilder<LiveLesson> builder)
    {
        builder.ToTable("LiveLessons").HasKey(ll => ll.Id);

        builder.Property(ll => ll.Id).HasColumnName("Id").IsRequired();
        builder.Property(ll => ll.Name).HasColumnName("Name");
        builder.Property(ll => ll.Language).HasColumnName("Language");
        builder.Property(ll => ll.Description).HasColumnName("Description");
        builder.Property(ll => ll.SubType).HasColumnName("SubType");
        builder.Property(ll => ll.RecordVideo).HasColumnName("RecordVideo");
        builder.Property(ll => ll.StartDate).HasColumnName("StartDate");
        builder.Property(ll => ll.EndDate).HasColumnName("EndDate");
        builder.Property(ll => ll.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ll => ll.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ll => ll.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ll => !ll.DeletedDate.HasValue);
    }
}