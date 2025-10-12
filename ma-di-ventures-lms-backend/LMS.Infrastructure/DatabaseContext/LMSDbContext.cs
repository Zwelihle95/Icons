using LMS.Domain.Entities;
using LMS.Domain.Enums;
using LMS.Domain.ValueObjects;
using LMS.Infrastructure.Configurations.Courses;
using LMS.Infrastructure.Configurations.Enrollments;
using LMS.Infrastructure.Configurations.Instructors;
using LMS.Infrastructure.Configurations.Lessons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.DatabaseContext
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options) { }
       
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());

            modelBuilder.Entity<User>()
                .HasDiscriminator<Role>("Role")
                .HasValue<Student>(Role.Student)
                .HasValue<Instructor>(Role.Instructor)
                .HasValue<Admin>(Role.Admin);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(user => user.Email)
                    .HasConversion(
                        email => email.UserEmail,
                        emailString => new Email(emailString)
                    );

                entity.Property(user => user.Password)
                    .HasConversion(
                        password => password.HashedPassword,
                        passwordString => new SecurePassword(passwordString)
                    );
            });
        }
    }
}