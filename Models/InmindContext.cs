using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UniversitySystem.Models
{
    public partial class InmindContext : DbContext
    {
        public InmindContext()
        {
        }

        public InmindContext(DbContextOptions<InmindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StudentsPerClass> StudentsPerClasses { get; set; } = null!;
        public virtual DbSet<TeachersPerCourse> TeachersPerCourses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Inmind;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses", "University");

                entity.HasIndex(e => e.Id, "courses_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Faculty).HasColumnType("character varying");

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "University");

                entity.HasIndex(e => e.Id, "roles_\"id\"_uindex")
                    .IsUnique();

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<StudentsPerClass>(entity =>
            {
                entity.ToTable("StudentsPerClass", "University");

                entity.HasIndex(e => e.Id, "students_per_class_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"University\".\"Students_per_class_Id_seq\"'::regclass)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentsPerClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClassId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsPerClasses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StudentId");
            });

            modelBuilder.Entity<TeachersPerCourse>(entity =>
            {
                entity.ToTable("TeachersPerCourse", "University");

                entity.HasComment("Classes");

                entity.HasIndex(e => e.Id, "teacher_per_course_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"University\".\"Teacher_per_course_Id_seq\"'::regclass)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TeachersPerCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CourseId");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeachersPerCourses)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TeacherId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "University");

                entity.HasIndex(e => e.Id, "users_\"id\"_uindex")
                    .IsUnique();

                entity.Property(e => e.Email).HasColumnType("character varying");

                entity.Property(e => e.Name).HasColumnType("character varying");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RoleId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
