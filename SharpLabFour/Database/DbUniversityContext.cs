using Microsoft.EntityFrameworkCore;
using SharpLabFour.Models.Students;
using SharpLabFour.Models.Subjects;

namespace SharpLabFour.Database
{
    public class DbUniversityContext : DbContext
    {
        public DbUniversityContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<SubjectOfStudent> SubjectsOfStudent { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=Database\\University.db");
        }


        // Data
        public void AddStudent(Student student)
        {
            try
            {
                Students.Add(student);
                SaveChanges();
            }
            catch (System.Exception)
            {
            }
        }
        public void RemoveStudent(Student student)
        {
            try
            {
                Students.Remove(student);
                SaveChanges();
            }
            catch (System.Exception)
            {
            }
        }
        public void UpdateStudent(Student student)
        {
            try
            {
                Student studentToUpdate = Students.Find(student.Id);
                if (studentToUpdate != null)
                {
                    studentToUpdate = student;
                    SaveChanges();
                }
            }
            catch (System.Exception)
            {
            }
        }
        public void AddSubject(Subject subject)
        {
            try
            {
                Subjects.Add(subject);
                SaveChanges();
            }
            catch (System.Exception)
            {
            }
        }
        public void RemoveSubject(Subject subject)
        {
            try
            {
                Subjects.Remove(subject);
                SaveChanges();
            }
            catch (System.Exception)
            {
            }
        }
        public void UpdateSubject(Subject subject)
        {
            try
            {
                Subject subjectToUpdate = Subjects.Find(subject.Id);
                if (subjectToUpdate != null)
                {
                    subjectToUpdate = subject;
                    SaveChanges();
                }
            }
            catch (System.Exception)
            {
            }
        }
        public void RemoveSubjectOfStudent(SubjectOfStudent subjectOfStudent)
        {
            try
            {
                SubjectsOfStudent.Remove(subjectOfStudent);
                SaveChanges();
            }
            catch (System.Exception)
            {
            }
        }
    }
}