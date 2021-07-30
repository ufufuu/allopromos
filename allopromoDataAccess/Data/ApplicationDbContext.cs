using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using allopromoDataAccess.Model;
//using Microsoft.Identity
namespace allopromoDataAccess.Data
{
    //public class ApplicationDbContext:IdentityDbContext<IdentityUser, IdentityRole, string>, DbContext
    //public class ApplicationDbContext: IdentityDbContext<IdentityUser>, DbContext
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser> // ?vs DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<Store>().ToTable("Users");
            
            modelBuilder.Entity<User>().HasMany(u => u.Photos).WithOne(i => i.User);

            modelBuilder.Entity<Photo>().ToTable("Photos");
            modelBuilder.Entity<Photo>().HasOne(i => i.User).WithMany(u => u.Photos);

            modelBuilder.Entity<Category>().ToTable("Categories");
            */
        }
        public DbSet<Store> Stores { get; set; }
    }
}
//https://www.tektutorialshub.com/asp-net-core/asp-net-core-identity-tutorial/

// On this July 05, 2021 !

//CODE-FIRST ENTITY FRAMEWORK
//1- One to One  Student has One Adress
//Student {int StudentId, Name, virtual Adress adresse}
//Adress{int StudentId, Adresse,  City, Postal Code,  virtual Student student }
//Below Configure  StudentId as pk and as foreign key in OnModelCreating method of the context class !

//2- One to Many: in case a a student has one Teacher and teacher can have a of of Students
//Student{Id, Name, Adress, virtual Teacher teacher }
//Teacher{TeacherId, TeacherName, virtual List<Student> students(Lazy loading reading Realted Data for Virtual)}

//3- Many-to-Many: Student to Courses
//Student{.....List<Courses> courses}
//Course{CourseId, CourseName, List<Student> students}
//This Creates Another JOIN table "StudentCourses" or "Enrollments" in this case !
//Enrollments{intEnrollmentId, CourseId, StudentId, Grade grade, virtual Course course, virtual Student student}

//WHAT THEN should BE Model-First Strategy???
