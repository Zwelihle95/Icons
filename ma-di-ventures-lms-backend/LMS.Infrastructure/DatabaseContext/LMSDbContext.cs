using LMS.Domain.Entities;
using LMS.Domain.ValueObjects;
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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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