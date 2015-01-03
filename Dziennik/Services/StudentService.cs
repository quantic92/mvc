using Dziennik.DTOs;
using Dziennik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.Services
{
    public class StudentService
    {
        public List<Student> GetAllStudents()
        {
            using (var db = new DziennikDbContext())
            {
                var list = db.Students.ToList();
                return list;
            }
        }

        public Student GetStudentById(int id) {
            using (var db = new DziennikDbContext()) {
                return db.Students.First(s => s.StudentID == id);
            }
        }

        public List<Student> GetStudentsForParent(int id)
        {
            using (var db = new DziennikDbContext())
            {
                return db.Students.Where(s => s.Parent.ParentID == id).ToList();
            }
        }

        public void AddStudent(Student student)
        {
            using (var db = new DziennikDbContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void EditStudent(Student student)
        {
            using (var db = new DziennikDbContext())
            {
                var original = db.Students.Find(student.StudentID);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(student);
                    db.SaveChanges();
                }
            }
        }
     }
}