namespace P01_StudentSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> studentCourse)
        {
            studentCourse
                .HasKey(sc => new { sc.CourseId, sc.StudentId });

            studentCourse
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

            studentCourse
              .HasOne(sc => sc.Course)
              .WithMany(c => c.StudentsEnrolled)
              .HasForeignKey(sc => sc.CourseId);
        }
    }
}
