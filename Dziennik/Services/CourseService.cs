using Dziennik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dziennik.Services
{
    public class CourseService
    {
        public void AddCourse(Course course, Grade grade)
        {
            using (var db = new DziennikDbContext())
            {
                course.Grade = grade;
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }

        public void EditCourse(Course course)
        {
            using (var db = new DziennikDbContext())
            {
                var original = db.Courses.Find(course.CourseID);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(course);
                    db.SaveChanges();
                }
            }
        }
    }
}